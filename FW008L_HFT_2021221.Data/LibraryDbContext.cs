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

           


            Book fisrtbook = new Book() { Book_Id = 1, Title = "Grease Junkie", Published=2015, Genre="Autobiography", Writer_Id=eddChina.Writer_Id, Person_Id=testP.Person_Id};
            
            

            //Brand bmw = new Brand() { Id = 1, Name = "BMW" };
            //Brand citroen = new Brand() { Id = 2, Name = "Citroen" };
            //Brand audi = new Brand() { Id = 3, Name = "Audi" };

            //Car bmw1 = new Car() { Id = 1, BrandId = bmw.Id, BasePrice = 20000, Model = "BMW 116d" };
            //Car bmw2 = new Car() { Id = 2, BrandId = bmw.Id, BasePrice = 30000, Model = "BMW 510" };
            //Car citroen1 = new Car() { Id = 3, BrandId = citroen.Id, BasePrice = 10000, Model = "Citroen C1" };
            //Car citroen2 = new Car() { Id = 4, BrandId = citroen.Id, BasePrice = 15000, Model = "Citroen C3" };
            //Car audi1 = new Car() { Id = 5, BrandId = audi.Id, BasePrice = 20000, Model = "Audi A3" };
            //Car audi2 = new Car() { Id = 6, BrandId = audi.Id, BasePrice = 25000, Model = "Audi A4" };

            //modelBuilder.Entity<Brand>().HasData(bmw, citroen, audi);
            //modelBuilder.Entity<Car>().HasData(bmw1, bmw2, citroen1, citroen2, audi1, audi2);

            modelBuilder.Entity<Writer>().HasData(eddChina,georgeOrwell, ernestHemingway, jkRowling, georgeRRMartin,
            agathaChristie, jrrTolkien, molnarFerenc, moriczZsigmond, jokaiMor, mikszathKalman, gunterGrass, 
            erichKastner, franzKafka, jamesJoyce, levNyTolsztoj, alekszandrPuskin, victorHugo, antonPCsehov);

            modelBuilder.Entity<Book>().HasData(fisrtbook);
            modelBuilder.Entity<Person>().HasData(testP);
        }




    }
}
