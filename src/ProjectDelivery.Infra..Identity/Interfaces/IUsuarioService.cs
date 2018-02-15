using ProjectDelivery.Infra.Identity.Model;
using System.Threading.Tasks;

namespace ProjectDelivery.Infra.Identity.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> Criar(string username, string senha);
        Task<bool> DeletarPorId(string id);
        Task<bool> DeletarPorUserName(string userName);
        Task<bool> Login(string username, string senha);
        Task<Usuario> TrazerPorId(string id);
        Task<Usuario> TrazerPorUserName(string username);
    }
}
