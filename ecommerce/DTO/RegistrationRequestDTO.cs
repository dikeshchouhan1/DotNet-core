using System.ComponentModel.DataAnnotations;
namespace ecommerce.DTO
{
    public class RegistrationRequestDTO
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string UserEmail { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password")]
        public string  confirm { get; set; } = string.Empty;

        [Required]
        public List<int>? RoleIds { get; set; } 

       
    }
}
