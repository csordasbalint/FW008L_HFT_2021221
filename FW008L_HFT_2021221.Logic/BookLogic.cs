using FW008L_HFT_2021221.Models;
using FW008L_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Logic
{
    public class BookLogic
    {
        IBookRepository bookRepo;

        public BookLogic(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public void Create(Book book)
        {
            bookRepo.Create(book);
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

    }
}
