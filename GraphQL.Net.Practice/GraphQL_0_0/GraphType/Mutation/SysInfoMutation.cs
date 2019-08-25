using GraphQL.Types;
using GraphQL_0_0.Entity;
using GraphQL_0_0.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_0_0.GraphType.Mutation
{
    public class SysInfoMutation:ObjectGraphType
    {
        public SysInfoMutation()
        {
            Name = "sysInfoMutation";
            Description = "sysInfo的修改操作";
            Field<SysInfoType>("addSysInfo", arguments: new QueryArguments(new QueryArgument<InputSysInfoType> { Name = "sysInfo" }),
                resolve: context =>
                {
                    SysInfo sysInfo = context.GetArgument<SysInfo>("sysInfo");
                    new SysInfoService().AddSysInfo(sysInfo);
                    return sysInfo;
                });
        }
    }
}
