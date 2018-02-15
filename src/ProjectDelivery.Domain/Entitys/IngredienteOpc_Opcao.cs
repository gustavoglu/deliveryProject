using System;
using ProjectDelivery.Domain.Core.Entitys;

namespace ProjectDelivery.Domain.Entitys
{
    public class IngredienteOpc_Opcao : Entity
    {
        public IngredienteOpc_Opcao(string descricao, decimal valorDiferenca, Guid? id_produto)
        {
            Descricao = descricao;
            ValorDiferenca = valorDiferenca;
            Id_produto = id_produto;
        }

        public string Descricao { get; private set; }
        public decimal ValorDiferenca { get; private set; } = 0;
        public Guid? Id_produto { get; private set; }
    }

    public static class IngredienteOpc_OpcaoFactory
    {
        public static IngredienteOpc_Opcao IngredienteOpc_OpcaoFull(Guid id,string descricao, decimal valorDiferenca, Guid? id_produto)
        {
            return new IngredienteOpc_Opcao(descricao, valorDiferenca, id_produto) { Id = id };
        }
    }
}
