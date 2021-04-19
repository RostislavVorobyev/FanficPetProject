using System.ComponentModel.DataAnnotations;

namespace FictionUILayer.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter you logn.")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter you login.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        [Display(Name = "Remember me?")] public bool RememberMe { get; set; } = false;

    }
}
