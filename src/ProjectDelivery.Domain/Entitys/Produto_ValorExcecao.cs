using System;
using ProjectDelivery.Domain.Core.Entitys;

namespace ProjectDelivery.Domain.Entitys
{
    public class Produto_ValorExcecao : Entity
    {

        public Produto_ValorExcecao(Guid? id_produto, Guid? id_produtoTipo = null, decimal valor = 0,
                                        Guid id_periodo = default(Guid), bool promocao = false, int porcentagem = 0)
        {
            Id_produto = id_produto;
            Id_produtoTipo = id_produtoTipo;
            Id_periodo = id_periodo;
            Valor = valor;
            Promocao = promocao;
            Porcentagem = porcentagem;
        }

        public Guid? Id_produto { get; private set; }
        public Guid? Id_produtoTipo { get; private set; }
        public Guid Id_periodo { get; private set; }
        public decimal Valor { get; private set; } = 0;
        public int Porcentagem { get; private set; }
        public bool Promocao { get; private set; } = false;
    }

    public static class Produto_ValorExcecaoFactory
    {
        public static Produto_ValorExcecao Produto_ValorExcecaoFull(Guid id, Guid? id_produto, Guid? id_produtoTipo = null, decimal valor = 0,
                                        Guid id_periodo = default(Guid), bool promocao = false, int porcentagem = 0)
        {
            return new Produto_ValorExcecao(id_produto, id_produtoTipo, valor, id_periodo, promocao, porcentagem) { Id = id };
        }
    }
}
