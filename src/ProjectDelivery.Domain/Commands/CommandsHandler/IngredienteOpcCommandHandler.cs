using ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcs;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class IngredienteOpcCommandHandler : CommandHandler, IHandler<CriarIngredienteOpcCommand>, IHandler<AtualizarIngredienteOpcCommand>, IHandler<DeletarIngredienteOpcCommand>
    {
        private readonly IIngredienteOpcRepository _ingredienteOpcRepository;

        public IngredienteOpcCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IIngredienteOpcRepository ingredienteOpcRepository) : base(uow, bus, notifications)
        {
            _ingredienteOpcRepository = ingredienteOpcRepository;
        }

        public void Handle(CriarIngredienteOpcCommand message)
        {
            if (!CommandValido(message)) return;
            IngredienteOpc ingredienteOpc = new IngredienteOpc(message.Descricao, message.Id_produtoTipo, message.Ids_ingredienteOpc_Opcoes);
            _ingredienteOpcRepository.Criar(ingredienteOpc);
            if (!Commit()) return;
        }

        public void Handle(AtualizarIngredienteOpcCommand message)
        {
            if (!CommandValido(message)) return;
            IngredienteOpc ingredienteOpc = IngredienteOpcFactory.IngredienteOpcFull(message.Id,message.Descricao, message.Id_produtoTipo, message.Ids_ingredienteOpc_Opcoes);
            _ingredienteOpcRepository.Atualizar(ingredienteOpc);
            if (!Commit()) return;
        }

        public void Handle(DeletarIngredienteOpcCommand message)
        {
            if (!CommandValido(message)) return;
            _ingredienteOpcRepository.Deletar(message.Id);
            if (!Commit()) return;
        }
    }
}
