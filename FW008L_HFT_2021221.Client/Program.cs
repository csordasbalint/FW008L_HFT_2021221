using FW008L_HFT_2021221.Data; //IMPORTANT TO DELETE
using FW008L_HFT_2021221.Logic;
using FW008L_HFT_2021221.Repository;
using System;
using System.Linq;

namespace FW008L_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext db = new LibraryDbContext();

            var test = db.Writers.ToList();


            BookLogic bcl = new BookLogic(new BookRepository(db));
            PersonLogic pcl = new PersonLogic(new PersonRepository(db));
            WriterLogic wlc = new WriterLogic(new WriterRepository(db));

            var logic = pcl.HungarianReaders();

            var logic2 = bcl.HowManyBooksDoTheyReadUnder18();
            
            var logic3 = bcl.LatestPublishedBooksByGeorges();

            var logic4 = bcl.AutobiographiesByTitle();

            var logic5 = wlc.Top2ProductiveWriters();

            ; 
        }
    }
}
