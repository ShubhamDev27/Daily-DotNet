using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }                          // Primary Key

        // Foreign Key to User
        public int UserId { get; set; }
        public User? User { get; set; }

        // Foreign Key to Product
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }
    }
}
