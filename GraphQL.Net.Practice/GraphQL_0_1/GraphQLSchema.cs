using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_0_1
{
    public class GraphQLSchema:Schema
    {
        public GraphQLSchema()
        {
            Query = new RootQueries();
        }
    }
}
