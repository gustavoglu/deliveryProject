using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDelivery.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>, IDisposable
    {
        public List<DomainNotification> Notifications;

        public DomainNotificationHandler()
        {
            Notifications = new List<DomainNotification>();
        }

        public void Dispose()
        {
            Notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return Notifications;
        }

        public void Handle(DomainNotification message)
        {
            Notifications.Add(message);
        }

        public bool HasNotification()
        {
            return Notifications.Any();
        }
    }
}
