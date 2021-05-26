using System.ComponentModel.DataAnnotations;

namespace WebAPIApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; } //Логин
        [Required]
        public string Password { get; set; } // Пароль
        [Required]
        public string Role { get; set; } // Роль
    }
}
