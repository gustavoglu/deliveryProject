using ProjectDelivery.Domain.Commands.EntitysCommands.Contas;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Domain.ValueObjects;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class ContaCommandHandler : CommandHandler, IHandler<NovaContaCommand>, IHandler<AtualizarContaCommand>, IHandler<DeletarContaCommand>
    {
        private readonly IContaRepository _contaRepository;

        public ContaCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IContaRepository contaRepository) : base(uow, bus, notifications)
        {
            _contaRepository = contaRepository;
        }

        public void Handle(NovaContaCommand message)
        {
            if (!CommandValido(message)) return;
            Conta conta = new Conta(message.Responsavel, message.Documento, message.NomeFantasia,
                new Core_AppStyle_Conta(message.LogoUri, message.Sobre, message.Informacoes, message.Ajuda));
            _contaRepository.Criar(conta);
            if(!Commit()) return;
        }

        public void Handle(AtualizarContaCommand message)
        {
            if (!CommandValido(message)) return;
            Conta conta = new Conta(message.Responsavel, message.Documento, message.NomeFantasia, 
                new Core_AppStyle_Conta(message.LogoUri,message.Sobre,message.Informacoes,message.Ajuda));

            _contaRepository.Atualizar(conta);
            if (!Commit()) return;
        }

        public void Handle(DeletarContaCommand message)
        {
            if (!CommandValido(message)) return;
            _contaRepository.Deletar(message._id);
            if (!Commit()) return;
        }
    }
}
