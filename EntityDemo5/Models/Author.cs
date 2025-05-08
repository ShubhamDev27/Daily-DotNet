using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo5.Models
{
    public class Author
    {
        [Key]
        public int Authord { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }


        public ICollection<Book> Books { get; set; }    

    }
}
