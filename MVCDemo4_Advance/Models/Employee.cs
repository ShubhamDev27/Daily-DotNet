using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MVCDemo4_Advance.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
     //   [JsonIgnore]
        public Department Department { get; set; }
    }
}
