using GraphQL_0_0.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace GraphQL_0_0.Service
{
    public class SysInfoService
    {
        //private static IList<SysInfo> sysInfos = new List<SysInfo>();
        //ReplaySubject可以将之前发布的所有消息都发送给订阅者
        private static readonly ISubject<SysInfo> _eventStream = new ReplaySubject<SysInfo>();
        /// <summary>
        /// 添加系统信息
        /// </summary>
        /// <param name="sysInfo"></param>
        public SysInfo AddSysInfo(SysInfo sysInfo)
        {
            //sysInfos.Add(sysInfo);
            _eventStream.OnNext(sysInfo);
            return sysInfo;
        }
        public IObservable<SysInfo> GetSysInfos()
        {
            return _eventStream.AsObservable();
        }
    }
}
