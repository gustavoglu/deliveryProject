using ProjectDelivery.Domain.Core.Commands;
using ProjectDelivery.Domain.Core.Events;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        List<T> GetNotifications();
        bool HasNotification();
    }
}
