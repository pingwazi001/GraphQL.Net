using GraphQL.Net.Subscription.IService;
using GraphQL.Net.Subscription.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace GraphQL.Net.Subscription.Service
{
    public class MessageService : IMessageService
    {
        private readonly ISubject<Messages> messageStream = new ReplaySubject<Messages>();
        public void AddError(Exception ex)
        { 
            messageStream.OnError(ex);
        }

        public Messages AddMessage(Messages message)
        {
            messageStream.OnNext(message);
            return message;
        }

        public IObservable<Messages> GetMessages()
        {
            return messageStream.AsObservable();
        }
    }
}
