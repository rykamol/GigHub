﻿using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModles
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
