using System;
using ProjectDelivery.Domain.Core.Commands;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Produtos
{
    public abstract class ProdutoCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public decimal Valor { get;  set; }
        public string ImagemUri { get;  set; } = null;
        public bool Sabor { get;  set; } = false;
        public Guid Id_produtoTipo { get;  set; }
        public List<Guid> Ids_tamanhos { get; set; }
        public List<Guid> Ids_produto_valorExcecoes { get; set; }
    }
}
