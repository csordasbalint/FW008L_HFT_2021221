using FW008L_HFT_2021221.Data;
using FW008L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Repository
{
    public class PersonRepository : IPersonRepository
    {
        LibraryDbContext db;

        public PersonRepository(LibraryDbContext db)
        {
            this.db = db;
        }

        public void Create(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
        }

        public Person Read(int id)
        {
            return db.People.FirstOrDefault(t => t.Person_Id == id);
        }

        public IQueryable<Person> ReadAll()
        {
            return db.People;
        }

        public void Delete(int id)
        {
            var PersonToBeDeleted = Read(id);
            db.People.Remove(PersonToBeDeleted);
            db.SaveChanges();
        }

        public void Update(Person person)
        {
            var oldPerson = Read(person.Person_Id);
            oldPerson.Name = person.Name;
            oldPerson.Age = person.Age;
            oldPerson.Nationality = person.Nationality;
        }

    }
}
