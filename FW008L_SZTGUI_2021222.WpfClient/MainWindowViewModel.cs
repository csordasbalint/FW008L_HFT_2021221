using FW008L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_SZTGUI_2021222.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Book> Books { get; set; }

        public MainWindowViewModel()
        {
            Books = new RestCollection<Book>("http://localhost:48920/","book");
        }

    }
}
