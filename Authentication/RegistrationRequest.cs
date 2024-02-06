using System.ComponentModel.DataAnnotations;

namespace todogamma.Controllers;
public class RegistrationRequest
{
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
}