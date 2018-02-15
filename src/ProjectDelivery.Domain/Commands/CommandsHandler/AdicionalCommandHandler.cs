using ProjectDelivery.Domain.Commands.EntitysCommands.Adicionais;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class AdicionalCommandHandler : CommandHandler, IHandler<CriarAdicionalCommand>, IHandler<AtualizarAdicionalCommand>, IHandler<DeletarAdicionalCommand>
    {
        private readonly IAdicionalRepository _adicionalRepository;
        public AdicionalCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IAdicionalRepository adicionalRepository) : base(uow, bus, notifications)
        {
            _adicionalRepository = adicionalRepository;
        }

        public void Handle(CriarAdicionalCommand message)
        {
            if (!this.CommandValido(message)) return;

            Adicional adicional = new Adicional(message.Descricao, message.ValorDiferenca, message.Id_Produto);
            _adicionalRepository.Criar(adicional);

            if (!Commit()) return;

        }

        public void Handle(DeletarAdicionalCommand message)
        {
            if (!this.CommandValido(message)) return;

            _adicionalRepository.Deletar(message.Id);

            if (!Commit()) return;
        }

        public void Handle(AtualizarAdicionalCommand message)
        {
            if (!this.CommandValido(message)) return;

            Adicional adicionalUpdate = AdicionalFactory.AdicionalFull(message.Id, message.Descricao, message.ValorDiferenca, message.Id_Produto);
            _adicionalRepository.Atualizar(adicionalUpdate);

            if (!Commit()) return;
        }
    }
}
