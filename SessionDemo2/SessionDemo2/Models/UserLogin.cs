using System.ComponentModel.DataAnnotations;

namespace SessionDemo2.Models
{
    public class UserLogin
    {
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
