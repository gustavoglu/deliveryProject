using FluentValidation;
using ProjectDelivery.Domain.Commands.EntitysCommands.Produto_ValorExcecoes;

namespace ProjectDelivery.Domain.Validations.Produto_ValorExcecoes
{
    public class Produto_ValorExcecaoValidation<T> : AbstractValidator<T> where T : Produto_ValorExcecaoCommand
    {
    }
}
