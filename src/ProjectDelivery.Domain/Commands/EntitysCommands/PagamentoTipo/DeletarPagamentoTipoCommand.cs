using System;
using ProjectDelivery.Domain.Validations.PagamentoTipos;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.PagamentoTipo
{
    public class DeletarPagamentoTipoCommand : PagamentoTipoCommand
    {
        public DeletarPagamentoTipoCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return new DeletarPagamentoTipoValidation().Validate(this).IsValid;
        }
    }
}
