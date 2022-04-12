using FW008L_HFT_2021221.Logic;
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
        IBookLogic bl;
        IWriterLogic wl;
        IPersonLogic pl;


        //restcollections 
        public RestCollection<Book> Books { get; set; }
        public RestCollection<Writer> Writers { get; set; }
        public RestCollection<Person> People { get; set; }

        private Book selectedBook;
        private Writer selectedWriter;
        private Person selectedPerson;

        //public IEnumerable<KeyValuePair<string, int>> Autosw
        //{
        //    get
        //    {
        //        return (IEnumerable<KeyValuePair<string, int>>)bl.AutobiographiesByTitle();
        //    }
        //}



        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                if (value != null)
                {
                    selectedBook = new Book()
                    {
                        Book_Id = value.Book_Id, //ez kell DELETE miatt
                        Title = value.Title,
                        Published = value.Published,
                        Genre = value.Genre,
                        //Person = value.Person,
                        Person_Id = value.Person_Id,
                        //Writer = value.Writer,
                        Writer_Id = value.Writer_Id
                    };
                    OnPropertyChanged();
                    (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public Writer SelectedWriter
        {
            get { return selectedWriter; }
            set
            {
                if (value != null)
                {
                    selectedWriter = new Writer()
                    {
                        Writer_Id = value.Writer_Id, //ez kell DELETE miatt
                        Name = value.Name,
                        Age = value.Age,
                        Nationality = value.Nationality,
                        Books = value.Books
                    };
                    OnPropertyChanged();
                    (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                if (value != null)
                {
                    selectedPerson = new Person()
                    {
                        Person_Id = value.Person_Id, //ez kell DELETE miatt
                        Name = value.Name,
                        Age = value.Age,
                        Nationality = value.Nationality,
                        Books = value.Books
                    };
                    OnPropertyChanged();
                    (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        //commands for books
        public ICommand CreateBookCommand { get; set; }
        public ICommand UpdateBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }

        //commands for writers
        public ICommand CreateWriterCommand { get; set; }
        public ICommand UpdateWriterCommand { get; set; }
        public ICommand DeleteWriterCommand { get; set; }

        //commands for people
        public ICommand CreatePersonCommand { get; set; }
        public ICommand UpdatePersonCommand { get; set; }
        public ICommand DeletePersonCommand { get; set; }


        //IsInDesignMode for wpf window
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        //public ctor
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Books = new RestCollection<Book>("http://localhost:48920/", "book");
                Writers = new RestCollection<Writer>("http://localhost:48920/", "writer");
                People = new RestCollection<Person>("http://localhost:48920/", "person");

                //commands for books
                CreateBookCommand = new RelayCommand(() =>
                {
                    Books.Add(new Book()
                    {
                        Title = SelectedBook.Title,
                        Published = SelectedBook.Published,
                        Genre = SelectedBook.Genre,
                        Person_Id = null,
                        Writer_Id = SelectedBook.Writer_Id
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


                //commands for writers
                CreateWriterCommand = new RelayCommand(() =>
                {
                    Writers.Add(new Writer()
                    {
                        Name = SelectedWriter.Name,
                        Age = SelectedWriter.Age,
                        Nationality = SelectedWriter.Nationality,
                        //Books = SelectedWriter.Books
                    });
                });

                UpdateWriterCommand = new RelayCommand(() =>
                {
                    Writers.Update(SelectedWriter);
                });

                DeleteWriterCommand = new RelayCommand(() =>
                {
                    Writers.Delete(SelectedWriter.Writer_Id);
                },
                () =>
                {
                    return SelectedWriter != null;
                });
                SelectedWriter = new Writer();


                //commands for people
                CreatePersonCommand = new RelayCommand(() =>
                {
                    People.Add(new Person()
                    {
                        Name = SelectedPerson.Name,
                        Age = SelectedPerson.Age,
                        Nationality = SelectedPerson.Nationality,
                        //Books = SelectedPerson.Books
                    });
                });

                UpdatePersonCommand = new RelayCommand(() =>
                {
                    People.Update(SelectedPerson);
                });

                DeletePersonCommand = new RelayCommand(() =>
                {
                    People.Delete(SelectedPerson.Person_Id);
                },
                () =>
                {
                    return SelectedPerson != null;
                });
                SelectedPerson = new Person();
            }
        }


    }
}
