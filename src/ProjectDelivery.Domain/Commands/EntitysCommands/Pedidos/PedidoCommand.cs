using ProjectDelivery.Domain.Core.Commands;
using ProjectDelivery.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Pedidos
{
    public abstract class PedidoCommand : Command
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public string Status { get; set; }
        public bool Entregue { get; set; }
        public bool Cancelado { get; set; }
        public decimal Total { get; set; }
        public string ObservacoesAdiocionais { get; set; }
        public Guid Id_loja { get; set; }
        public Guid Id_pagamentoTipo { get; set; }
        public List<Pedido_Produto> Pedido_Produtos { get; set; }
        public Cliente Cliente { get; set; }
    }
}
