using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Entitys;

namespace ProjectDelivery.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PeriodosController : BaseController
    {
        private readonly IPeriodoService _periodoService;
        public PeriodosController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IPeriodoService periodoService) : base(bus, notifications)
        {
            _periodoService = periodoService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_periodoService.TrazerTodosAtivos());
        }

        [HttpGet("/api/[controller]/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_periodoService.TrazerPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Periodo periodo)
        {
            if (periodo == null) return Response(null);
            _periodoService.Criar(periodo);
            return Response(periodo);
        }

        [HttpPut]
        public IActionResult Put(Periodo periodo)
        {
            if (periodo == null) return Response(null);
            _periodoService.Atualizar(periodo);
            return Response(periodo);
        }

        [HttpDelete]
        public IActionResult Delete(Periodo periodo)
        {
            if (periodo == null) return Response(null);
            _periodoService.Deletar(periodo.Id);
            return Response(periodo);
        }
    }
}
