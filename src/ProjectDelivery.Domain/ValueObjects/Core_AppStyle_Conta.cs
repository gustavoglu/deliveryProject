using ProjectDelivery.Domain.Core.ValueObjects;

namespace ProjectDelivery.Domain.ValueObjects
{
    public class Core_AppStyle_Conta : ValueObject
    {
        
        public Core_AppStyle_Conta(string logoUri, string sobre, string informacoes, string ajuda)
        {
            LogoUri = logoUri;
            Sobre = sobre;
            Informacoes = informacoes;
            Ajuda = ajuda;
        }

        public string LogoUri { get; private set; }
        public string Sobre{ get; private set; }
        public string Informacoes { get; private set; }
        public string Ajuda { get; private set; }

        public string CorInfos { get; private set; }
        public string CorBar { get; private set; }
        public string CorBarFonte { get; private set; }
        public string CorFundo { get; private set; }
        public string CorCerto { get; private set; }
        public string CorErrado { get; private set; }
        public string CorPromocao { get; private set; }
    }
}
