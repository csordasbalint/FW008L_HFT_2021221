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
                .OnDelete(DeleteBehavior.Restrict);

                entity
               .HasOne(book => book.Person)
               .WithMany(person => person.Books)
               .HasForeignKey(book => book.Person_Id)
               .OnDelete(DeleteBehavior.Restrict);
            });


            Person testP = new Person() { Person_Id = 1, Name = "pálteszt", Age = 51, Nationality = "hungarian" };

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
            Writer erichKastner = new Writer() { Writer_Id = 13, Name = "Erich Kästner", Age = 75, Nationality = "German" };  //zwei lotti ja
            Writer franzKafka = new Writer() { Writer_Id = 14, Name = "Franz Kafka", Age = 40, Nationality = "Czech" };
            Writer jamesJoyce = new Writer() { Writer_Id = 15, Name = "James Joyce", Age = 58, Nationality = "Irish" };
            Writer levNyTolsztoj = new Writer() { Writer_Id = 16, Name = "Lev Ny. Tolsztoj", Age = 82, Nationality = "Russian" };
            Writer alekszandrPuskin = new Writer() { Writer_Id = 17, Name = "Alekszandr Puskin", Age = 37, Nationality = "Russian" };
            Writer victorHugo = new Writer() { Writer_Id = 18, Name = "Victor Hugo", Age = 83, Nationality = "French" };
            Writer antonPCsehov = new Writer() { Writer_Id = 19, Name = "Anton Pavlovics Csehov", Age = 44, Nationality = "Russian" };
            #endregion writers


            #region books
            Book edd1 = new Book() { Book_Id = 1, Title = "Grease Junkie", Published = 2015, Genre = "Autobiography", Writer_Id = eddChina.Writer_Id, Person_Id = testP.Person_Id };

            Book george1 = new Book() { Book_Id = 2, Title = "1984", Published = 1949, Genre = "Political novel", Writer_Id = georgeOrwell.Writer_Id, Person_Id = testP.Person_Id };
            Book george2 = new Book() { Book_Id = 3, Title = "Animal Farm: A Fairy Story", Published = 1945, Genre = "Satire", Writer_Id = georgeOrwell.Writer_Id, Person_Id = testP.Person_Id };
            Book george3 = new Book() { Book_Id = 4, Title = "Down and Out in Paris and London", Published = 1933, Genre = "Memoir", Writer_Id = georgeOrwell.Writer_Id, Person_Id = testP.Person_Id };

            Book ernest1 = new Book() { Book_Id = 5, Title = "In Our Time", Published = 1925, Genre = "Short story collection", Writer_Id = ernestHemingway.Writer_Id, Person_Id = testP.Person_Id };
            Book ernest2 = new Book() { Book_Id = 6, Title = "The Sun Also Rises", Published = 1926, Genre = "Novel", Writer_Id = ernestHemingway.Writer_Id, Person_Id = testP.Person_Id };
            Book ernest3 = new Book() { Book_Id = 7, Title = "A Farewell to Arms", Published = 1929, Genre = "Realism", Writer_Id = ernestHemingway.Writer_Id, Person_Id = testP.Person_Id };
            Book ernest4 = new Book() { Book_Id = 8, Title = "The Old Man and the Sea", Published = 1952, Genre = "Literary Fiction", Writer_Id = ernestHemingway.Writer_Id, Person_Id = testP.Person_Id };

            Book jkRowling1 = new Book() { Book_Id = 9, Title = "Fantastic Beasts & Where to Find Them", Published = 2001, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = testP.Person_Id };
            Book jkRowling2 = new Book() { Book_Id = 10, Title = "Harry Potter and the Philosopher’s Stone", Published = 1997, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = testP.Person_Id };
            Book jkRowling3 = new Book() { Book_Id = 11, Title = "Harry Potter and the Chamber of Secrets", Published = 1998, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = testP.Person_Id };
            Book jkRowling4 = new Book() { Book_Id = 12, Title = "Harry Potter and the Prisoner of Azkaban", Published = 1999, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = testP.Person_Id };
            Book jkRowling5 = new Book() { Book_Id = 13, Title = "Harry Potter and the Goblet of Fire", Published = 2000, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = testP.Person_Id };
            Book jkRowling6 = new Book() { Book_Id = 14, Title = "Harry Potter and the Order of the Phoenix", Published = 2003, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = testP.Person_Id };
            Book jkRowling7 = new Book() { Book_Id = 15, Title = "Harry Potter and the Half-Blood Prince", Published = 2005, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = testP.Person_Id };
            Book jkRowling8 = new Book() { Book_Id = 16, Title = "Harry Potter and the Deathly Hallows", Published = 2007, Genre = "Fantasy", Writer_Id = jkRowling.Writer_Id, Person_Id = testP.Person_Id };

            Book georgeRR1 = new Book() { Book_Id = 17, Title = "Game of Thrones", Published = 1996, Genre = "Fantasy", Writer_Id = georgeRRMartin.Writer_Id, Person_Id = testP.Person_Id };
            Book georgeRR2 = new Book() { Book_Id = 18, Title = "Clash of Kings", Published = 1998, Genre = "Fantasy", Writer_Id = georgeRRMartin.Writer_Id, Person_Id = testP.Person_Id };
            Book georgeRR3 = new Book() { Book_Id = 19, Title = "Storm of Swords", Published = 2000, Genre = "Fantasy", Writer_Id = georgeRRMartin.Writer_Id, Person_Id = testP.Person_Id };
            Book georgeRR4 = new Book() { Book_Id = 20, Title = "Feast for Crows", Published = 2005, Genre = "Fantasy", Writer_Id = georgeRRMartin.Writer_Id, Person_Id = testP.Person_Id };
            Book georgeRR5 = new Book() { Book_Id = 21, Title = "Dance with Dragons", Published = 2011, Genre = "Fantasy", Writer_Id = georgeRRMartin.Writer_Id, Person_Id = testP.Person_Id };

            Book agatha1 = new Book() { Book_Id = 22, Title = "Murder on the Orient Express", Published = 1934, Genre = "Crime novel", Writer_Id = agathaChristie.Writer_Id, Person_Id = testP.Person_Id };
            Book agatha2 = new Book() { Book_Id = 23, Title = "Sad Cypress", Published = 1940, Genre = "Crime novel", Writer_Id = agathaChristie.Writer_Id, Person_Id = testP.Person_Id };
            Book agatha3 = new Book() { Book_Id = 24, Title = "Endless Night", Published = 1967, Genre = "Crime novel", Writer_Id = agathaChristie.Writer_Id, Person_Id = testP.Person_Id };
            Book agatha4 = new Book() { Book_Id = 25, Title = "Five Little Pigs", Published = 1942, Genre = "Crime novel", Writer_Id = agathaChristie.Writer_Id, Person_Id = testP.Person_Id };

            Book jrrtolkien1 = new Book() { Book_Id = 26, Title = "The Fellowship of the Ring", Published = 1954, Genre = "Fantasy", Writer_Id = jrrTolkien.Writer_Id, Person_Id = testP.Person_Id };
            Book jrrtolkien2 = new Book() { Book_Id = 27, Title = "The Two Towers", Published = 1954, Genre = "Fantasy", Writer_Id = jrrTolkien.Writer_Id, Person_Id = testP.Person_Id };
            Book jrrtolkien3 = new Book() { Book_Id = 28, Title = "The Return of the King", Published = 1955, Genre = "Fantasy", Writer_Id = jrrTolkien.Writer_Id, Person_Id = testP.Person_Id };






            #endregion books




            modelBuilder.Entity<Writer>().HasData(eddChina,georgeOrwell, ernestHemingway, jkRowling, georgeRRMartin,
            agathaChristie, jrrTolkien, molnarFerenc, moriczZsigmond, jokaiMor, mikszathKalman, gunterGrass, 
            erichKastner, franzKafka, jamesJoyce, levNyTolsztoj, alekszandrPuskin, victorHugo, antonPCsehov);

            modelBuilder.Entity<Book>().HasData(edd1, george1, george2, george3, ernest1, ernest2, ernest3, ernest4,
            jkRowling1, jkRowling2, jkRowling3, jkRowling4, jkRowling5, jkRowling6, jkRowling7, jkRowling8,
            georgeRR1, georgeRR2, georgeRR3, georgeRR4, georgeRR5, agatha1, agatha2, agatha3, agatha4,
            jrrtolkien1,jrrtolkien2,jrrtolkien3);


            modelBuilder.Entity<Person>().HasData(testP);
        }




    }
}
