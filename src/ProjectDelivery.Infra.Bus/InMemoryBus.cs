using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Commands;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using System;

namespace ProjectDelivery.Infra.Bus
{
    public class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        public static IServiceProvider Container => ContainerAccessor();

        public void RaizeEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            var type = message.MessageType.Equals("DomainNotification") ?
                typeof(IDomainNotificationHandler<T>) :
                typeof(IHandler<T>);

            var obj = Container.GetService(type);
            ((IHandler<T>)obj).Handle(message);
        }
    }
}
