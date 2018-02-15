using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Infra.Identity.Interfaces;
using ProjectDelivery.Infra.Identity.Model;
using System;
using System.Threading.Tasks;

namespace ProjectDelivery.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class IngredienteOpcOpcoesController : BaseController
    {
        private readonly IIngredienteOpc_OpcaoService _ingredienteOpc_OpcaoService;
        private readonly IServiceProvider _provider;
        private readonly IUsuarioService _usuarioService;

        public IngredienteOpcOpcoesController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IIngredienteOpc_OpcaoService ingredienteOpc_OpcaoService, IServiceProvider provider, IUsuarioService usuarioService) : base(bus, notifications)
        {
            _ingredienteOpc_OpcaoService = ingredienteOpc_OpcaoService;
            _usuarioService = usuarioService;
            _provider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _usuarioService.Criar("gustavoglu@hotmail.com", "Giroldinhu20*");
            return Response(_ingredienteOpc_OpcaoService.TrazerTodosAtivos());
        }

        [HttpGet("/api/[controller]/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_ingredienteOpc_OpcaoService.TrazerPorId(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]IngredienteOpc_Opcao ingredienteOpc_Opcao)
        {
            if (ingredienteOpc_Opcao == null) return Response(null);
            _ingredienteOpc_OpcaoService.Criar(ingredienteOpc_Opcao);
            return Response(ingredienteOpc_Opcao);
        }

        [HttpPut]
        public IActionResult Put([FromBody]IngredienteOpc_Opcao ingredienteOpc_Opcao)
        {
            if (ingredienteOpc_Opcao == null) return Response(null);
            _ingredienteOpc_OpcaoService.Atualizar(ingredienteOpc_Opcao);
            return Response(ingredienteOpc_Opcao);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]IngredienteOpc_Opcao ingredienteOpc_Opcao)
        {
            if (ingredienteOpc_Opcao == null) return Response(null);
            _ingredienteOpc_OpcaoService.Deletar(ingredienteOpc_Opcao.Id);
            return Response(ingredienteOpc_Opcao);
        }
    }
}
