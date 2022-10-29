﻿using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Web.Models
{
    public class LoginPostModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public bool IsPersistent { get; set; } = false;
    }
}
