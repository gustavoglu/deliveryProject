using ProjectDelivery.Domain.Commands.EntitysCommands.Tamanhos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class TamanhoCommandHandler : CommandHandler, IHandler<CriarTamanhoCommand>, IHandler<AtualizarTamanhoCommand>, IHandler<DeletarTamanhoCommand>
    {
        private readonly ITamanhoRepository _tamanhoRepository;
        public TamanhoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, ITamanhoRepository tamanhoRepository) : base(uow, bus, notifications)
        {
            _tamanhoRepository = tamanhoRepository;
        }

        public void Handle(CriarTamanhoCommand message)
        {
            if (!CommandValido(message)) return;
            _tamanhoRepository.Criar(new Entitys.Tamanho(message.Descricao));
            if (!Commit()) return;
        }

        public void Handle(AtualizarTamanhoCommand message)
        {
            if (!CommandValido(message)) return;
            _tamanhoRepository.Atualizar(TamanhoFactory.TamanhoFull(message.Id,message.Descricao));
            if (!Commit()) return;
        }

        public void Handle(DeletarTamanhoCommand message)
        {
            if (!CommandValido(message)) return;
            _tamanhoRepository.Deletar(message.Id);
            if (!Commit()) return;
        }
    }
}
