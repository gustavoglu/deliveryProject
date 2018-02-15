using System;
using Microsoft.AspNetCore.Mvc;
using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Entitys;

namespace ProjectDelivery.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PedidosController : BaseController
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IPedidoService pedidoService) : base(bus, notifications)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_pedidoService.TrazerTodosAtivos());
        }

        [HttpGet("/api/[controller]/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_pedidoService.TrazerPorId(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Pedido pedido)
        {
            if (pedido == null) return Response(null);
            _pedidoService.Criar(pedido);
            return Response(pedido);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Pedido pedido)
        {
            if (pedido == null) return Response(null);
            _pedidoService.Atualizar(pedido);
            return Response(pedido);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] Pedido pedido)
        {
            if (pedido == null) return Response(null);
            _pedidoService.Deletar(pedido.Id);
            return Response(pedido);
        }
    }
}
