using GraphQL.Net.Subscription.Model;
using System;

namespace GraphQL.Net.Subscription.IService
{
    public interface IMessageService
    {
        void AddError(Exception ex);
        Messages AddMessage(Messages message);
        IObservable<Messages> GetMessages();
    }
}
