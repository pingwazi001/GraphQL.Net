using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Net.Subscription.Model
{
    /// <summary>
    /// 老师
    /// </summary>
    public class Teachers
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id{ get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 科目
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 学生编号
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// 学生
        /// </summary>
        public IList<Students> Students { get; set; }
    }
}
