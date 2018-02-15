using ProjectDelivery.Domain.Core.Commands;
using ProjectDelivery.Domain.Core.Events;

namespace ProjectDelivery.Domain.Core.Bus
{
    public interface IBus
    {
        void RaizeEvent<T>(T theEvent) where T : Event;
        void SendCommand<T>(T theCommand) where T : Command;
    }
}
