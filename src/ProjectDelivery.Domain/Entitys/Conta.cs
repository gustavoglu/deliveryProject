using ProjectDelivery.Domain.Core.Entitys;
using ProjectDelivery.Domain.ValueObjects;

namespace ProjectDelivery.Domain.Entitys
{
    public class Conta : Entity
    {
        public Conta(string responsavel, string documento, string nomeFantasia, Core_AppStyle_Conta style)
        {
            Responsavel = responsavel;
            Documento = documento;
            NomeFantasia = nomeFantasia;
            Style = style;
        }

        public string Responsavel { get; private set; }
        public string Documento { get; private set; }
        public string NomeFantasia { get; private set; }
        public Core_AppStyle_Conta Style { get; private set; }
    }
}
