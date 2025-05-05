using System.ComponentModel.DataAnnotations;

namespace MVCDemo_6Advance.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [MaxLength(50, ErrorMessage = "Department name cannot be more than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [MaxLength(100, ErrorMessage = "Location cannot be more than 100 characters.")]
        public string Location { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
