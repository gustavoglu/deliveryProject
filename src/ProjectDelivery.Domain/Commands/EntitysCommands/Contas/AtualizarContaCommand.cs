using System;
using ProjectDelivery.Domain.Validations.Contas;

namespace ProjectDelivery.Domain.Commands.EntitysCommands.Contas
{
    public class AtualizarContaCommand : ContaCommand
    {
        public AtualizarContaCommand(Guid id,string responsavel, string documento, string nomeFantasia, string logoUri, string sobre, string informacoes, string ajuda, 
                                                string corInfos, string corBar, string corBarFonte, string corFundo, string corCerto, string corErrado, string corPromocao)
        {
            _id = id;
            Responsavel = responsavel;
            Documento = documento;
            NomeFantasia = nomeFantasia;
            LogoUri = logoUri;
            Sobre = sobre;
            Informacoes = informacoes;
            Ajuda = ajuda;
            CorInfos = corInfos;
            CorBar = corBar;
            CorBarFonte = corBarFonte;
            CorFundo = corFundo;
            CorCerto = corCerto;
            CorErrado = corErrado;
            CorPromocao = corPromocao;
        }

        public override bool IsValid()
        {
            return new AtualizarContaValidation().Validate(this).IsValid;
        }
    }
}
