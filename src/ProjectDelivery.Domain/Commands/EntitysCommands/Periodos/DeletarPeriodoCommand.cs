using ProjectDelivery.Domain.Validations.Periodos;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Periodos
{
    public class DeletarPeriodoCommand : PeriodoCommand
    {
        public DeletarPeriodoCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            return new DeletarPeriodoValidation().Validate(this).IsValid;
        }
    }
}
