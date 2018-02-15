using System.ComponentModel.DataAnnotations;

namespace ProjectDelivery.Infra.Identity.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "UserName não pode chegar nulo")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Senha não pode ser nula")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "ConfirmacaoSenha não pode ser nula")]
        [Compare(otherProperty: "Senha", ErrorMessage = "A Confirmacao da Senha precisa ser igual a Senha informada")]
        public string ConfirmacaoSenha { get; set; }
    }
}
