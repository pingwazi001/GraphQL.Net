using GraphQL.Types;
using GraphQL_0_0.GraphType.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_0_0
{
    public class RootQueries:ObjectGraphType
    {
        public RootQueries()
        {
            Name = "rootQueries";
            Description = "查询根";
            Field<SysInfoQuery>("sysInfoQueries", resolve: context => new { });
        }
    }
}
