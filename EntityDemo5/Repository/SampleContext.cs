using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDemo5.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityDemo5.Service
{
    public class SampleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null) 
            {

                if (!optionsBuilder.IsConfigured)
                    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=ADOcode2;Integrated Security=True;");

            }
        
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        

    }
}
