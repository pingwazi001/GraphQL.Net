using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.AspNetCore
{
    public class GraphQLSchema:Schema
    {
        public GraphQLSchema()
        {
            Query = new GraphQLQuery();
        }
    }
}
