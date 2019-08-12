using System.Collections.Generic;

namespace GraphQL.Net.Subscription.Model
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Students
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } 
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string Professional { get; set; }
        /// <summary>
        /// 老师编号
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// 老师
        /// </summary>
        public IList<Teachers>Teachers{get;set;}
    }
}
