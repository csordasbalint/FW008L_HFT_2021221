using FW008L_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Data
{
    public class LibraryDbContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Writer> Writers { get; set; }

        public LibraryDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataBase1.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity
                .HasOne(book => book.Writer)
                .WithMany(writer => writer.Books)
                .HasForeignKey(book => book.Writer_Id)
                .OnDelete(DeleteBehavior.Cascade);

                entity
               .HasOne(book => book.Person)
               .WithMany(person => person.Books)
               .HasForeignKey(book => book.Person_Id)
               .OnDelete(DeleteBehavior.Cascade);
            });


            #region people
            Person andrew = new Person() { Person_Id = 1, Name = "Andrew", Age = 15, Nationality = "English" };
            Person arvid = new Person() { Person_Id = 2, Name = "Arvid", Age = 22, Nationality = "Norwegian" };
            Person ben = new Person() { Person_Id = 3, Name = "Ben", Age = 31, Nationality = "German" };
            Person bella = new Person() { Person_Id = 4, Name = "Bella", Age = 19, Nationality = "Australian" };
            Person chloe = new Person() { Person_Id = 5, Name = "Chloe", Age = 25, Nationality = "Greek" };
            Person cara = new Person() { Person_Id = 6, Name = "Cara", Age = 22, Nationality = "Italian" };
            Person dominic = new Person() { Person_Id = 7, Name = "Dominic", Age = 21, Nationality = "Hungarian" };
            Person dlyan = new Person() { Person_Id = 8, Name = "Dylan", Age = 63, Nationality = "Welsh" };
            Person freya = new Person() { Person_Id = 9, Name = "Freya", Age = 43, Nationality = "Norwegian" };
            Person fraser = new Person() { Person_Id = 10, Name = "Fraser", Age = 29, Nationality = "French" };
            Person james = new Person() { Person_Id = 11, Name = "James", Age = 15, Nationality = "Hungarian" };
            Person max = new Person() { Person_Id = 12, Name = "Max", Age = 27, Nationality = "Danish" };
            Person pablo = new Person() { Person_Id = 13, Name = "Pablo", Age = 17, Nationality = "Spanish" };
            Person rostislav = new Person() { Person_Id = 14, Name = "Rostislav", Age = 45, Nationality = "Russian" };
            Person sumiko = new Person() { Person_Id = 15, Name = "Sumiko", Age = 23, Nationality = "Japanese" };
            Person tao = new Person() { Person_Id = 16, Name = "Tao", Age = 55, Nationality = "Chinese" };
            Person ursula = new Person() { Person_Id = 17, Name = "Ursula", Age = 40, Nationality = "Swiss" };
            Person victor = new Person() { Person_Id = 18, Name = "Victor", Age = 34, Nationality = "Hungarian" };
            Person whitt = new Person() { Person_Id = 19, Name = "Whitt", Age = 54, Nationality = "American" };
            Person jesper = new Person() { Person_Id = 20, Name = "Jesper ", Age = 47, Nationality = "Icelandic" };
            Person patricio = new Person() { Person_Id = 21, Name = "Patricio", Age = 38, Nationality = "Portuguese" };
            Person ras = new Person() { Person_Id = 22, Name = "Ras", Age = 20, Nationality = "Dutch" };
            Person flamur = new Person() { Person_Id = 23, Name = "Flamur", Age = 54, Nationality = "Italian" };
            Person herbert = new Person() { Person_Id = 24, Name = "Herbert", Age = 16, Nationality = "German" };
            #endregion people


            #region writers
            Writer eddChina = new Writer() { Writer_Id = 1, Name = "Edd China", Age = 50, Nationality = "English"};
            Writer georgeOrwell = new Writer() { Writer_Id = 2, Name = "George Orwell", Age = 46, Nationality = "Indian" };
            Writer ernestHemingway = new Writer() { Writer_Id = 3, Name = "Ernest Hemingway", Age = 61, Nationality = "American" };
            Writer jkRowling = new Writer() { Writer_Id = 4, Name = "J. K. Rowling", Age = 56, Nationality = "English" };
            Writer georgeRRMartin = new Writer() { Writer_Id = 5, Name = "George R. R. Martin", Age = 73, Nationality = "American" };
            Writer agathaChristie = new Writer() { Writer_Id = 6, Name = "Agatha Christie", Age = 85, Nationality = "English" };
            Writer jrrTolkien = new Writer() { Writer_Id = 7, Name = "J. R. R. Tolkien", Age = 81, Nationality = "English" };
            Writer molnarFerenc = new Writer() { Writer_Id = 8, Name = "Molnár Ferenc", Age = 74, Nationality = "Hungarian" };
            Writer moriczZsigmond = new Writer() { Writer_Id = 9, Name = "Móricz Zsigmond", Age = 63, Nationality = "Hungarian" };
            Writer jokaiMor = new Writer() { Writer_Id = 10, Name = "Jókai Mór", Age = 79, Nationality = "Hungarian" };
            Writer mikszathKalman = new Writer() { Writer_Id = 11, Name = "Mikszáth Kálmán", Age = 63, Nationality = "Hungarian" };
            Writer gunterGrass = new Writer() { Writer_Id = 12, Name = "Günter Grass", Age = 87, Nationality = "German" };
            Writer erichKastner = new Writer() { Writer_Id = 13, Name = "Erich Kästner", Age = 75, Nationality = "German" };
            Writer franzKafka = new Writer() { Writer_Id = 14, Name = "Franz Kafka", Age = 40, Nationality = "Czech" };
            Writer jamesJoyce = new Writer() { Writer_Id = 15, Name = "James Joyce", Age = 58, Nationality = "Irish" };
            Writer levNyTolsztoj = new Writer() { Writer_Id = 16, Name = "Lev Ny. Tolsztoj", Age = 82, Nationality = "Russian" };
            Writer alekszandrPuskin = new Writer() { Writer_Id = 17, Name = "Alekszandr Puskin", Age = 37, Nationality = "Russian" };
            Writer victorHugo = new Writer() { Writer_Id = 18, Name = "Victor Hugo", Age = 83, Nationality = "French" };
            Writer antonPCsehov = new Writer() { Writer_Id = 19, Name = "Anton Pavlovics Csehov", Age = 44, Nationality = "Russian" };
            #endregion writers


            #region books
            Book edd1 = new Book() { Book_Id = 1, Title = "Grease Junkie", Published = 2015, Genre = "Autobiography", Writer_Id = eddChina.Writer_Id, Person_Id = james.Person_Id };

            Book george1 = new Book() { Book_Id = 2, Title = "1984", Published = 1949, Genre = "Political novel", Writer_Id = georgeOrwell.Writer_Id, Person_Id = freya.Person_Id };
            Book george2 = new Book() { Book_Id = 3, Title = "Animal Farm: A Fairy Story", Published = 1945, Genre = "Satire", Writer_Id = georgeOrwell.Writer_Id, Person_Id = ben.Person_Id };
            Book george3 = new Book() { Book_Id = 4, Title = "Down and Out in Paris and London", Published = 1933, Genre = "Memoir", Writer_Id = georgeOrwell.Writer_Id, Person_Id = fraser.Person_Id };

            Book ernest1 = new Book() { Book_Id = 5, Title = "In Our Time", Published = 1925, Genre = "Short story collection", Writer_Id = ernestHemingway.Writer_Id, Person_Id = dlyan.Person_Id };
            Book ernest2 = new Book() { Book_Id = 6, Title = "The Sun Also Rises", Published = 1926, Genre = "Novel", Writer_Id = ernestHemingway.Writer_Id, Person_Id = freya.Person_Id };
            Book ernest3 = new Book() { Book_Id = 7, Title = "A Farewell to Arms", Published = 1929, Genre = "Realism", Writer_Id = ernestHemingway.Writer_Id, Person_Id = pablo.Person_Id };
            Book ernest4 = new Book() { Book_Id = 8, Title = "The Old Man and the Sea", Published = 1952, Genre = "Literary Fiction", Writer_Id = ernestHemingway.Writer_Id, Person_Id = max.Person_Id };

            Book jkRowling1 = new Book() { Book_Id = 9, Title = "Fantastic Beasts & Where to Find Them", Published = 2001, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = null };
            Book jkRowling2 = new Book() { Book_Id = 10, Title = "Harry Potter and the Philosopher’s Stone", Published = 1997, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = tao.Person_Id };
            Book jkRowling3 = new Book() { Book_Id = 11, Title = "Harry Potter and the Chamber of Secrets", Published = 1998, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = max.Person_Id };
            Book jkRowling4 = new Book() { Book_Id = 12, Title = "Harry Potter and the Prisoner of Azkaban", Published = 1999, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = ursula.Person_Id };
            Book jkRowling5 = new Book() { Book_Id = 13, Title = "Harry Potter and the Goblet of Fire", Published = 2000, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = sumiko.Person_Id};
            Book jkRowling6 = new Book() { Book_Id = 14, Title = "Harry Potter and the Order of the Phoenix", Published = 2003, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = null };
            Book jkRowling7 = new Book() { Book_Id = 15, Title = "Harry Potter and the Half-Blood Prince", Published = 2005, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = victor.Person_Id };
            Book jkRowling8 = new Book() { Book_Id = 16, Title = "Harry Potter and the Deathly Hallows", Published = 2007, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = arvid.Person_Id };

            Book georgeRR1 = new Book() { Book_Id = 17, Title = "Game of Thrones", Published = 1996, Genre = "Fantasy", Writer_Id = georgeRRMartin.Writer_Id, Person_Id = tao.Person_Id };
            Book georgeRR2 = new Book() { Book_Id = 18, Title = "Clash of Kings", Published = 1998, Genre = "Fantasy", Writer_Id = georgeRRMartin.Writer_Id, Person_Id = null };
            Book georgeRR3 = new Book() { Book_Id = 19, Title = "Storm of Swords", Published = 2000, Genre = "Fantasy", Writer_Id = georgeRRMartin.Writer_Id, Person_Id = sumiko.Person_Id };
            Book georgeRR4 = new Book() { Book_Id = 20, Title = "Feast for Crows", Published = 2005, Genre = "Fantasy", Writer_Id = georgeRRMartin.Writer_Id, Person_Id = ursula.Person_Id };
            Book georgeRR5 = new Book() { Book_Id = 21, Title = "Dance with Dragons", Published = 2011, Genre = "Fantasy", Writer_Id = georgeRRMartin.Writer_Id, Person_Id = null };

            Book agatha1 = new Book() { Book_Id = 22, Title = "Murder on the Orient Express", Published = 1934, Genre = "Crime novel", Writer_Id = agathaChristie.Writer_Id, Person_Id = jesper.Person_Id };
            Book agatha2 = new Book() { Book_Id = 23, Title = "Sad Cypress", Published = 1940, Genre = "Crime novel", Writer_Id = agathaChristie.Writer_Id, Person_Id = null };
            Book agatha3 = new Book() { Book_Id = 24, Title = "Endless Night", Published = 1967, Genre = "Crime novel", Writer_Id = agathaChristie.Writer_Id, Person_Id = andrew.Person_Id };
            Book agatha4 = new Book() { Book_Id = 25, Title = "Five Little Pigs", Published = 1942, Genre = "Crime novel", Writer_Id = agathaChristie.Writer_Id, Person_Id = chloe.Person_Id };

            Book jrrtolkien1 = new Book() { Book_Id = 26, Title = "The Fellowship of the Ring", Published = 1954, Genre = "Fantasy", Writer_Id = jrrTolkien.Writer_Id, Person_Id = max.Person_Id };
            Book jrrtolkien2 = new Book() { Book_Id = 27, Title = "The Two Towers", Published = 1954, Genre = "Fantasy", Writer_Id = jrrTolkien.Writer_Id, Person_Id = jesper.Person_Id };
            Book jrrtolkien3 = new Book() { Book_Id = 28, Title = "The Return of the King", Published = 1955, Genre = "Fantasy", Writer_Id = jrrTolkien.Writer_Id, Person_Id = null };

            Book molnarF1 = new Book() { Book_Id = 29, Title = "The Boys of Paul Street", Published = 1906, Genre = "Novel", Writer_Id = molnarFerenc.Writer_Id, Person_Id = dominic.Person_Id };

            Book moricz1 = new Book() { Book_Id = 30, Title = "Be Faithful Unto Death", Published = 1920, Genre = "Novel", Writer_Id = moriczZsigmond.Writer_Id, Person_Id = null };
            Book moricz2 = new Book() { Book_Id = 31, Title = "Behind God's Back", Published = 1917, Genre = "Novel", Writer_Id = moriczZsigmond.Writer_Id, Person_Id = whitt.Person_Id };
            Book moricz3 = new Book() { Book_Id = 32, Title = "Seven Pennies", Published = 1908, Genre = "Short-story", Writer_Id = moriczZsigmond.Writer_Id, Person_Id = cara.Person_Id };
            Book moricz4 = new Book() { Book_Id = 33, Title = "Just To Remain", Published = 1920, Genre = "Poem", Writer_Id = moriczZsigmond.Writer_Id, Person_Id = james.Person_Id };

            Book jokai1 = new Book() { Book_Id = 34, Title = "The Man with the Golden Touch", Published = 1872, Genre = "Novel", Writer_Id = jokaiMor.Writer_Id, Person_Id = max.Person_Id };
            Book jokai2 = new Book() { Book_Id = 35, Title = "The Baron’s Sons", Published = 1869, Genre = "Novel", Writer_Id = jokaiMor.Writer_Id, Person_Id = cara.Person_Id };
            Book jokai3 = new Book() { Book_Id = 36, Title = "The Corsair King", Published = 1886, Genre = "Romance Novel", Writer_Id = jokaiMor.Writer_Id, Person_Id = ben.Person_Id };
            Book jokai4 = new Book() { Book_Id = 37, Title = "Black diamonds", Published = 1870, Genre = "Novel", Writer_Id = jokaiMor.Writer_Id, Person_Id = pablo.Person_Id };

            Book mikszath1 = new Book() { Book_Id = 38, Title = "St. Peter's Umbrella", Published = 1895, Genre = "Novel", Writer_Id = mikszathKalman.Writer_Id, Person_Id = null };
            Book mikszath2 = new Book() { Book_Id = 39, Title = "The Siege of Beszterce", Published = 1894, Genre = "Novel", Writer_Id = mikszathKalman.Writer_Id, Person_Id = victor.Person_Id };
            Book mikszath3 = new Book() { Book_Id = 40, Title = "Strange Marriage", Published = 1901, Genre = "Novel", Writer_Id = mikszathKalman.Writer_Id, Person_Id = chloe.Person_Id };
            Book mikszath4 = new Book() { Book_Id = 41, Title = "The ​Good People of Palocz", Published = 1882, Genre = "Novel", Writer_Id = mikszathKalman.Writer_Id, Person_Id = arvid.Person_Id };

            Book gunter1 = new Book() { Book_Id = 42, Title = "The Tin Drum", Published = 1959, Genre = "Magic realism", Writer_Id = gunterGrass.Writer_Id, Person_Id = herbert.Person_Id };
            Book gunter2 = new Book() { Book_Id = 43, Title = "Cat and Mouse", Published = 1963, Genre = "Novel", Writer_Id = gunterGrass.Writer_Id, Person_Id = freya.Person_Id };
            Book gunter3 = new Book() { Book_Id = 44, Title = "Dog Years", Published = 1965, Genre = "Novel", Writer_Id = gunterGrass.Writer_Id, Person_Id = herbert.Person_Id };
            Book gunter4 = new Book() { Book_Id = 45, Title = "My Century", Published = 1999, Genre = "Fiction", Writer_Id = gunterGrass.Writer_Id, Person_Id = fraser.Person_Id };
            Book gunter5 = new Book() { Book_Id = 46, Title = "Peeling the Onion", Published = 2006, Genre = "Autobiography", Writer_Id = gunterGrass.Writer_Id, Person_Id = tao.Person_Id };

            Book erich1 = new Book() { Book_Id = 47, Title = "Emil and the Detectives", Published = 1929, Genre = "Fiction", Writer_Id = erichKastner.Writer_Id, Person_Id = flamur.Person_Id };
            Book erich2 = new Book() { Book_Id = 48, Title = "The Two Lottes", Published = 1949, Genre = "Novel", Writer_Id = erichKastner.Writer_Id, Person_Id = chloe.Person_Id };
            Book erich3 = new Book() { Book_Id = 49, Title = "Three Men in the Snow", Published = 1934, Genre = "Fiction", Writer_Id = erichKastner.Writer_Id, Person_Id = null };
            Book erich4 = new Book() { Book_Id = 50, Title = "The Animal Congress", Published = 1949, Genre = "Satire", Writer_Id = erichKastner.Writer_Id, Person_Id = pablo.Person_Id };

            Book franz1 = new Book() { Book_Id = 51, Title = "A Country Doctor", Published = 1917, Genre = "Short-story", Writer_Id = franzKafka.Writer_Id, Person_Id = dominic.Person_Id };
            Book franz2 = new Book() { Book_Id = 52, Title = "The Stoker", Published = 1913, Genre = "Short-story", Writer_Id = franzKafka.Writer_Id, Person_Id = ben.Person_Id };
            Book franz3 = new Book() { Book_Id = 53, Title = "The Judgment", Published = 1913, Genre = "Short-story", Writer_Id = franzKafka.Writer_Id, Person_Id = andrew.Person_Id };
            Book franz4 = new Book() { Book_Id = 54, Title = "In the Penal Colony", Published = 1919, Genre = "Short-story", Writer_Id = franzKafka.Writer_Id, Person_Id = ursula.Person_Id };
            Book franz5 = new Book() { Book_Id = 55, Title = "Metamorphosis", Published = 1915, Genre = "Allegorical novel", Writer_Id = franzKafka.Writer_Id, Person_Id = ras.Person_Id };
            Book franz6 = new Book() { Book_Id = 56, Title = "Before the Law", Published = 1915, Genre = "Parable", Writer_Id = franzKafka.Writer_Id, Person_Id = flamur.Person_Id };

            Book james1 = new Book() { Book_Id = 57, Title = "A Portrait of the Artist as a Young Man", Published = 1916, Genre = "Novel", Writer_Id = jamesJoyce.Writer_Id, Person_Id = null };
            Book james2 = new Book() { Book_Id = 58, Title = "Ulysses", Published = 1922, Genre = "Novel", Writer_Id = jamesJoyce.Writer_Id, Person_Id = ras.Person_Id };
            Book james3 = new Book() { Book_Id = 59, Title = "Stephen Hero", Published = 1944, Genre = "Novel", Writer_Id = jamesJoyce.Writer_Id, Person_Id = jesper.Person_Id };
            Book james4 = new Book() { Book_Id = 60, Title = "Finnegans Wake", Published = 1939, Genre = "Novel", Writer_Id = jamesJoyce.Writer_Id, Person_Id = sumiko.Person_Id };
            Book james5 = new Book() { Book_Id = 61, Title = "The Dead", Published = 1914, Genre = "Short-story", Writer_Id = jamesJoyce.Writer_Id, Person_Id = null };

            Book tolsztoj1 = new Book() { Book_Id = 62, Title = "Sevastopol Sketches", Published = 1855, Genre = "Short-story", Writer_Id = levNyTolsztoj.Writer_Id, Person_Id = null };
            Book tolsztoj2 = new Book() { Book_Id = 63, Title = "Boyhood", Published = 1854, Genre = "Novel", Writer_Id = levNyTolsztoj.Writer_Id, Person_Id = rostislav.Person_Id };
            Book tolsztoj3 = new Book() { Book_Id = 64, Title = "The Kingdom of God Is Within You", Published = 1894, Genre = "Fiction", Writer_Id = levNyTolsztoj.Writer_Id, Person_Id = bella.Person_Id };
            Book tolsztoj4 = new Book() { Book_Id = 65, Title = "The Awakening", Published = 1899, Genre = "Fiction", Writer_Id = levNyTolsztoj.Writer_Id, Person_Id = arvid.Person_Id };
            Book tolsztoj5 = new Book() { Book_Id = 66, Title = "A Confession", Published = 1882, Genre = "Fiction", Writer_Id = levNyTolsztoj.Writer_Id, Person_Id = dominic.Person_Id };

            Book alekszandr1 = new Book() { Book_Id = 67, Title = "Eugene Onegin", Published = 1825, Genre = "Novel", Writer_Id = alekszandrPuskin.Writer_Id, Person_Id = bella.Person_Id };
            Book alekszandr2 = new Book() { Book_Id = 68, Title = "The Captain's Daughter", Published = 1836, Genre = "Historical novel", Writer_Id = alekszandrPuskin.Writer_Id, Person_Id = arvid.Person_Id };
            Book alekszandr3 = new Book() { Book_Id = 69, Title = "The Queen of Spades", Published = 1834, Genre = "Short-story", Writer_Id = alekszandrPuskin.Writer_Id, Person_Id = null };
            Book alekszandr4 = new Book() { Book_Id = 70, Title = "The Bronze Horseman", Published = 1837, Genre = "Narrative novel", Writer_Id = alekszandrPuskin.Writer_Id, Person_Id = ras.Person_Id };

            Book victor1 = new Book() { Book_Id = 71, Title = "The Man Who Laughs", Published = 1869, Genre = "Novel", Writer_Id = victorHugo.Writer_Id, Person_Id = andrew.Person_Id };
            Book victor2 = new Book() { Book_Id = 72, Title = "Toilers of the Sea", Published = 1866, Genre = "Novel", Writer_Id = victorHugo.Writer_Id, Person_Id = rostislav.Person_Id };
            Book victor3 = new Book() { Book_Id = 73, Title = "The Last Day of a Condemned Man", Published = 1829, Genre = "Novel", Writer_Id = victorHugo.Writer_Id, Person_Id = ben.Person_Id };
            Book victor4 = new Book() { Book_Id = 74, Title = "Hans of Iceland", Published = 1823, Genre = "Fiction", Writer_Id = victorHugo.Writer_Id, Person_Id = null };

            Book anton1 = new Book() { Book_Id = 75, Title = "The Lady with the Dog", Published = 1899, Genre = "Fiction", Writer_Id = antonPCsehov.Writer_Id, Person_Id = rostislav.Person_Id };
            Book anton2 = new Book() { Book_Id = 76, Title = "Gooseberries", Published = 1898, Genre = "Short-story", Writer_Id = antonPCsehov.Writer_Id, Person_Id = james.Person_Id };
            Book anton3 = new Book() { Book_Id = 77, Title = "About Love", Published = 1898, Genre = "Short-story", Writer_Id = antonPCsehov.Writer_Id, Person_Id = fraser.Person_Id };
            Book anton4 = new Book() { Book_Id = 78, Title = "The Bet", Published = 1889, Genre = "Short-story", Writer_Id = antonPCsehov.Writer_Id, Person_Id = bella.Person_Id };
            #endregion books


            #region modelbuilders
            modelBuilder.Entity<Writer>().HasData(eddChina,georgeOrwell, ernestHemingway, jkRowling, georgeRRMartin,
            agathaChristie, jrrTolkien, molnarFerenc, moriczZsigmond, jokaiMor, mikszathKalman, gunterGrass, 
            erichKastner, franzKafka, jamesJoyce, levNyTolsztoj, alekszandrPuskin, victorHugo, antonPCsehov);


            modelBuilder.Entity<Book>().HasData(edd1, george1, george2, george3, ernest1, ernest2, ernest3, ernest4,
            jkRowling1, jkRowling2, jkRowling3, jkRowling4, jkRowling5, jkRowling6, jkRowling7, jkRowling8,
            georgeRR1, georgeRR2, georgeRR3, georgeRR4, georgeRR5, agatha1, agatha2, agatha3, agatha4,
            jrrtolkien1, jrrtolkien2, jrrtolkien3, molnarF1, moricz1, moricz2, moricz3, moricz4,
            jokai1, jokai2, jokai3, jokai4, mikszath1, mikszath2, mikszath3, mikszath4, gunter1, gunter2,
            gunter3, gunter4, gunter5, erich1, erich2, erich3, erich4, franz1, franz2, franz3, franz4, franz5, franz6,
            james1, james2, james3, james4, james5, tolsztoj1, tolsztoj2, tolsztoj3, tolsztoj4, tolsztoj5,
            alekszandr1, alekszandr2, alekszandr3, alekszandr4, victor1, victor2, victor3, victor4,
            anton1, anton2, anton3, anton4);


            modelBuilder.Entity<Person>().HasData(andrew, arvid, ben, bella, chloe, cara, dominic, dlyan,
            freya, fraser, james, max, pablo, rostislav, sumiko, tao, ursula, victor, whitt, jesper,
            patricio, ras, flamur, herbert);
            #endregion modelbuilders



        }




    }
}
