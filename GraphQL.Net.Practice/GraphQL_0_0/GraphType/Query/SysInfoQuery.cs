using GraphQL.Types;
using GraphQL_0_0.Entity;

namespace GraphQL_0_0.GraphType.Query
{
    public class SysInfoQuery:ObjectGraphType
    {
        public SysInfoQuery()
        {
            Name = "sysInfoQuery";
            Description = "系统信息查询";
            Field<SysInfoType>("getSysInfo", resolve: context => new SysInfo { SysId = 0, SysName = "GraphQL_0_0", HostName = "localhost" });

        }
        
    }
}
