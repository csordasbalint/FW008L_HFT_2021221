using FW008L_HFT_2021221.Logic;
using FW008L_HFT_2021221.Models;
using FW008L_HFT_2021221.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Test
{
    [TestFixture]
    public class TesterClass
    {
        BookLogic bl;
        PersonLogic pl;
        WriterLogic wl;
        
        public TesterClass()
        {
            bl = new BookLogic(new FakeBookRepository());
            pl = new PersonLogic(new FakePersonRepository());
            wl = new WriterLogic(new FakeWriterRepository());
        }

        #region fakepersonrepo
        class FakePersonRepository : IPersonRepository
        {
            public void Create(Person person)
            {
                //deleted for testing
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Person Read(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Person> ReadAll()
            {
                Person fakePerson = new Person();
                fakePerson.Person_Id = 1;
                fakePerson.Name = "Victor";
                fakePerson.Nationality = "innen";
                fakePerson.Age = 15;

                return (IQueryable<Person>)new List<Book>()
                {
                    new Book(){
                        Genre= "novel",
                        Title = "elég",
                        Published = 1995,
                        Book_Id = 1,
                        Person = fakePerson

                    },
                    new Book(){
                        Genre= "novel",
                        Title = "elég",
                        Published = 1999,
                        Book_Id = 2,
                        Person = fakePerson
                    }
                }.AsQueryable();
            }

            public void Update(Person person)
            {
                throw new NotImplementedException();
            }
        }
        #endregion fakepersonrepo


        #region fakebookrepo
        class FakeBookRepository : IBookRepository
        {
            public void Create(Book book)
            {
                
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Book Read(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Book> ReadAll()
            {
                throw new NotImplementedException();
            }

            public void Update(Book book)
            {
                throw new NotImplementedException();
            }
        }
        #endregion fakebookrepo


        #region fakewriterrepo
        class FakeWriterRepository : IWriterRepository
        {
            public void Create(Writer writer)
            {
                
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Writer Read(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Writer> ReadAll()
            {
                throw new NotImplementedException();
            }

            public void Update(Writer writer)
            {
                throw new NotImplementedException();
            }
        }
        #endregion fakewriterrepo


        //[Test]
        //public void ElsoTeszt()
        //{
        //    //ARRANGE
        //    PersonLogic cl = new PersonLogic(new FakePersonRepository());
        //    //ACT
        //    var result = cl.HungarianReaders();

        //    //ASSERT
        //    var expected = new List<KeyValuePair<string, double>>()
        //    {
        //        new KeyValuePair<string, double>
        //        ("Victor", 2)
        //    };

        //    Assert.That(result, Is.EqualTo(expected));
        //}






        #region bookCreateMethodTest
        [TestCase("The first book which should pass the test",true)]  
        [TestCase("The story of a book which should also pass the test",true)]
        [TestCase("",false)]
        public void BookCreateMethodTest(string title,bool result) 
        {
            if (result == true)
            {
                Assert.That(() => bl.Create(new Book()
                {
                    Genre = "Novel",
                    Published = 1926,
                    Title = title
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => bl.Create(new Book()
                {
                    Genre = "Novel",
                    Published = 1926,
                    Title = title
                }), Throws.ArgumentException);
            }
        }
        #endregion bookCreateMethodTest


        #region personCreateMethodTest
        [TestCase(-5, false)]
        [TestCase(0, false)]
        [TestCase(40, true)]
        public void PersonCreateMethodTest(int age, bool result)
        {
            if (result == true)
            {
                Assert.That(() => pl.Create(new Person()
                {
                    Name = "Tester Tom",
                    Age = age,
                    Nationality = "Hungarian"
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => pl.Create(new Person()
                {
                    Name = "Tester Tom",
                    Age = age,
                    Nationality = "Hungarian"
                }), Throws.ArgumentException);
            }
        }
        #endregion personCreateMethodTest


        #region writerCreateMethodTest
        [TestCase(-10, false)]
        [TestCase(0, false)]
        [TestCase(60, true)]
        public void WriterCreateMethodTest(int age, bool result)
        {
            if (result == true)
            {
                Assert.That(() => wl.Create(new Writer()
                {
                    Name = "Passing Paul",
                    Age = age,
                    Nationality = "Scottish"
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => wl.Create(new Writer()
                {
                    Name = "Passing Paul",
                    Age = age,
                    Nationality = "Scottish"
                }), Throws.ArgumentException);
            }
        }
        #endregion writerCreateMethodTest

    }
}
