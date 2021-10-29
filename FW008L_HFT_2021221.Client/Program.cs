using FW008L_HFT_2021221.Data; //IMPORTANT TO DELETE
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

            var test2 = db.Books.ToList();

            ;
            
        }
    }
}
