using ProjectDelivery.Domain.Validations.Produtos;
using System;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Produtos
{
    public class CriarProdutoCommand : ProdutoCommand
    {
        public CriarProdutoCommand(string nome,string descricao, decimal valor, string imagemUri = null, bool sabor = false, Guid id_produtoTipo = default(Guid),
                        List<Guid> ids_tamanho = null, List<Guid> ids_produto_ValorExcecao = null)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            ImagemUri = imagemUri;
            Sabor = sabor;
            Ids_tamanhos = ids_tamanho ?? new List<Guid>();
            Ids_produto_valorExcecoes = ids_produto_ValorExcecao ?? new List<Guid>();
            Id_produtoTipo = id_produtoTipo;
        }
        public override bool IsValid()
        {
            return new CriarProdutoValidation().Validate(this).IsValid;
        }
    }
}
