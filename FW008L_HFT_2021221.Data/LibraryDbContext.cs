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
            });

            Writer testW = new Writer() { Writer_Id = 1, Name = "bélateszt", Age = 55, Nationality = "hungarian"};
            Person testP = new Person() { Person_Id = 1, Name = "pálteszt", Age = 51, Nationality = "hungarian" };
            Book testB = new Book() { Book_Id = 1, Title = "test", Published=1995,Writer_Id=testW.Writer_Id,Person_Id=testP.Person_Id};
            


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

            modelBuilder.Entity<Writer>().HasData(testW);
            modelBuilder.Entity<Book>().HasData(testB);
            modelBuilder.Entity<Person>().HasData(testP);
        }




    }
}
