using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDemo5.Models;
using EntityDemo5.Service;
using Microsoft.EntityFrameworkCore;

namespace EntityDemo5.Serives
{
    public class BookServices
    {
        private readonly SampleContext db;
        public BookServices() 
        {
          db = new SampleContext();
        }

        public void AddMany(Author author) 
        {
          db.Add(author);
            db.SaveChanges();
        
        }
        public void AddBook(Book book) 
        {
            db.Add(book);
            db.SaveChanges();
        
        }
        public void RemoveBook(int id) 
        {
          var a = db.Books.FirstOrDefault(x => x.Id == id);
            if (a != null) 
            {
                db.Remove(a);
                db.SaveChanges();
            }
        
        }
        public Book GetById(int id)
        {
            return db.Books.SingleOrDefault(x => x.Id == id);
            
        }
        public void UpdateBook(Book b1) 
        {
            var ExistBook = db.Books.Find(b1.Id);
            if(ExistBook != null)
            {
              db.Entry(ExistBook).State = EntityState.Detached;
                
            }
            db.Update(b1);
            db.SaveChanges();



        }
        public ICollection<Book> DispAll() 
        {
          return db.Books.Include(x => x.Author).ToList();
        }

    }
}
