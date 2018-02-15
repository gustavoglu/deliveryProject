using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.ProdutoTipos;

namespace ProjectDelivery.Domain.Validations.ProdutoTipos
{
    public class ProdutoTipoValidation<T> : AbstractValidator<T> where T : ProdutoTipoCommand
    {
    }
}
