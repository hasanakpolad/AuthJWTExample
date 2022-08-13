using System.ComponentModel.DataAnnotations;

namespace AuthJWTExample.DTOes
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(127)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string LastName { get; set; }
    }
}
