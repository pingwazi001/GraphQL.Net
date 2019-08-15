using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.AspNetCore.GraphQLType.EntityType;
using GraphQL.AspNetCore.GraphQLType.QueryType;
using GraphQL.Http;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace GraphQL.AspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //依赖注入
            services.AddScoped<PersonsType>();
            services.AddScoped<PersonsQuery>();
            services.AddScoped<GraphQLQuery>();
            services.AddScoped<GraphQLMutation>();
            services.AddScoped<GraphQLSubscription>();
            services.AddScoped<GraphQLSchema>();
            services.TryAddSingleton<IDocumentWriter>(x =>
            {
                var jsonSerializerSettings = x.GetRequiredService<IOptions<JsonSerializerSettings>>();
                return new DocumentWriter(Formatting.None, jsonSerializerSettings.Value);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //访问/graphql
            app.UseMiddleware<GraphQLHttpMiddleware>();
            // use graphql-playground middleware at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground",
                GraphQLEndPoint="/graphql"
            });
        }
    }
}
