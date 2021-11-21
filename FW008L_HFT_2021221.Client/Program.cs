using FW008L_HFT_2021221.Models;
using System;
using System.Linq;

namespace FW008L_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:48920");  //base url copied from launchSettings.json file

            var people = rest.Get<Person>("person");
            var books = rest.Get<Book>("book");


            ;
        }
    }
}
