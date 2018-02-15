using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.Produtos;

namespace ProjectDelivery.Domain.Validations.Produtos
{
    public abstract class ProdutoValidation<T> : AbstractValidator<T> where T : ProdutoCommand
    {
    }
}
