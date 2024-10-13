using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace G_5_BMS.Views.Admin
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "UserName or Email is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed.")]
        [DisplayName("UserName or Email")]
        public string UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 or minimum 5 characters allowed.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
