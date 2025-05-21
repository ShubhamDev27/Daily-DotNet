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

        
        public string Gender { get; set; }

       
        public string Sallary { get; set; }

     
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department? Department { get; set; }
    }
}
