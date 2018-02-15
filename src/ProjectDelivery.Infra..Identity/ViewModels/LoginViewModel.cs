using System.ComponentModel.DataAnnotations;

namespace ProjectDelivery.Infra.Identity.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username não informado")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Senha não informada")]
        public string Senha { get; set; }
    }
}
