using System.ComponentModel.DataAnnotations;

namespace MVCDemo4_Advance.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
       // public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; } 
    }
}
