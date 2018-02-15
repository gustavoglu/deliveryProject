using FluentValidation.Results;
using ProjectDelivery.Domain.Core.Events;
using System;

namespace ProjectDelivery.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult Validations { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
