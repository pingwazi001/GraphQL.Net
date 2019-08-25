using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using GraphQL_0_0.Entity;
using GraphQL_0_0.GraphType;
using GraphQL_0_0.Service;
using System;

namespace GraphQL_0_0
{
    public class SysInfoSubScription:ObjectGraphType
    {
        public SysInfoSubScription()
        {
            Name = "sysInfoSubscription";
            Description = "sysInfo的Subscription";
            AddField(new EventStreamFieldType()
            {
                Name = "getSysInfos",
                Description = "消息的订阅者",
                Type = typeof(SysInfoType),
                Resolver = new FuncFieldResolver<SysInfo>(SendMessage),
                Subscriber = new EventStreamResolver<SysInfo>(FilterSubscriberMessage)
            });
        }
        /// <summary>
        /// 为消息订阅者过滤消息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private IObservable<SysInfo> FilterSubscriberMessage(ResolveEventStreamContext context)
        {
            return new SysInfoService().GetSysInfos();
        }
        /// <summary>
        /// 向消息订阅者发送消息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private SysInfo SendMessage(ResolveFieldContext context)
        {
            return context.Source as SysInfo;
        }
    }
}
