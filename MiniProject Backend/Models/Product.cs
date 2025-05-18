using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }                          // Primary Key
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        // Foreign Key to Category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Navigation: One Product -> Many CartItems
        public ICollection<CartItem> CartItems { get; set; }
    }
}
