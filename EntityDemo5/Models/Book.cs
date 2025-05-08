using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo5.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Title { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
