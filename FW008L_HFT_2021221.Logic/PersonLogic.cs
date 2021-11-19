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
            if (person.Age <= 0)
            {
                throw new ArgumentException("Age must be greater than 0");
            }
            else
            {
                personRepo.Create(person);
            }
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


        //=================================================================================================
        //4th non-crud method--gives back hungarian people who borrowed books from the library(and the amount)
        public IEnumerable<KeyValuePair<string, int>> HungarianReaders()
        {
            return from x in personRepo.ReadAll()
                   where x.Nationality.ToLower().Contains("hungarian")
                   orderby x.Books.Count
                   select new KeyValuePair<string, int>(x.Name, x.Books.Count());
        }
        //=================================================================================================


    }
}
