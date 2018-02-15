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
    public class TamanhosController : BaseController
    {
        private readonly ITamanhoService _tamanhoService;

        public TamanhosController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, ITamanhoService tamanhoService) : base(bus, notifications)
        {
            _tamanhoService = tamanhoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_tamanhoService.TrazerTodosAtivos());
        }

        [HttpGet]
        [Route("api/[controller]/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_tamanhoService.TrazerPorId(id));
        }


        [HttpPost]
        public IActionResult Post(Tamanho tamanho)
        {
            if (tamanho == null) return Response(null);
            _tamanhoService.Criar(tamanho);
            return Response(tamanho);
        }

        [HttpPut]
        public IActionResult Put(Tamanho tamanho)
        {
            if (tamanho == null) return Response(null);
            _tamanhoService.Atualizar(tamanho);
            return Response(tamanho);
        }

        [HttpDelete]
        public IActionResult Delete(Tamanho tamanho)
        {
            if (tamanho == null) return Response(null);
            _tamanhoService.Deletar(tamanho.Id);
            return Response(tamanho);
        }


    }
}
