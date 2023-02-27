using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class RegisterUser
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido ")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string password { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int age { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string cell { get; set; }


    }


    public class LoginUser
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido ")]
        public string email { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string password { get; set; }
    }
}
