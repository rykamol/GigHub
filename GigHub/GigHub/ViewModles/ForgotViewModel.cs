using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModles
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}