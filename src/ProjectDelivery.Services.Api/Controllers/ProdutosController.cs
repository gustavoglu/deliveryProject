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
    public class ProdutosController : BaseController
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IProdutoService produtoService) : base(bus, notifications)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_produtoService.TrazerTodosAtivos());
        }

        [HttpGet("/api/[controller]/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_produtoService.TrazerPorId(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Produto produto)
        {
            if (produto == null) return Response(null);
            _produtoService.Criar(produto);
            return Response(produto);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Produto produto)
        {
            if (produto == null) return Response(null);
            _produtoService.Atualizar(produto);
            return Response(produto);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Produto produto)
        {
            if (produto == null) return Response(null);
            _produtoService.Deletar(produto.Id);
            return Response(produto);
        }

    }
}
