using FW008L_HFT_2021221.Models;
using FW008L_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Logic
{
    public class WriterLogic
    {
        IWriterRepository writerRepo;

        public WriterLogic(IWriterRepository writerRepo)
        {
            this.writerRepo = writerRepo;
        }

        public void Create(Writer writer)
        {
            writerRepo.Create(writer);
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

    }
}
