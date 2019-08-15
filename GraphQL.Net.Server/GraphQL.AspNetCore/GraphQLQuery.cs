using GraphQL.AspNetCore.GraphQLType.QueryType;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.AspNetCore
{
    public class GraphQLQuery:ObjectGraphType
    {
        public GraphQLQuery()
        {
            Name = "graphqlQuery";
            Description = "顶层查询";
            Field<PersonsQuery>("persons", resolve: context => new { });
        }
    }
}
