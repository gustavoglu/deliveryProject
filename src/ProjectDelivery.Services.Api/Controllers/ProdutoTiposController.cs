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
    public class ProdutoTiposController : BaseController
    {
        private readonly IProdutoTipoService _produtoTipoService;
        public ProdutoTiposController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IProdutoTipoService produtoTipoService) : base(bus, notifications)
        {
            _produtoTipoService = produtoTipoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_produtoTipoService.TrazerTodosAtivos());
        }

        [HttpGet("/api/[controller]/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_produtoTipoService.TrazerPorId(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProdutoTipo produtoTipo)
        {
            if (produtoTipo == null) return Response(null);
            _produtoTipoService.Criar(produtoTipo);
            return Response(produtoTipo);
        }

        [HttpPut]
        public IActionResult Put([FromBody]ProdutoTipo produtoTipo)
        {
            if (produtoTipo == null) return Response(null);
            _produtoTipoService.Atualizar(produtoTipo);
            return Response(produtoTipo);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]ProdutoTipo produtoTipo)
        {
            if (produtoTipo == null) return Response(null);
            _produtoTipoService.Deletar(produtoTipo.Id);
            return Response(produtoTipo);
        }
    }
}
