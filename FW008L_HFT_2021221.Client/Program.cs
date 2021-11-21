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

            Console.WriteLine();
            Console.WriteLine("TESZTELÉS");
            foreach (KeyValuePair<string, int> kvp in lastbook)
            {
                Console.WriteLine("Author's name : {0,-20} || || The year it was published : {1,-20}",
                    kvp.Key, kvp.Value);
            }





            //TESZT-----------------------------------------------------------------------


            #region userinterface
            Console.Title = "Lukste Library";

            string welcomeText = "~~  Welcome!  ~~";
            Console.SetCursorPosition((Console.WindowWidth - welcomeText.Length) / 2, Console.CursorTop); //setting welcometext to the middle
            Console.WriteLine(welcomeText);
            Console.WriteLine();

            Console.WriteLine("Please choose an option!");
            Console.WriteLine("Type 1-10 a number.");
            Console.WriteLine("[1]--Listing the books");
            Console.WriteLine("[2]--Listing the people");
            Console.WriteLine("[3]--Listing the writers");

            int answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                        foreach (var item in books)
                        {
                            Console.WriteLine(item);
                        }
                break;



               

            }
            Console.ReadLine();

            #endregion userinterface

            ;



















        }

    }
}
