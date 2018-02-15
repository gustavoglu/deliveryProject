using ProjectDelivery.Domain.Core.Entitys;
using System;

namespace ProjectDelivery.Domain.Entitys
{
    public class PagamentoTipo : Entity
    {
        public PagamentoTipo(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; private set; }
    }

    public static class PagamentoTipoFactory
    {
        public static PagamentoTipo PagamentoTipoFull(Guid id, string descricao)
        {
            return new PagamentoTipo(descricao) { Id = id };
        }
    }
}
