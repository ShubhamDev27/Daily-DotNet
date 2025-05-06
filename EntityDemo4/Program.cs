using System.Security.Cryptography;
using EntityDemo4.Models;
using EntityDemo4.Service;

namespace EntityDemo4
{
    public class Program
    {
        static void Main(string[] args)
        {
            BookService b1 = new BookService();

            var a1 = new Author
            {
                FirstName = "William",
                LastName = "Shakespear",
                Books = new List<Book> { new Book{Title ="Hamlet " },
                                      new Book {Title ="Othello" },
                                      new Book{Title = "MacBeth" }
                                     }


            };
           // b1.Addmany(a1);

            var b2 = new Book 
            {
               Title = "Attitude",
               Author = new Author
               {
                   FirstName = "Jeff",
                   LastName = "Keller"

               }
             
            };
            //b1.AddBook(b2);
           // b1.RemoveBook(1);
           // b1.AuthDel(2);
            var b3 = b1.GetById(4);
            Console.WriteLine($"Book: {b3.Title}");

            var book = new Book
            {
                Title = "Laws",
                Id = 6,
                AuthorId = 4
            };
           // b1.UpdateBook(book);

            
            Console.WriteLine("All Books with Author :");
            var a = b1.DispAll();

            foreach (var x in a) 
            {
                Console.WriteLine($"Book Id : {x.Id},Book Title :{x.Title},Author Id : {x.Author.AuthorId},Auther Name:{x.Author.FirstName}");
            }

           


        }
    }
}
