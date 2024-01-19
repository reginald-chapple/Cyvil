using System.ComponentModel.DataAnnotations;

namespace Cyvil.Web.Models
{
    public class AuthenticationModel
    {
        [Required]
        [StringLength(16, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = string.Empty;


        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Password { get; set; } = string.Empty;
    }
}