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


            Person person1 = new Person();
            person1.Person_Id = 1;
            person1.Name = "Herbert";
            person1.Age = 17;
            person1.Nationality = "Hungarian";

            Person person2 = new Person();
            person2.Person_Id = 2;
            person2.Name = "James";
            person2.Age = 25;
            person2.Nationality = "German";


            List<Writer> writers = new List<Writer>() { writer1, writer2 };
            List<Person> people = new List<Person>() { person1, person2 };


            var books = new List<Book>()
                {
                    new Book()
                    {
                        Book_Id = 1,
                        Person_Id = person1.Person_Id,
                        Person = person1,

                        Title= "Peeling the Onion",
                        Genre= "Novel",

                        Published = 1949,
                        Writer = writer1,
                        Writer_Id = writer1.Writer_Id
                    },
                    new Book()
                    {
                        Book_Id = 2,
                        Person_Id = person1.Person_Id,
                        Person = person1,

                        Title = "Animal Farm",
                        Genre= "Novel",

                        Published = 1933,
                        Writer = writer1,
                        Writer_Id = writer1.Writer_Id
                    },
                    new Book()
                    {
                        Book_Id = 3,
                        Person_Id = person2.Person_Id,
                        Person = person2,

                        Title = "Grease Junkie",
                        Genre= "Autobiography",

                        Published = 2011,
                        Writer = writer2,
                        Writer_Id = writer2.Writer_Id
                    }
                };
          
            person1.Books.Add(books[0]);
            person1.Books.Add(books[1]);
            person2.Books.Add(books[2]);
            
            writer1.Books.Add(books[0]);
            writer1.Books.Add(books[1]);
            writer2.Books.Add(books[2]);




            mockWriterRepository.Setup((t) => t.ReadAll()).Returns(writers.AsQueryable); 
            mockPersonRepository.Setup((t) => t.ReadAll()).Returns(people.AsQueryable); 
            mockBookRepository.Setup((t) => t.ReadAll()).Returns(books.AsQueryable());
   

            bl = new BookLogic(mockBookRepository.Object);
            pl = new PersonLogic(mockPersonRepository.Object);
            wl = new WriterLogic(mockWriterRepository.Object);
        }




        [Test]
        public void HowManyBooksTest()
        {
            var result = bl.HowManyBooksDoTheyReadUnder18();

            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>
                ("Herbert", 2)
            };
            
            Assert.That(result, Is.EqualTo(expected));
        }


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


        [Test]
        public void HungarianReadersTest()
        {
            var result = pl.HungarianReaders();
            
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>
                ("Herbert", 2)
            };
            
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        public void TheMostProductiveWriterTest()
        {
            var result = wl.Top2ProductiveWriters();

            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>
                ("George Orwell", 2),
                new KeyValuePair<string, int>
                ("Edd China", 1)
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
