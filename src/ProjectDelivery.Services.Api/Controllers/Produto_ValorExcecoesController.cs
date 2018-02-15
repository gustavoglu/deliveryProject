using Microsoft.AspNetCore.Mvc;
using ProjectDelivery.Application.Interfaces;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Domain.Entitys;
using System;

namespace ProjectDelivery.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class Produto_ValorExcecoesController : BaseController
    {
        private readonly IProduto_ValorExcecaoService _produto_ValorExcecaoService;
        public Produto_ValorExcecoesController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IProduto_ValorExcecaoService produto_ValorExcecaoService) : base(bus, notifications)
        {
            _produto_ValorExcecaoService = produto_ValorExcecaoService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Response(_produto_ValorExcecaoService.TrazerTodosAtivos());
        }

        [HttpGet("/api/[controller]/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_produto_ValorExcecaoService.TrazerPorId(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Produto_ValorExcecao produto_ValorExcecao)
        {
            if (produto_ValorExcecao == null) return Response(null);
            _produto_ValorExcecaoService.Criar(produto_ValorExcecao);
            return Response(produto_ValorExcecao);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Produto_ValorExcecao produto_ValorExcecao)
        {
            if (produto_ValorExcecao == null) return Response(null);
            _produto_ValorExcecaoService.Atualizar(produto_ValorExcecao);
            return Response(produto_ValorExcecao);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Produto_ValorExcecao produto_ValorExcecao)
        {
            if (produto_ValorExcecao == null) return Response(null);
            _produto_ValorExcecaoService.Deletar(produto_ValorExcecao.Id);
            return Response(produto_ValorExcecao);
        }
    }
}
