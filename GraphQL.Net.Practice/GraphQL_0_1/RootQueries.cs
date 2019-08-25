using GraphQL.Types;
using GraphQL_0_1.Entity;
using GraphQL_0_1.GraphType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_0_1
{
    public class RootQueries:ObjectGraphType
    {
        public RootQueries()
        {
            Name = "rootQueries";
            Description = "查询根";
            Field<SysInfoType>("sysInfo", resolve: context => new SysInfo { SysId = 1, Name = "GraphQL_0_1" });
        }
    }
}
