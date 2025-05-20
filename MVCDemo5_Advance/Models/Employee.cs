using System.ComponentModel.DataAnnotations;

namespace MVCDemo5_Advance.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name Cannot be more than 50Chars")]

        public string? Name { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
           ErrorMessage = "Invalid email format")]

        public string? Email { get; set; }
        public string Phone { get; set; }
        public string ?Address { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; } // Navigation property
    }
}
