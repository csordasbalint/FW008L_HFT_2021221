using FW008L_HFT_2021221.Models;
using System.Collections.Generic;

namespace FW008L_HFT_2021221.Logic
{
    public interface IWriterLogic
    {
        void Create(Writer writer);
        void Delete(int id);
        Writer Read(int id);
        IEnumerable<Writer> ReadAll();
        IEnumerable<KeyValuePair<string, int>> Top2ProductiveWriters();
        void Update(Writer writer);
    }
}