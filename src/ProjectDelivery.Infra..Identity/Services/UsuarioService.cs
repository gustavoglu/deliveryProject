using Microsoft.AspNetCore.Identity;
using ProjectDelivery.Domain.Core.Bus;
using ProjectDelivery.Domain.Core.Notifications;
using ProjectDelivery.Infra.Identity.Interfaces;
using ProjectDelivery.Infra.Identity.Model;
using System.Threading.Tasks;

namespace ProjectDelivery.Infra.Identity.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IBus _bus;

        public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IBus bus)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _bus = bus;
        }

        public async Task<Usuario> Criar(string username, string senha)
        {
            Usuario usuario = new Usuario() { UserName = username , Email = username};
            var response = await _userManager.CreateAsync(usuario, senha);

            if (!response.Succeeded)
            {
                EnviaErrosIdentity(response);
                return null;
            };

            return usuario;
        }

        public async Task<bool> DeletarPorId(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null) EnviaErro($"Usuario não existe, ID : {id}");

            var result = await _userManager.DeleteAsync(usuario);
            if (!result.Succeeded)
            {
                EnviaErrosIdentity(result);
                return false;
            }
            return true;
        }

        public async Task<bool> Login(string username, string senha)
        {
            var result = await _signInManager.PasswordSignInAsync(username, senha, false, false);
            if (!result.Succeeded)
            {
                EnviaErro("Não foi possivel logar-se");
                return false;
            }
            return true;
        }

        void EnviaErrosIdentity(IdentityResult identityResult)
        {
            foreach (var error in identityResult.Errors)
                _bus.RaizeEvent(new DomainNotification("Identity", error.Description));
        }

        void EnviaErro(string erroMessagem)
        {
            _bus.RaizeEvent(new DomainNotification("Identity", erroMessagem));
        }

        public async Task<bool> DeletarPorUserName(string userName)
        {
            var usuario = await _userManager.FindByEmailAsync(userName);
            if (usuario == null) EnviaErro($"Usuario não existe, USERNAME : {userName}");

            var result = await _userManager.DeleteAsync(usuario);
            if (!result.Succeeded)
            {
                EnviaErrosIdentity(result);
                return false;
            }
            return true;
        }

        public async Task<Usuario> TrazerPorId(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<Usuario> TrazerPorUserName(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }
    }
}
