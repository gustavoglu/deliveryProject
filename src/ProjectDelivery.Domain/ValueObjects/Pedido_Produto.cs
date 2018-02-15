using ProjectDelivery.Domain.Core.ValueObjects;
using ProjectDelivery.Domain.Entitys;
using System.Collections.Generic;

namespace ProjectDelivery.Domain.ValueObjects
{
    public class Pedido_Produto : ValueObject
    {
        private List<Pedido_Produto_IngredienteOpc_Opcao> _pedido_Produto_IngredienteOpc_Opcoes;
        private List<Adicional> _adicionais;

        public Pedido_Produto(Produto produto, Tamanho tamanho, decimal valor,
                               List<Adicional> adicionais,
                                List<Pedido_Produto_IngredienteOpc_Opcao> pedido_Produto_IngredienteOpc_Opcoes = null)
        {
            Produto = produto;
            Tamanho = tamanho;
            Valor = valor;
            _adicionais = adicionais ?? new List<Adicional>();
            _pedido_Produto_IngredienteOpc_Opcoes = pedido_Produto_IngredienteOpc_Opcoes ?? new List<Pedido_Produto_IngredienteOpc_Opcao>();
        }

        public Produto Produto { get; private set; }
        public Tamanho Tamanho { get; private set; }
        public decimal Valor { get; set; }

        public List<Pedido_Produto_IngredienteOpc_Opcao> Pedido_Produto_IngredienteOpc_Opcoes { get { return _pedido_Produto_IngredienteOpc_Opcoes ; } }
        public List<Adicional> Adicionais { get { return _adicionais; } }

        public void AdicionarAdicional(Adicional adicional)
        {
            _adicionais.Add(adicional);
        }

        public void Adicionaredido_Produto_IngredienteOpc_Opcao(Pedido_Produto_IngredienteOpc_Opcao pedido_Produto_IngredienteOpc_Opcao)
        {
            _pedido_Produto_IngredienteOpc_Opcoes.Add(pedido_Produto_IngredienteOpc_Opcao);
        }
    }
}
