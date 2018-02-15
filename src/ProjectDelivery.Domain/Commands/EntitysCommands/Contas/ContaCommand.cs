using System;
using ProjectDelivery.Domain.Core.Commands;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Contas
{
    public abstract class ContaCommand : Command
    {
        public Guid _id { get; set; }
        public string Responsavel { get; set; }
        public string Documento { get; set; }
        public string NomeFantasia { get; set; }
        public string LogoUri { get; set; }
        public string Sobre { get; set; }
        public string Informacoes { get; set; }
        public string Ajuda { get; set; }
        public string CorInfos { get; set; }
        public string CorBar { get; set; }
        public string CorBarFonte { get; set; }
        public string CorFundo { get; set; }
        public string CorCerto { get; set; }
        public string CorErrado { get; set; }
        public string CorPromocao { get; set; }
    }
}
