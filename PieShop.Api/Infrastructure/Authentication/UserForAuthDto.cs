using System.ComponentModel.DataAnnotations;

namespace PieShop.Api.Infrastructure.Authentication
{
    public class UserForAuthDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; }
    }
}
