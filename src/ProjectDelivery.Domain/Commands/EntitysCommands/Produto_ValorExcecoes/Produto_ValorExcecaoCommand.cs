using ProjectDelivery.Domain.Core.Commands;
using System;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Produto_ValorExcecoes
{
    public abstract class Produto_ValorExcecaoCommand : Command
    {
        public Guid Id { get; set; }
        public Guid? Id_produto { get; set; }
        public Guid? Id_produtoTipo { get; set; }
        public Guid Id_periodo { get; set; }
        public decimal Valor { get; set; } = 0;
        public int Porcentagem { get; set; }
        public bool Promocao { get; set; } = false;
    }
}
