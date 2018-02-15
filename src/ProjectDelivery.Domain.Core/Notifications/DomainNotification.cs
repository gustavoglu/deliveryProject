using ProjectDelivery.Domain.Core.Events;
using System;

namespace ProjectDelivery.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int Version { get; set; }
        public Guid Id { get; set; }

        public DomainNotification(string key, string value)
        {
            Id = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
