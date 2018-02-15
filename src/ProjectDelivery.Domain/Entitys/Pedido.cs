using System;
using ProjectDelivery.Domain.Core.Entitys;
using System.Collections.Generic;
using ProjectDelivery.Domain.ValueObjects;

namespace ProjectDelivery.Domain.Entitys
{
    public class Pedido : Entity
    {
        private List<Pedido_Produto> _pedido_produtos;

        public Pedido(string status, bool entregue, bool cancelado, decimal total, Guid id_loja, Guid id_pagamentoTipo, Cliente cliente, List<Pedido_Produto> pedidoProdutos)
        {
            Status = status;
            Entregue = entregue;
            Cancelado = cancelado;
            Total = total;
            Id_loja = id_loja;
            Id_pagamentoTipo = id_pagamentoTipo;
            Cliente = cliente;
            _pedido_produtos = pedidoProdutos ?? new List<Pedido_Produto>();

        }

        public int Numero { get; private set; }
        public string Status { get; private set; }
        public bool Entregue { get; private set; }
        public bool Cancelado { get; private set; }
        public decimal Total { get; private set; }
        public string ObservacoesAdiocionais { get; private set; }
        public Guid Id_loja { get; private set; }
        public Guid Id_pagamentoTipo { get; private set; }
        public List<Pedido_Produto> Pedido_Produtos { get { return _pedido_produtos; } }
        public Cliente Cliente { get; private set; }

        public void AtribuirNumero(int numero)
        {
            Numero = numero;
        }

        public void AdicionarProduto(Pedido_Produto pedido_Produto)
        {
            _pedido_produtos.Add(pedido_Produto);
        }
    }

    public static class Pedido_ProdutoFactory
    {
        public static Pedido PedidoFull(Guid id, string status, bool entregue, bool cancelado, decimal total, Guid id_loja, Guid id_pagamentoTipo, Cliente cliente, List<Pedido_Produto> pedidoProdutos)
        {
            return new Pedido(status, entregue, cancelado, total, id_loja, id_pagamentoTipo, cliente, pedidoProdutos) { Id = id };
        }
    }
}
