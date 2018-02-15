using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Application.Services;
using ProjectDelivery.Domain.Commands.CommandsHandler;
using ProjectDelivery.Domain.Commands.EntitysCommands.Adicionais;
using ProjectDelivery.Domain.Commands.EntitysCommands.Contas;
using ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcOpcoes;
using ProjectDelivery.Domain.Commands.EntitysCommands.IngredienteOpcs;
using ProjectDelivery.Domain.Commands.EntitysCommands.PagamentoTipo;
using ProjectDelivery.Domain.Commands.EntitysCommands.Pedidos;
using ProjectDelivery.Domain.Commands.EntitysCommands.Periodos;
using ProjectDelivery.Domain.Commands.EntitysCommands.Produto_ValorExcecoes;
using ProjectDelivery.Domain.Commands.EntitysCommands.Produtos;
using ProjectDelivery.Domain.Commands.EntitysCommands.ProdutoTipos;
using ProjectDelivery.Domain.Commands.EntitysCommands.Tamanhos;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Events;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Core.UoW;
using ProjectDelivery.Domain.Interfaces;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Infra.Bus;
using ProjectDelivery.Infra.Data.Context;
using ProjectDelivery.Infra.Data.Interfaces;
using ProjectDelivery.Infra.Data.Repository;
using ProjectDelivery.Infra.Data.UoW;
using ProjectDelivery.Infra.Identity.Interfaces;
using ProjectDelivery.Infra.Identity.Model;
using ProjectDelivery.Infra.Identity.Services;
using ProjectDelivery.Infra.Identity.User;

namespace ProjectDelivery.Infra.IoC
{
    public static class NativeInjection
    {
        public static void RegisterDependencys(IServiceCollection service)
        {
            //Bus
            service.AddScoped<IBus, InMemoryBus>();

            //Domain
            service.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Data
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IMongoDbContext, ProjectDeliveryContext>();

            //Identity
            service.AddScoped<IUsuarioService,UsuarioService>();
            //service.AddScoped<UserManager<Usuario>>();
            //service.AddScoped<SignInManager<Usuario>>();
            service.AddScoped<IUser, UserAspNet>();

            //Repository
            service.AddScoped<IAdicionalRepository, AdicionalRepository>();
            service.AddScoped<IContaRepository, ContaRepository>();
            service.AddScoped<IIngredienteOpc_OpcaoRepository, IngredienteOpc_OpcaoRepository>();
            service.AddScoped<IIngredienteOpcRepository, IngredienteOpcRepository>();
            service.AddScoped<IPagamentoTipoRepository, PagamentoTipoRepository>();
            service.AddScoped<IPedidoRepository, PedidoRepository>();
            service.AddScoped<IProduto_ValorExcecaoRepository, Produto_ValorExcecaoRepository>();
            service.AddScoped<IProdutoRepository, ProdutoRepository>();
            service.AddScoped<IProdutoTipoRepository, ProdutoTipoRepository>();
            service.AddScoped<ITamanhoRepository, TamanhoRepository>();

            //Commands
            //Produto
            service.AddScoped<IHandler<CriarProdutoCommand>, ProdutoCommandHandler>();
            service.AddScoped<IHandler<AtualizarProdutoCommand>, ProdutoCommandHandler>();
            service.AddScoped<IHandler<DeletarProdutoCommand>, ProdutoCommandHandler>();

            //Conta
            service.AddScoped<IHandler<NovaContaCommand>, ContaCommandHandler>();
            service.AddScoped<IHandler<AtualizarContaCommand>, ContaCommandHandler>();
            service.AddScoped<IHandler<DeletarContaCommand>, ContaCommandHandler>();

            //Adicional
            service.AddScoped<IHandler<CriarAdicionalCommand>, AdicionalCommandHandler>();
            service.AddScoped<IHandler<AtualizarAdicionalCommand>, AdicionalCommandHandler>();
            service.AddScoped<IHandler<DeletarAdicionalCommand>, AdicionalCommandHandler>();

            //Tamanho
            service.AddScoped<IHandler<CriarTamanhoCommand>, TamanhoCommandHandler>();
            service.AddScoped<IHandler<AtualizarTamanhoCommand>, TamanhoCommandHandler>();
            service.AddScoped<IHandler<DeletarTamanhoCommand>, TamanhoCommandHandler>();

            //IngredienteOpc
            service.AddScoped<IHandler<CriarIngredienteOpcCommand>, IngredienteOpcCommandHandler>();
            service.AddScoped<IHandler<AtualizarIngredienteOpcCommand>, IngredienteOpcCommandHandler>();
            service.AddScoped<IHandler<DeletarIngredienteOpcCommand>, IngredienteOpcCommandHandler>();

            //IngredienteOpcOpcao
            service.AddScoped<IHandler<CriarIngredienteOpcOpcaoCommand>, IngredienteOpcOpcaoCommandHandler>();
            service.AddScoped<IHandler<AtualizarIngredienteOpcOpcaoCommand>, IngredienteOpcOpcaoCommandHandler>();
            service.AddScoped<IHandler<DeletarIngredienteOpcOpcaoCommand>, IngredienteOpcOpcaoCommandHandler>();

            //ProdutoTipo
            service.AddScoped<IHandler<CriarProdutoTipoCommand>, ProdutoTipoCommandHandler>();
            service.AddScoped<IHandler<AtualizarProdutoTipoCommand>, ProdutoTipoCommandHandler>();
            service.AddScoped<IHandler<DeletarProdutoTipoCommand>, ProdutoTipoCommandHandler>();

            //PagamentoTipo
            service.AddScoped<IHandler<CriarPagamentoTipoCommand>, PagamentoTipoCommandHandler>();
            service.AddScoped<IHandler<AtualizarPagamentoTipoCommand>, PagamentoTipoCommandHandler>();
            service.AddScoped<IHandler<DeletarPagamentoTipoCommand>, PagamentoTipoCommandHandler>();

            //Pedido
            service.AddScoped<IHandler<CriarPedidoCommand>, PedidoCommandHandler>();
            service.AddScoped<IHandler<AtualizarPedidoCommand>, PedidoCommandHandler>();
            service.AddScoped<IHandler<DeletarPedidoCommand>, PedidoCommandHandler>();

            //Pedido
            service.AddScoped<IHandler<CriarPeriodoCommand>, PeriodoCommandHandler>();
            service.AddScoped<IHandler<AtualizarPeriodoCommand>, PeriodoCommandHandler>();
            service.AddScoped<IHandler<DeletarPeriodoCommand>, PeriodoCommandHandler>();

            //Produto_ValorExcecao
            service.AddScoped<IHandler<CriarProduto_ValorExcecaoCommand>, Produto_ValorExcecaoCommandHandler>();
            service.AddScoped<IHandler<AtualizarProduto_ValorExcecaoCommand>, Produto_ValorExcecaoCommandHandler>();
            service.AddScoped<IHandler<DeletarProduto_ValorExcecaoCommand>, Produto_ValorExcecaoCommandHandler>();


            //Services
            service.AddScoped<ITamanhoService, TamanhoService>();
            service.AddScoped<IAdicionalService, AdicionalService>();
            service.AddScoped<IProdutoTipoService, ProdutoTipoService>();
            service.AddScoped<IPagamentoTipoService, PagamentoTipoService>();
            service.AddScoped<IIngredienteOpcService, IngredienteOpcService>();
            service.AddScoped<IIngredienteOpc_OpcaoService, IngredienteOpc_OpcaoService>();
            service.AddScoped<IPedidoService, PedidoService>();
            service.AddScoped<IProdutoService, ProdutoService>();
            service.AddScoped<IProduto_ValorExcecaoService, Produto_ValorExcecaoService>();
            service.AddScoped<IPeriodoService, PeriodoService>();

        }
    }
}
