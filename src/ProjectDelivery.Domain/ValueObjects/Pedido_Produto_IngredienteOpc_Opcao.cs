using ProjectDelivery.Domain.Core.ValueObjects;
using ProjectDelivery.Domain.Entitys;

namespace ProjectDelivery.Domain.ValueObjects
{
    public class Pedido_Produto_IngredienteOpc_Opcao : ValueObject
    {
        public Pedido_Produto_IngredienteOpc_Opcao(IngredienteOpc ingredienteOpc, IngredienteOpc_Opcao opcao, decimal valorDiferenca)
        {
            IngredienteOpc = ingredienteOpc;
            Opcao = opcao;
        }

        public IngredienteOpc IngredienteOpc { get; private set; }
        public IngredienteOpc_Opcao Opcao { get; private set; }
        public decimal ValorDiferenca { get; private set; } = 0;
    }
}
