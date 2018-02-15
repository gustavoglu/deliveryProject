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
    public class PagamentoTiposController : BaseController
    {
        private readonly IPagamentoTipoService _pagamentoTipoService;

        public PagamentoTiposController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IPagamentoTipoService pagamentoTipoService) : base(bus, notifications)
        {
            _pagamentoTipoService = pagamentoTipoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_pagamentoTipoService.TrazerTodosAtivos());
        }

        [HttpGet("/api/[controller]/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_pagamentoTipoService.TrazerPorId(id)); ;
        }

        [HttpPost]
        public IActionResult Post([FromBody]PagamentoTipo pagamentoTipo)
        {
            if (pagamentoTipo == null) return Response(null);
            _pagamentoTipoService.Criar(pagamentoTipo);
            return Response(pagamentoTipo);
        }

        [HttpPut]
        public IActionResult Put([FromBody]PagamentoTipo pagamentoTipo)
        {
            if (pagamentoTipo == null) return Response(null);
            _pagamentoTipoService.Atualizar(pagamentoTipo);
            return Response(pagamentoTipo);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]PagamentoTipo pagamentoTipo)
        {
            if (pagamentoTipo == null) return Response(null);
            _pagamentoTipoService.Deletar(pagamentoTipo.Id);
            return Response(pagamentoTipo);
        }
    }
}
