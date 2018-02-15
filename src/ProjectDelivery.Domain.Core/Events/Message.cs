using System;

namespace ProjectDelivery.Domain.Core.Events
{
    public abstract class Message
    {
        public string MessageType { get; set; }
        public Guid IdAggregate { get; set; }

        public Message()
        {
            MessageType = this.GetType().Name;
        }
    }
}
