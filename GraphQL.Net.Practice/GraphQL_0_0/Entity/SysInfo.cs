using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_0_0.Entity
{
    /// <summary>
    /// 系统信息
    /// </summary>
    public class SysInfo
    {
        /// <summary>
        /// 系统id
        /// </summary>
        public int SysId { get; set; }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SysName { get; set; }
        /// <summary>
        /// 主机名
        /// </summary>
        public string HostName { get; set; }
    }
}
