using System.ComponentModel.DataAnnotations;

namespace Supliex.Domain.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }

}
