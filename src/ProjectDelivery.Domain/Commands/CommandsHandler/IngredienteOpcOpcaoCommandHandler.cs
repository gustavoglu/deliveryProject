using ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcOpcoes;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;

namespace ProjectDelivery.Domain.Commands.CommandsHandler
{
    public class IngredienteOpcOpcaoCommandHandler : CommandHandler, IHandler<CriarIngredienteOpcOpcaoCommand>, IHandler<AtualizarIngredienteOpcOpcaoCommand>, IHandler<DeletarIngredienteOpcOpcaoCommand>
    {
        private readonly IIngredienteOpc_OpcaoRepository _ingredienteOpc_OpcaoRepository;
        public IngredienteOpcOpcaoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IIngredienteOpc_OpcaoRepository ingredienteOpc_OpcaoRepository) : base(uow, bus, notifications)
        {
            _ingredienteOpc_OpcaoRepository = ingredienteOpc_OpcaoRepository;
        }

        public void Handle(CriarIngredienteOpcOpcaoCommand message)
        {
            if (!CommandValido(message)) return;
            IngredienteOpc_Opcao IngredienteOpc_Opcao = new IngredienteOpc_Opcao(message.Descricao, message.ValorDiferenca, message.Id_produto);
            _ingredienteOpc_OpcaoRepository.Criar(IngredienteOpc_Opcao);
            if (!Commit()) return;
        }

        public void Handle(DeletarIngredienteOpcOpcaoCommand message)
        {
            if (!CommandValido(message)) return;
            _ingredienteOpc_OpcaoRepository.Deletar(message.Id);
            if (!Commit()) return;
        }

        public void Handle(AtualizarIngredienteOpcOpcaoCommand message)
        {
            if (!CommandValido(message)) return;
            IngredienteOpc_Opcao IngredienteOpc_Opcao = IngredienteOpc_OpcaoFactory.IngredienteOpc_OpcaoFull(message.Id, message.Descricao, message.ValorDiferenca, message.Id_produto);
            _ingredienteOpc_OpcaoRepository.Atualizar(IngredienteOpc_Opcao);
            if (!Commit()) return;
        }
    }
}
