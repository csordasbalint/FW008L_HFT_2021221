using FW008L_HFT_2021221.Models;
using System.Collections.Generic;

namespace FW008L_HFT_2021221.Logic
{
    public interface IBookLogic
    {
        IEnumerable<KeyValuePair<string, string>> AutobiographiesByTitle();
        void Create(Book book);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, int>> HowManyBooksDoTheyReadUnder18();
        IEnumerable<KeyValuePair<string, int>> LatestPublishedBooksByGeorges();
        Book Read(int id);
        IEnumerable<Book> ReadAll();
        void Update(Book book);
    }
}