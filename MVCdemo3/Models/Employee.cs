using System.ComponentModel.DataAnnotations;

namespace MVCdemo3.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }

    }
}
