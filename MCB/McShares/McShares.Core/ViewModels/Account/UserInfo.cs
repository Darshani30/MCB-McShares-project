using System.ComponentModel.DataAnnotations;

namespace McShares.Core.ViewModels.Account
{
    public class UserInfo
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
