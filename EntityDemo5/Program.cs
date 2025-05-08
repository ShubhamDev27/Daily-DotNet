using System.Reflection;
using EntityDemo5.Models;
using EntityDemo5.Serives;
using Microsoft.Identity.Client;

namespace EntityDemo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookServices bk = new BookServices();

            var author = new Author
            {
                FirstName = "William",
                LastName = "Shakespear",
                Books = new List<Book>()
              {
               new Book{Title = "Hamlet" },
               new Book{Title = "Olemt" },
               new Book {Title ="matt" }

              }

            };
            //bk.AddMany(author);

            var book = new Book
            {
                Title = "Attitude",
                Author = new Author
                {
                    FirstName = "Jeff",
                    LastName = "Keller"
               }
            };
            // bk.AddBook(book);

            //bk.RemoveBook(7);

            var b = bk.GetById(1);
            Console.WriteLine($"Book : {b.Title}");

            var b1 = new Book
            {
                Title = "new Book",
                AuthorId = 2,
                Id = 6
            };
            
             bk.UpdateBook(b1);


            Console.WriteLine("All books with Auther :");
            var disp = bk.DispAll();

            foreach (var a in disp) 
            {
                Console.WriteLine($"Book Id: {a.Id},Name : {a.Title},AuthorId :{a.AuthorId},Author Name : {a.Author.FirstName}");
            }
        }
    }
}
