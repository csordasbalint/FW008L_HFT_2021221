using FW008L_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FW008L_SZTGUI_2021222.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Book> Books { get; set; }


        private Book selectedBook;
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                if (value != null)
                {
                    selectedBook = new Book()
                    {
                        Title = value.Title,
                        Published = value.Published,
                        Genre = value.Genre,
                        Person_Id = null,
                        Writer_Id = 1
                    };
                    OnPropertyChanged();
                    (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();

                }
            }
        }


        public ICommand CreateBookCommand { get; set; }
        public ICommand UpdateBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Books = new RestCollection<Book>("http://localhost:48920/", "book");
                CreateBookCommand = new RelayCommand(() =>
                {
                    Books.Add(new Book()
                    {
                        Title = SelectedBook.Title,
                        Published = SelectedBook.Published,
                        Genre = SelectedBook.Genre,
                        Person_Id = null,
                        Writer_Id = 1
                    });
                });

                UpdateBookCommand = new RelayCommand(() =>
                {
                    Books.Update(SelectedBook);
                });

                DeleteBookCommand = new RelayCommand(() =>
                {
                    Books.Delete(SelectedBook.Book_Id);
                },
                () =>
                {
                    return SelectedBook != null;
                });
                SelectedBook = new Book();
            }
        }


    }
}
