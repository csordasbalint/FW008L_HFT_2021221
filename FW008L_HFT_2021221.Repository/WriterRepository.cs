using FW008L_HFT_2021221.Data;
using FW008L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Repository
{
    public class WriterRepository : IWriterRepository
    {
        LibraryDbContext db;

        public WriterRepository(LibraryDbContext db)
        {
            this.db = db;
        }

        public void Create(Writer writer)
        {
            db.Writers.Add(writer);
            db.SaveChanges();
        }

        public Writer Read(int id)
        {
            return db.Writers.FirstOrDefault(t => t.Writer_Id == id);
        }

        public IQueryable<Writer> ReadAll()
        {
            return db.Writers;
        }

        public void Delete(int id)
        {
            var writerToBeDeleted = Read(id);
            db.Writers.Remove(writerToBeDeleted);
            db.SaveChanges();
        }

        public void Update(Writer writer)
        {
            var oldWriter = Read(writer.Writer_Id);
            oldWriter.Name = writer.Name;
            oldWriter.Age = writer.Age;
            oldWriter.Nationality = writer.Nationality;
        }
    }
}
