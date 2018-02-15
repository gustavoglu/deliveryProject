using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Infra.Identity.Interfaces;
using ProjectDelivery.Infra.Identity.ViewModels;
using ProjectDelivery.Services.Api.Configuracoes;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ProjectDelivery.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IUsuarioService usuarioService) : base(bus, notifications)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("/api/[controller]/Registro")]
        public async Task<IActionResult> Registro([FromBody]RegistroViewModel registro)
        {
            var usuario = await _usuarioService.Criar(registro.UserName, registro.Senha);
            if (usuario == null) return Response(null);
            return Response(usuario);
        }

        [HttpPost]
        [Route("/api/[controller]/Login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel login, [FromServices]SigningConfig signingConfigs, [FromServices]TokenConfig tokenConfigs)
        {
            if (login == null)
            {
                NotificaErro("Login", "LoginViewModel null");
                return Response(null);
            };

            var loginResponse = await _usuarioService.Login(login.UserName, login.Senha);

            if (!loginResponse) return Response(null);

            var usuario = await _usuarioService.TrazerPorUserName(login.UserName);

            if(usuario == null)
            {
                NotificaErro("Login" ,"Usuario não encontrado");
                return Response(null);
            }

            var genericIdentity = new GenericIdentity(usuario.UserName, usuario.UserName);
            var claimList = new List<Claim>
            {
                new Claim("UserId", usuario.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName)
            };

            ClaimsIdentity identity = new ClaimsIdentity(genericIdentity, claimList);

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + new TimeSpan(24,0,0);//TimeSpan.FromSeconds(tokenConfigs.Seconds);

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigs.Issuer,
                Audience =tokenConfigs.Audience,
                SigningCredentials = signingConfigs.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            var token = handler.WriteToken(securityToken);

            var response = new
            {
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token
            };

            return Response(response);
        }
    }
}
