using FW008L_HFT_2021221.Models;
using FW008L_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Logic
{
    public class PersonLogic
    {
        IPersonRepository personRepo;

        public PersonLogic(IPersonRepository personRepo)
        {
            this.personRepo = personRepo;
        }

        public void Create(Person person)
        {
            personRepo.Create(person);
        }

        public void Delete(int id)
        {
            personRepo.Delete(id);
        }

        public Person Read(int id)
        {
            return personRepo.Read(id);
        }

        public void Update(Person person)
        {
            personRepo.Update(person);
        }

        public IEnumerable<Person> ReadAll()
        {
            return personRepo.ReadAll();
        }


    }
}
