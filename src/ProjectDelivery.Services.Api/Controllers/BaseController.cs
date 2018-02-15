using Microsoft.AspNetCore.Mvc;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Services.Api.ViewModels;

namespace ProjectDelivery.Services.Api.Controllers
{
    [Produces("application/json")]
    public class BaseController : Controller
    {
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public BaseController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _bus = bus;
            _notifications = notifications;
        }

        protected new IActionResult Response(object obj)
        {
            bool success = (!HasNotification() && ModelState.IsValid);
            Response response = new Response(success, obj, _notifications);

            if (response.Sucess) return Ok(response);

            return BadRequest(response);
        }

        protected bool HasNotification()
        {
            return _notifications.HasNotification();
        }

        protected void NotificaErro(string key, string value)
        {
            _bus.RaizeEvent(new DomainNotification(key, value));
        }
    }
}