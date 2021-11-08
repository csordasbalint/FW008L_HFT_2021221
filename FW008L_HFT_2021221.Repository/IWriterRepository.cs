using FW008L_HFT_2021221.Models;
using System.Linq;

namespace FW008L_HFT_2021221.Repository
{
    public interface IWriterRepository
    {
        void Create(Writer writer);
        void Delete(int id);
        Writer Read(int id);
        IQueryable<Writer> ReadAll();
        void Update(Writer writer);
    }
}