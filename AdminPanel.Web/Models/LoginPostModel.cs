using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Web.Models
{
    public class LoginPostModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [DisplayName("Stay signed in?")]
        public bool IsPersistent { get; set; } = false;
    }
}
