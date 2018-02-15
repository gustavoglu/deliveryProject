using Microsoft.AspNetCore.Mvc;
using System;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Entitys;
using ProjectDelivery.Domain.Repositorys;
using ProjectDelivery.Application.Interfaces;

namespace ProjectDelivery.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AdicionaisController : BaseController
    {
        private readonly IAdicionalService _adicionalService;

        public AdicionaisController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IAdicionalRepository adicionalRepository, IAdicionalService adicionalService) : base(bus, notifications)
        {
            _adicionalService = adicionalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_adicionalService.TrazerTodosAtivos());
        }

        [HttpGet("/api/[controller]/{id}")]
        public IActionResult GetById(Guid id)
        {
            var adicional = _adicionalService.TrazerPorId(id);
            return Response(adicional);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Adicional adicional)
        {
            if (adicional == null) return Response(null);
            _adicionalService.Criar(adicional);
            return Response(adicional);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Adicional adicional)
        {
            if (adicional == null) return Response(null);
            _adicionalService.Atualizar(adicional);
            return Response(adicional);
        }

        [HttpDelete("/api/[controller]/{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == null) return Response(null);
            _adicionalService.Deletar(id);
            return Response(id);
        }
    }
}
