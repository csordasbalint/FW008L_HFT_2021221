using FW008L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FW008L_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:48920");  //base url copied from launchSettings.json file


            #region userinterface
            Console.Title = "Lukste Library";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string welcomeText = "~~  Welcome!  ~~";
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition((Console.WindowWidth - welcomeText.Length) / 2, Console.CursorTop); //setting welcometext to the middle
            Console.WriteLine(welcomeText);
            Console.WriteLine();

            PrintingMethod();


            bool stop = true;
            while (stop)
            {
                
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        var books = rest.Get<Book>("book");
                        foreach (Book book in books)
                        {
                            Console.WriteLine(string.Format("|| {0,-43} | {1,-23} | {2,4} ||", book.Title, book.Genre, book.Published));
                        }
                        Console.WriteLine();

                        PrintingMethod();
                        break;


                    case "2":
                        var people = rest.Get<Person>("person");              
                        foreach (Person person in people)
                        {
                            Console.WriteLine(string.Format("|| {0,-10} | {1,2} | {2,-10} ||", person.Name, person.Age, person.Nationality));
                        }
                        Console.WriteLine();

                        PrintingMethod();
                        break;


                    case "3":
                        var writers = rest.Get<Writer>("writer");
                        foreach (Writer writer in writers)
                        {
                            Console.WriteLine(string.Format("|| {0,-22} | {1,2} | {2,-10} ||", writer.Name, writer.Age, writer.Nationality));
                        }
                        Console.WriteLine();

                        PrintingMethod();
                        break;


                    case "4":

                        Console.WriteLine("First of all, enter the title of the book!");
                        string title1 = Console.ReadLine();

                        Console.WriteLine("Next, enter the year when it was published!");
                        int pub1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Next, please enter the genre of the book!");
                        string genre1 = Console.ReadLine();

                        Console.WriteLine("Next, please enter the ID of a writer, who wrote this book!");
                        int writerId1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Last thing to do, please enter the ID of a person, who borrowed this book!");
                        int personId1 = int.Parse(Console.ReadLine());


                        rest.Post(new Book()
                        {
                            Title = title1,
                            Published = pub1,
                            Genre = genre1,
                            Writer_Id = writerId1,
                            Person_Id = personId1
                        }, "book");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have successfully added the book!");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        PrintingMethod();

                        break;


                    case "5":

                        Console.WriteLine("First of all, please enter the name of the person!");
                        string person_name1 = Console.ReadLine();

                        Console.WriteLine("Next, please enter the age of the person!");
                        int person_age1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Last thing to do, please enter the nationality of the person!");
                        string person_nat1 = Console.ReadLine();

                        rest.Post(new Person()
                        {
                            Name = person_name1,
                            Age = person_age1,
                            Nationality = person_nat1
                        }, "person");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have successfully created the person's data!");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        PrintingMethod();

                        break;


                    case "6":

                        Console.WriteLine("First of all, please enter the name of the writer!");
                        string writer_name1= Console.ReadLine();

                        Console.WriteLine("Next, please enter the age of the writer!");
                        int writer_age1 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Last thing to do, please enter the nationality of the writer!");
                        string writer_nat1 = Console.ReadLine();

                        rest.Post(new Writer()
                        {
                            Name = writer_name1,
                            Age = writer_age1,
                            Nationality = writer_nat1
                        }, "writer");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have successfully created the writer's data!");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        PrintingMethod();

                        break;


                    case "7":

                        Console.WriteLine("First of all, please enter the ID of the book which you want to update!");
                        int bookOwnId2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Next, enter the title of the book!");
                        string title2 = Console.ReadLine();

                        Console.WriteLine("Next, enter the year when it was published!");
                        int pub2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Next, please enter the genre of the book!");
                        string genre2 = Console.ReadLine();

                        Console.WriteLine("Next, please enter the ID of a writer, who wrote this book!");
                        int writerId2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Last thing to do, please enter the ID of a person, who borrowed this book!");
                        int personId2 = int.Parse(Console.ReadLine());


                        rest.Put(new Book()
                        {
                            Book_Id = bookOwnId2,
                            Title = title2,
                            Published = pub2,
                            Genre = genre2,
                            Writer_Id = writerId2,
                            Person_Id = personId2              
                        }, "book");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have successfully updated the book!");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        PrintingMethod();

                        break;


                    case "8":

                        Console.WriteLine("First of all, please enter the ID of the person whose data you want to update!");
                        int personOwnId2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Next, please enter the name of the person!");
                        string person_name2 = Console.ReadLine();

                        Console.WriteLine("Next, please enter the age of the person!");
                        int person_age2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Last thing to do, please enter the nationality of the person!");
                        string person_nat2 = Console.ReadLine();

                        rest.Put(new Person()
                        {
                            Person_Id = personOwnId2,
                            Name = person_name2,
                            Age = person_age2,
                            Nationality = person_nat2
                        }, "person");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have successfully updated the person's data!");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        PrintingMethod();

                        break;


                    case "9":

                        Console.WriteLine("First of all, please enter the ID of the writer whose data you want to update!");
                        int writerOwnId2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Next, please enter the name of the writer!");
                        string writer_name2 = Console.ReadLine();

                        Console.WriteLine("Next, please enter the age of the writer!");
                        int writer_age2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Last thing to do, please enter the nationality of the writer!");
                        string writer_nat2 = Console.ReadLine();

                        rest.Put(new Writer()
                        {
                            Writer_Id = writerOwnId2,
                            Name = writer_name2,
                            Age = writer_age2,
                            Nationality = writer_nat2
                        }, "writer");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have successfully updated the writer's data!");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        PrintingMethod();

                        break;


                    case "10":
                        Console.WriteLine("Please enter the ID of a book which you want to delete!");
                        int idBook = int.Parse(Console.ReadLine());
                        rest.Delete(idBook, "book");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have successfully deleted the book which ID was: "+idBook);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        PrintingMethod();
                        break;


                    case "11":
                        Console.WriteLine("Please enter the ID of a person which you want to delete!");
                        int idPerson = int.Parse(Console.ReadLine());
                        rest.Delete(idPerson, "person");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have successfully deleted the person whose ID was: " + idPerson);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        PrintingMethod();
                        break;


                    case "12":
                        Console.WriteLine("Please enter the ID of a writer which you want to delete!");
                        int idWriter = int.Parse(Console.ReadLine());
                        rest.Delete(idWriter, "writer");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You have successfully deleted the writer whose ID was: " + idWriter);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        PrintingMethod();
                        break;


                    case "13":
                        var hunreaders = rest.Get<KeyValuePair<string, int>>("stat/hungarianreaders");
                        foreach (KeyValuePair<string, int> kvp in hunreaders)
                        {
                            Console.WriteLine("|| The reader's name: {0,-8} | Number of borrowed books: {1,2} ||", kvp.Key, kvp.Value);
                        }
                        Console.WriteLine();
                        PrintingMethod();
                        break;


                    case "14":                 
                        var howmanyunder = rest.Get<KeyValuePair<string, int>>("stat/howmanybooksdotheyreadunder18");
                        foreach (KeyValuePair<string, int> kvp in howmanyunder)
                        {
                            Console.WriteLine("|| The reader's name: {0,-8} | Number of borrowed books: {1,2} ||", kvp.Key, kvp.Value);
                        }
                        Console.WriteLine();
                        PrintingMethod();
                        break;


                    case "15":
                        var lastbook = rest.Get<KeyValuePair<string, int>>("stat/latestpublishedbooksbygeorges");
                        foreach (KeyValuePair<string, int> kvp in lastbook)
                        {
                            Console.WriteLine("|| Author's name: {0,-20} | The year it was published: {1,2} ||", kvp.Key, kvp.Value);
                        }
                        Console.WriteLine();
                        PrintingMethod();
                        break;


                    case "16":
                        var autobios = rest.Get<KeyValuePair<string, string>>("stat/autobiographiesbytitle");
                        foreach (KeyValuePair<string, string> kvp in autobios)
                        {
                            Console.WriteLine("|| Author's name: {0,-13} | Genre: {1,-10} ||", kvp.Key, kvp.Value);
                        }
                        Console.WriteLine();
                        PrintingMethod();
                        break;


                    case "17":
                        var top2 = rest.Get<KeyValuePair<string, int>>("stat/top2productivewriters");
                        foreach (KeyValuePair<string, int> kvp in top2)
                        {
                            Console.WriteLine(string.Format("|| Author's name: {0,-13} | Number of published books: {1,1} ||", kvp.Key, kvp.Value));
                        }
                        Console.WriteLine();
                        PrintingMethod();
                        break;


                    case "stop":
                    default:
                      stop = false;
                          break;
                }
            }

            
            #endregion userinterface

        }



        static void PrintingMethod() 
        {
            Console.WriteLine();
            Console.WriteLine("Please choose an option!");
            Console.WriteLine("Type a number from 1 to 17!");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[1]---Listing the books");
            Console.WriteLine("[2]---Listing the people");
            Console.WriteLine("[3]---Listing the writers");

            Console.WriteLine("[4]---Adding a new book");
            Console.WriteLine("[5]---Adding a new person");
            Console.WriteLine("[6]---Adding a new writer");

            Console.WriteLine("[7]---Updating an already existing book");
            Console.WriteLine("[8]---Updating an already existing person");
            Console.WriteLine("[9]---Updating an already existing writer");

            Console.WriteLine("[10]--Deleting an already existing book");
            Console.WriteLine("[11]--Deleting an already existing person"); //it is not what you might think it is
            Console.WriteLine("[12]--Deleting an already existing writer"); //it is not what you might think it is

            Console.WriteLine("[13]--Listing the hungarian readers");
            Console.WriteLine("[14]--Listing how many books the people read under 18");
            Console.WriteLine("[15]--Listing the latest books published by writers whose name is George");
            Console.WriteLine("[16]--Listing those books which genre is Autobiography");
            Console.WriteLine("[17]--Listing the 2 most productive writers");
            Console.WriteLine("Type 'stop' if you want to exit.");

            Console.WriteLine();
        }
    }
}
