using ProjectDelivery.Domain.Core.Notifications;
using System.Linq;

namespace ProjectDelivery.Services.Api.ViewModels
{
    public class Response
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public Response(bool sucess = true, object data = null, IDomainNotificationHandler<DomainNotification> notifications = null)
        {
            _notifications = notifications;
            Data = sucess ? data : NotificationsFormated();
            Sucess = sucess;
        }

        public Response(bool sucess = true, object data = null)
        {
            Sucess = sucess;
            Data = data;
        }

        private object NotificationsFormated()
        {
            return _notifications.GetNotifications().Select(n => $"{n.Key} : {n.Value}");
        }

        public bool Sucess { get; private set; } = true;
        public object Data { get; private set; } = null;
    }
}
