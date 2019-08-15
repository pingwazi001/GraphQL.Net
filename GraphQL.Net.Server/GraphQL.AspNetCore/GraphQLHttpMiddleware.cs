using GraphQL.AspNetCore.GraphQLType.QueryType;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GraphQL.AspNetCore
{
    /// <summary>
    /// GraphQL的Http中间件
    /// </summary>
    public class GraphQLHttpMiddleware
    {
        private readonly RequestDelegate _next;
        private const string _jsonContentType= "application/json";
        private const string _graphQLContentType= "application/graphql";
        private const string _formUrlEncodedContentType= "application/x-www-form-urlencoded";
        public GraphQLHttpMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //请求过滤
            if (context.WebSockets.IsWebSocketRequest || !context.Request.Path.StartsWithSegments("/graphql"))
            {
                await _next(context);
                return;
            }
            //对象初始化
            var httpRequest = context.Request;
            var gqlRequest = new GraphQLRequest();
            var writer = context.RequestServices.GetRequiredService<IDocumentWriter>();

            #region 根据条件初始化GraphQLRequest
            if (HttpMethods.IsGet(httpRequest.Method) || (HttpMethods.IsPost(httpRequest.Method) && httpRequest.Query.ContainsKey(GraphQLRequest.QueryKey)))
            {
                ExtractGraphQLRequestFromQueryString(httpRequest.Query, gqlRequest);
            }
            else if (HttpMethods.IsPost(httpRequest.Method))
            {
                if (!MediaTypeHeaderValue.TryParse(httpRequest.ContentType, out var mediaTypeHeader))
                {
                    await WriteBadRequestResponseAsync(context, writer, $"Invalid 'Content-Type' header: value '{httpRequest.ContentType}' could not be parsed.");
                    return;
                }

                switch (mediaTypeHeader.MediaType)
                {
                    case _jsonContentType:
                        gqlRequest = Deserialize<GraphQLRequest>(httpRequest.Body);
                        break;
                    case _graphQLContentType:
                        gqlRequest.Query = await ReadAsStringAsync(httpRequest.Body);
                        break;
                    case _formUrlEncodedContentType:
                        var formCollection = await httpRequest.ReadFormAsync();
                        ExtractGraphQLRequestFromPostBody(formCollection, gqlRequest);
                        break;
                    default:
                        await WriteBadRequestResponseAsync(context, writer, $"Invalid 'Content-Type' header: non-supported media type. Must be of '{_jsonContentType}', '{_graphQLContentType}', or '{_formUrlEncodedContentType}'. See: http://graphql.org/learn/serving-over-http/.");
                        return;
                }
            }
            #endregion
            //文档查询
            var schema = context.RequestServices.GetRequiredService<GraphQLSchema>();
            var result = await new DocumentExecuter().ExecuteAsync(option => {
                option.Schema = schema;
                option.OperationName = gqlRequest.OperationName;
                option.Query = gqlRequest.Query;
                option.Inputs = gqlRequest.GetInputs();
                option.CancellationToken = context.RequestAborted;
                
            });

            if (result.Errors != null)
            {
                //这里可以执行一些日志记录操作
                Console.WriteLine($"GraphQL execution error(s): { result.Errors}");
            }
            //响应给客户端
            await WriteResponseAsync(context, writer, result);
        }
        #region 私有方法
        private static void ExtractGraphQLRequestFromPostBody(IFormCollection fc, GraphQLRequest gqlRequest)
        {
            gqlRequest.Query = fc.TryGetValue(GraphQLRequest.QueryKey, out var queryValues) ? queryValues[0] : null;
            gqlRequest.Variables = fc.TryGetValue(GraphQLRequest.VariablesKey, out var variablesValue) ? JObject.Parse(variablesValue[0]) : null;
            gqlRequest.OperationName = fc.TryGetValue(GraphQLRequest.OperationNameKey, out var operationNameValues) ? operationNameValues[0] : null;
        }
        private static async Task<string> ReadAsStringAsync(Stream s)
        {
            // Do not explicitly or implicitly (via using, etc.) call dispose because StreamReader will dispose inner stream.
            // This leads to the inability to use the stream further by other consumers/middlewares of the request processing
            // pipeline. In fact, it is absolutely not dangerous not to dispose StreamReader as it does not perform any useful
            // work except for the disposing inner stream.
            return await new StreamReader(s).ReadToEndAsync();
        }
        private static T Deserialize<T>(Stream s)
        {
            // Do not explicitly or implicitly (via using, etc.) call dispose because StreamReader will dispose inner stream.
            // This leads to the inability to use the stream further by other consumers/middlewares of the request processing
            // pipeline. In fact, it is absolutely not dangerous not to dispose StreamReader as it does not perform any useful
            // work except for the disposing inner stream.
            var reader = new StreamReader(s);
            using (var jsonReader = new JsonTextReader(reader) { CloseInput = false })
            {
                return new JsonSerializer().Deserialize<T>(jsonReader);
            }
        }
        private static void ExtractGraphQLRequestFromQueryString(IQueryCollection qs, GraphQLRequest gqlRequest)
        {
            gqlRequest.Query = qs.TryGetValue(GraphQLRequest.QueryKey, out var queryValues) ? queryValues[0] : null;
            gqlRequest.Variables = qs.TryGetValue(GraphQLRequest.VariablesKey, out var variablesValues) ? JObject.Parse(variablesValues[0]) : null;
            gqlRequest.OperationName = qs.TryGetValue(GraphQLRequest.OperationNameKey, out var operationNameValues) ? operationNameValues[0] : null;
        }

        private Task WriteBadRequestResponseAsync(HttpContext context, IDocumentWriter writer, string errorMessage)
        {
            var result = new ExecutionResult
            {
                Errors = new ExecutionErrors
                {
                    new ExecutionError(errorMessage)
                }
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 400; // Bad Request

            return writer.WriteAsync(context.Response.Body, result);
        }
        private Task WriteResponseAsync(HttpContext context, IDocumentWriter writer, ExecutionResult result)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 200; // OK
            return writer.WriteAsync(context.Response.Body, result);
        }
        #endregion

    }
    #region GraphQLRequest
    public class GraphQLRequest
    {
        public const string QueryKey = "query";
        public const string VariablesKey = "variables";
        public const string OperationNameKey = "operationName";

        [JsonProperty(QueryKey)]
        public string Query { get; set; }

        [JsonProperty(VariablesKey)]
        public JObject Variables { get; set; }

        [JsonProperty(OperationNameKey)]
        public string OperationName { get; set; }

        public Inputs GetInputs()
        {
            return GetInputs(Variables);
        }

        public static Inputs GetInputs(JObject variables)
        {
            return variables?.ToInputs();
        }
    }
#endregion

}
