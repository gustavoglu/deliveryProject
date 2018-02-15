using System;
using Microsoft.AspNetCore.Mvc;
using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Entitys;

namespace ProjectDelivery.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class IngredienteOpcsController : BaseController
    {
        private readonly IIngredienteOpcService _ingredienteOpcService;

        public IngredienteOpcsController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IIngredienteOpcService ingredienteOpcService) : base(bus, notifications)
        {
            _ingredienteOpcService = ingredienteOpcService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_ingredienteOpcService.TrazerTodosAtivos());
        }

        [HttpPost]
        public IActionResult Post([FromBody] IngredienteOpc ingredienteOpc)
        {
            if (ingredienteOpc == null) return Response(null);
            _ingredienteOpcService.Criar(ingredienteOpc);
            return Response(ingredienteOpc);
        }

        [HttpGet("/api/[controller]/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_ingredienteOpcService.TrazerPorId(id));
        }

        [HttpPut]
        public IActionResult Put([FromBody]IngredienteOpc ingredienteOpc)
        {
            if (ingredienteOpc == null) return Response(null);
            _ingredienteOpcService.Atualizar(ingredienteOpc);
            return Response(ingredienteOpc);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] IngredienteOpc ingredienteOpc)
        {
            if (ingredienteOpc == null) return Response(null);
            _ingredienteOpcService.Deletar(ingredienteOpc.Id);
            return Response(ingredienteOpc);
        }
    }
}
