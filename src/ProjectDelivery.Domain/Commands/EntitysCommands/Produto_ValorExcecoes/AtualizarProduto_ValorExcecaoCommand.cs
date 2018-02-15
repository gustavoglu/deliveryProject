using ProjectDelivery.Domain.Validations.Produto_ValorExcecoes;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Produto_ValorExcecoes
{
    public class AtualizarProduto_ValorExcecaoCommand : Produto_ValorExcecaoCommand
    {
        public AtualizarProduto_ValorExcecaoCommand(Guid id,Guid? id_produto, Guid? id_produtoTipo = null, decimal valor = 0, Guid id_periodo = default(Guid), bool promocao = false, int porcentagem = 0)
        {
            Id = id;
            Id_produto = id_produto;
            Id_produtoTipo = id_produtoTipo;
            Id_periodo = id_periodo;
            Valor = valor;
            Promocao = promocao;
            Porcentagem = porcentagem;
        }
        public override bool IsValid()
        {
            return new AtualizarProduto_ValorExcecaoValidation().Validate(this).IsValid;
        }
    }
}
