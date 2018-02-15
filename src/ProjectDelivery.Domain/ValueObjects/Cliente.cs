using ProjectDelivery.Domain.Core.ValueObjects;
using ProjectDelivery.Domain.ValueObjects;
using System;

namespace ProjectDelivery.Domain.ValueObjects
{
    public class Cliente : ValueObject
    {
        public Cliente()
        {

        }

        public Cliente(string nome, string email, string telefone1, string telefone2, DateTime? dataNascimento,Endereco endereco, string idCelular)
        {
            Nome = nome;
            Email = email;
            Telefone1 = telefone1;
            Telefone2 = telefone2;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            IdCelular = idCelular;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone1 { get; private set; }
        public string Telefone2 { get; private set; }
        public string IdCelular { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
