using ProjectDelivery.Domain.Validations.PagamentoTipos;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.PagamentoTipo
{
    public class AtualizarPagamentoTipoCommand : PagamentoTipoCommand
    {
        public AtualizarPagamentoTipoCommand(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
        public override bool IsValid()
        {
            return new AtualizarPagamentoTipoValidation().Validate(this).IsValid;
        }
    }
}
