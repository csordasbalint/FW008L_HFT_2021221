using FW008L_HFT_2021221.Models;
using System.Linq;

namespace FW008L_HFT_2021221.Repository
{
    public interface IPersonRepository
    {
        void Create(Person person);
        void Delete(int id);
        Person Read(int id);
        IQueryable<Person> ReadAll();
        void Update(Person person);
    }
}