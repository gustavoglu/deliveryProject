using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.PagamentoTipo;

namespace ProjectDelivery.Domain.Validations.PagamentoTipos
{
    public class PagamentoTipoValidation<T> : AbstractValidator<T> where T : PagamentoTipoCommand
    {
    }
}
