using FW008L_HFT_2021221.Models;
using FW008L_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Logic
{
    public class BookLogic : IBookLogic
    {
        IBookRepository bookRepo;

        public BookLogic(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public void Create(Book book)
        {
            if (book.Title == "")
            {
                throw new ArgumentException("A book must have a title!");
            }
            else
            {
                bookRepo.Create(book);
            }

        }

        public void Delete(int id)
        {
            bookRepo.Delete(id);
        }

        public Book Read(int id)
        {
            return bookRepo.Read(id);
        }

        public void Update(Book book)
        {
            bookRepo.Update(book);
        }

        public IEnumerable<Book> ReadAll()
        {
            return bookRepo.ReadAll();
        }


        //=================================================================================================
        //1st non-crud method--gives back those people who are 18 years old or younger, and how many books they have borrowed
        public IEnumerable<KeyValuePair<string, int>> HowManyBooksDoTheyReadUnder18()
        {
            return (from x in bookRepo.ReadAll()
                    where x.Person.Age < 19
                    orderby x.Person.Name ascending
                    select new KeyValuePair<string, int>(x.Person.Name, x.Person.Books.Count)).Distinct();

        }
        //=================================================================================================
        


        //=================================================================================================
        //2nd non-crud method--gives back the last published books of writers whose name contains "george"
        public IEnumerable<KeyValuePair<string, int>> LatestPublishedBooksByGeorges()
        {
            return from x in bookRepo.ReadAll()
                   where x.Writer.Name.ToLower().Contains("george")
                   group x by x.Writer.Name into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Max(t => t.Published));
        }
        //=================================================================================================



        //=================================================================================================
        //3rd non-crud method--gives back a book (and its writer) which genre is "AUTOBIOGRAPHY"
        public IEnumerable<KeyValuePair<string, string>> AutobiographiesByTitle()
        {
            return from x in bookRepo.ReadAll()
                   where x.Genre.ToUpper().Contains("AUTOBIOGRAPHY")
                   orderby x.Title.Length
                   select new KeyValuePair<string, string>
                   (x.Writer.Name, x.Genre);
        }
        //=================================================================================================



    }
}
