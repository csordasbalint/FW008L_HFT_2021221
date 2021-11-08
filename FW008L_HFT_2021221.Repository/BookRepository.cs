using FW008L_HFT_2021221.Data;
using FW008L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Repository
{
    public class BookRepository : IBookRepository
    {
        LibraryDbContext db;

        public BookRepository(LibraryDbContext db)
        {
            this.db = db;
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public Book Read(int id)
        {
            return db.Books.FirstOrDefault(t => t.Book_Id == id);
        }

        public IQueryable<Book> ReadAll()
        {
            return db.Books;
        }

        public void Delete(int id)
        {
            var bookToBeDeleted = Read(id);
            db.Books.Remove(bookToBeDeleted);
            db.SaveChanges();
        }

        public void Update(Book book)
        {
            var oldBook = Read(book.Book_Id);
            oldBook.Title = book.Title;
            oldBook.Published = book.Published;
            oldBook.Genre = book.Genre;
            oldBook.Writer_Id = book.Writer_Id;
            oldBook.Person_Id = book.Person_Id;
            db.SaveChanges();
        }



    }
}
