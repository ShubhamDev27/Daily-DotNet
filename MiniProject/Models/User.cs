using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }  // Primary Key

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, ErrorMessage = "Name cannot be more than 20 characters.")]
        public string Username { get; set; }=string.Empty;
        public string Password { get; set; }=string.Empty;

        // Navigation: One User -> Many CartItems
        public ICollection<CartItem> CartItems { get; set; }
    }
}
