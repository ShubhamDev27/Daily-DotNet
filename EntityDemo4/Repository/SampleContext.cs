using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDemo4.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityDemo4.Repository
{
    public class SampleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=ADOcode;Integrated Security=True;");

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>()
        //        .HasOne(b => b.Author)
        //        .WithMany(a => a.Books)
        //        .HasForeignKey(b => b.AuthorId)
        //        .OnDelete(DeleteBehavior.Restrict);
        //}


        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
    