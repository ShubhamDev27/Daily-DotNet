using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MVCDemo_6Advance.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, ErrorMessage = "Name cannot be more than 20 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(100, ErrorMessage = "Address cannot be more than 100 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "DepartmentId is required.")]
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department? Department { get; set; }
    }
}
