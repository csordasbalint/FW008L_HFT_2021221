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


            rest.Post<Person>(new Person() 
            {
                Name = "Testing Ted",
                Nationality = "Spanish",
                Age = 35,

            }, "person");


            var people = rest.Get<Person>("person");
            var books = rest.Get<Book>("book");

            var  lastbook = rest.Get<KeyValuePair<string, int>>("stat/latestpublishedbooksbygeorges");


            

            //TESZT-----------------------------------------------------------------------


            #region userinterface
            Console.Title = "Lukste Library";

            string welcomeText = "~~  Welcome!  ~~";
            Console.SetCursorPosition((Console.WindowWidth - welcomeText.Length) / 2, Console.CursorTop); //setting welcometext to the middle
            Console.WriteLine(welcomeText);
            Console.WriteLine();

            Console.WriteLine("Please choose an option!");
            Console.WriteLine("Type a number from 1 to 17!");

            Console.WriteLine();
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            

            Console.WriteLine(string.Format("|| { 0,-20} ",numbers);



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


            int answer = int.Parse(Console.ReadLine());
            if (answer == 1)
            {
                foreach (Person item in people)
                {
                    Console.WriteLine(people); // nicht gut
                }
            }
            else if (answer == 2)
            {

            }
            else if (answer == 3)
            {

            }
            else if (answer == 4)
            {

            }
            else if (answer == 5)
            {

            }
            else if (answer == 6)
            {

            }
            else if (answer == 7)
            {
                
            }
            else if (answer == 8)
            {

            }
            else if (answer == 9)
            {

            }
            else if (answer == 10)
            {

            }
            else if (answer == 11)
            {

            }
            else if (answer == 12)
            {

            }
            else if (answer == 13)
            {

            }
            else if (answer == 14)
            {

            }
            else if (answer == 15)
            {
                foreach (KeyValuePair<string, int> kvp in lastbook)
                {
                    Console.WriteLine("Author's name : {0,-20} || || The year it was published : {1,-20}",
                        kvp.Key, kvp.Value);
                }
            }
            else if (answer == 16)
            {

            }
            else if (answer == 17)
            {

            }
            else
            {
                Console.WriteLine("error, jo szam kell");
            }



            Console.ReadLine();
            #endregion userinterface

            ;



















        }

    }
}
