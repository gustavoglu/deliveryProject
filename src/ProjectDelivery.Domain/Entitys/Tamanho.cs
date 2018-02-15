using ProjectDelivery.Domain.Core.Entitys;
using System;

namespace ProjectDelivery.Domain.Entitys
{
    public class Tamanho : Entity
    {
        public Tamanho(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; private set; }
    }

    public static class TamanhoFactory
    {
        public static Tamanho TamanhoFull(Guid id, string descricao)
        {
            return new Tamanho(descricao) { Id = id };
        }
    }
}
