using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_0_0
{
    public class GraphQLSchema:Schema
    {
        public GraphQLSchema()
        {
            Query = new RootQueries();
            Mutation = new RootMutations();
            Subscription = new SysInfoSubScription();
        }
    }
}
