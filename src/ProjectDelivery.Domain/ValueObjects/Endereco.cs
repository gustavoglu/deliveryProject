using ProjectDelivery.Domain.Core.ValueObjects;

namespace ProjectDelivery.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string rua, string bairro, string cidade, string estado, string pais)
        {
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
    }
}
