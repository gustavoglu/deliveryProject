using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.PagamentoTipo;

namespace ProjectDelivery.Domain.Validations.PagamentoTipos
{
    public class AtualizarPagamentoTipoValidation : AbstractValidator<AtualizarPagamentoTipoCommand>
    {
        public AtualizarPagamentoTipoValidation()
        {

        }
    }
}
