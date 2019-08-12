using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Net.Subscription.Model
{
    /// <summary>
    /// 消息
    /// </summary>
    public class Messages
    {
        /// <summary>
        /// 消息发送者id
        /// </summary>
        public int FromId { get; set; }
        /// <summary>
        /// 消息发送者姓名
        /// </summary>
        public string FromName { get; set; }
        /// <summary>
        /// 消息接收者id
        /// </summary>
        public int ToId  { get; set; }
        /// <summary>
        /// 消息接收者姓名
        /// </summary>
        public string ToName { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息发送时间
        /// </summary>
        public string SendTime { get; set; }
    }
}
