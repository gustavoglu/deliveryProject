using ProjectDelivery.Domain.Core.Entitys;
using System;

namespace ProjectDelivery.Domain.Entitys
{
    public class Adicional : Entity
    {
        public Adicional(string descricao, decimal valorDiferenca, Guid? id_produto)
        {
            Descricao = descricao;
            ValorDiferenca = valorDiferenca;
            Id_Produto = id_produto;
        }

        public string Descricao { get; private set; }
        public decimal ValorDiferenca { get; private set; } = 0;
        public Guid? Id_Produto { get; private set; }
    }

    public static class AdicionalFactory
    {
        public static Adicional AdicionalFull(Guid id,string descricao, decimal valorDiferenca, Guid? id_produto)
        {
            return new Adicional(descricao, valorDiferenca, id_produto) { Id = id };
        }
    }
}
