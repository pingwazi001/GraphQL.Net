using GraphQL.Types;
using GraphQL_0_0.GraphType.Mutation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_0_0
{
    public class RootMutations:ObjectGraphType
    {
        public RootMutations()
        {
            Name = "rootMutations";
            Description = "修改根";
            Field<SysInfoMutation>("sysInfoMutation", resolve: context => new { });
        }
    }
}
