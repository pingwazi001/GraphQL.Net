using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_3_1
{
    /// <summary>
    /// 人
    /// </summary>
    public class Persons
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set;}
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Addr { get; set; }
    }
}
