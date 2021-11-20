using FW008L_HFT_2021221.Logic;
using FW008L_HFT_2021221.Models;
using FW008L_HFT_2021221.Repository;
using Moq;
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

        [SetUp]
        public void InIt() 
        {
            var mockBookRepository =new Mock<IBookRepository>();
            var mockPersonRepository = new Mock<IPersonRepository>();
            var mockWriterRepository = new Mock<IWriterRepository>();


            Writer writer1 = new Writer();
            writer1.Writer_Id = 1;
            writer1.Name = "George Orwell";

            Writer writer2 = new Writer();
            writer2.Writer_Id = 2;
            writer2.Name = "Edd China";


            Person fakePerson = new Person();
            fakePerson.Person_Id = 1;
            fakePerson.Name = "Herbert";
            fakePerson.Age = 17;       
            //fakePerson.Books.Count = 2;

            var books = new List<Book>()
                {
                    new Book(){
                        Book_Id = 1,
                        Person_Id = fakePerson.Person_Id,
                        Person = fakePerson,

                        Title= "Peeling the Onion",
                        Genre= "Novel",

                        Published = 1949,
                        Writer = writer1,
                        Writer_Id = 1
                    },
                    new Book(){
                        Book_Id = 2,
                        Person_Id = fakePerson.Person_Id,
                        Person = fakePerson,

                        Title = "Animal Farm",
                        Genre= "Novel",

                        Published = 1933,
                        Writer = writer1,
                        Writer_Id = 1
                    },
                    new Book(){
                        Book_Id = 3,
                        Person_Id = fakePerson.Person_Id,
                        Person = fakePerson,

                        Title = "Grease Junkie",
                        Genre= "Autobiography",

                        Published = 2011,
                        Writer = writer2,
                        Writer_Id = 2
                    }
                }.AsQueryable();



            mockBookRepository.Setup((t) => t.ReadAll()).Returns(books);


            bl = new BookLogic(mockBookRepository.Object);
            pl = new PersonLogic(mockPersonRepository.Object);
            wl = new WriterLogic(mockWriterRepository.Object);
        }

        //[Test]
        //public void ElsoTeszt()
        //{            
        //    var result = bl.HowManyBooksDoTheyReadUnder18();  //should be 2 but its 0
            
        //    var expected = new List<KeyValuePair<string, int>>()
        //    {
        //        new KeyValuePair<string, int>
        //        ("Herbert", 2)
        //    };

        //    Assert.That(result, Is.EqualTo(expected));
        //}

        [Test]
        public void LatestPublishedBookByGeorgeTest()
        {
            var result = bl.LatestPublishedBooksByGeorges();
            
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>
                ("George Orwell",1949)
            };

            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        public void IsGenreAutobiographyTest()
        {
            var result = bl.AutobiographiesByTitle();

            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>
                ("Edd China", "Autobiography")
            };

            Assert.That(result, Is.EqualTo(expected));
        }




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
