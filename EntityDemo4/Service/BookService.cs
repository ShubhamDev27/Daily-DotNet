using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDemo4.Models;
using EntityDemo4.Repository;
using Microsoft.EntityFrameworkCore;


namespace EntityDemo4.Service
{
    public class BookService
    {
        private readonly SampleContext db;

        internal BookService()
        {
            db = new SampleContext();
        }

        public void Addmany(Author a1)
        {

            db.Add(a1);
            db.SaveChanges();
        }

        public void AddBook(Book b2)
        {
            db.Add(b2);
            db.SaveChanges();
        }
        public void RemoveBook(int id)
        {
            var book = db.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                db.Remove(book);
                db.SaveChanges();
            }

        }
//        public void AuthDel(int id)
//{
//    using var db1 = new SampleContext();
//    var auth = db1.Authors.Find(id); // or SingleOrDefault(...)
    
//    if (auth != null) 
//    {
//        db1.Remove(auth);
//        db1.SaveChanges();
//    }
//}

        public Book GetById(int id) 
        {
          return db.Books.SingleOrDefault(x=>x.Id==id);

        }
        public void UpdateBook(Book book) 
        { 
          var ExistBook = db.Books.Find(book.Id);
            if (ExistBook != null) 
            {
                db.Entry(ExistBook).State = EntityState.Detached;

            }
            /db.Update(book);
            db.SaveChanges();
        }

        public IEnumerable<Book> DispAll() 
        {
         return db.Books.Include((a) => a.Author).ToList<Book>();
        }

      


    }
}
