using GraphQL.Types;
using GraphQL_0_1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_0_1.GraphType
{
    public class SysInfoType:ObjectGraphType<SysInfo>
    {
        public SysInfoType()
        {
            Name = "sysInfoType";
            Description = "sysInfo的graphtype类型";
            Field(s => s.SysId).Description("系统id");
            Field(s => s.Name).Description("系统名称");
        }
    }
}
