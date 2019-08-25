using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.Types;
using System;

namespace GraphQL_23_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Schema schema = new Schema { Query = new RootQueries() };
            string resultJson = schema.Execute(_ =>
              {
                  _.Query = "{queryPerson{id name age}}";
                  _.FieldMiddleware.Use(next =>
                  {
                      return context =>{
                          return new MyMiddleWare().Invock(context, next);
                      };

                  });
            });
            Console.WriteLine(resultJson);
            Console.ReadKey();
            */
            Schema schema = new Schema { Query = new RootQueries() };
            var start = DateTime.UtcNow;
            var executor = new DocumentExecuter();
            ExecutionResult result = executor.ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = "query{queryPerson{id name age}}";
                _.EnableMetrics = true;
                _.FieldMiddleware.Use<MyMiddleWare>();
            }).Result;
            result.EnrichWithApolloTracing(start);
            string serialStr = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            Console.WriteLine(serialStr);
            Console.ReadKey();
        }
    }
}
