using FW008L_HFT_2021221.Models;
using System.Collections.Generic;

namespace FW008L_HFT_2021221.Logic
{
    public interface IPersonLogic
    {
        void Create(Person person);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, int>> HungarianReaders();
        Person Read(int id);
        IEnumerable<Person> ReadAll();
        void Update(Person person);
    }
}