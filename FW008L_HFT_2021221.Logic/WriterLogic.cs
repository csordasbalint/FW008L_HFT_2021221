using FW008L_HFT_2021221.Models;
using FW008L_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Logic
{
    public class WriterLogic : IWriterLogic
    {
        IWriterRepository writerRepo;

        public WriterLogic(IWriterRepository writerRepo)
        {
            this.writerRepo = writerRepo;
        }

        public void Create(Writer writer)
        {
            if (writer.Age <= 0)
            {
                throw new ArgumentException("Age must be greater than 0");
            }
            else
            {
                writerRepo.Create(writer);
            }

        }

        public void Delete(int id)
        {
            writerRepo.Delete(id);
        }

        public Writer Read(int id)
        {
            return writerRepo.Read(id);
        }

        public void Update(Writer writer)
        {
            writerRepo.Update(writer);
        }

        public IEnumerable<Writer> ReadAll()
        {
            return writerRepo.ReadAll();
        }



        //=================================================================================================
        //5th non-crud method--gives back the 2 most productive writers and the amount of books they have written
        public IEnumerable<KeyValuePair<string, int>> Top2ProductiveWriters()
        {
            var top2 = writerRepo.ReadAll().OrderByDescending(x => x.Books.Count).Select(x => x.Name);

            return (from x in writerRepo.ReadAll()
                    where top2.Contains(x.Name)
                    orderby x.Books.Count descending
                    select new KeyValuePair<string, int>
                    (x.Name, x.Books.Count)).Take(2);
        }
        //=================================================================================================



        //=================================================================================================
        //noncrud for testing
        public int OldestWriter()
        {
            return writerRepo.ReadAll().Max(x => x.Age);
        }
        //=================================================================================================
    }
}
