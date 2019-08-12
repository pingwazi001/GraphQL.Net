using GraphQL.Net.Subscription.Model;
using GraphQL.Types;

namespace GraphQL.Net.Subscription.Schema.Type
{
    public class InputMessageType:InputObjectGraphType<Messages>
    {
        public InputMessageType()
        {
            Name = "inputMessageType";
            Description = "消息输入类型";
            Field(m => m.FromId).Description("消息发送者的编号");
            Field(m => m.FromName).Description("消息发送者的姓名");
            Field(m => m.ToId).Description("消息接收者的编号");
            Field(m => m.ToName).Description("消息接收着的姓名");
            Field(m => m.Content).Description("消息内容");
            Field(m => m.SendTime).Description("消息发送时间");
        }
    }
}
