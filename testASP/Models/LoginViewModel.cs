using System.ComponentModel.DataAnnotations;

namespace testASP.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [UIHint("password")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool Remember { get; set; }
    }
}
