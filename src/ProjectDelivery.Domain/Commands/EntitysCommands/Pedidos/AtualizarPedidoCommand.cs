using ProjectDelivery.Domain.Validations.Pedidos;
using ProjectDelivery.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Pedidos
{
    public class AtualizarPedidoCommand : PedidoCommand
    {
        public AtualizarPedidoCommand(Guid id,string status, bool entregue, bool cancelado, decimal total, Guid id_loja, Guid id_pagamentoTipo, Cliente cliente, List<Pedido_Produto> pedidoProdutos)
        {
            Id = id;
            Status = status;
            Entregue = entregue;
            Cancelado = cancelado;
            Total = total;
            Id_loja = id_loja;
            Id_pagamentoTipo = id_pagamentoTipo;
            Cliente = cliente;
            pedidoProdutos = pedidoProdutos ?? new List<Pedido_Produto>();
        }

        public override bool IsValid()
        {
            return new AtualizarPedidoValidation().Validate(this).IsValid;
        }
    }
}
