using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModles
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}