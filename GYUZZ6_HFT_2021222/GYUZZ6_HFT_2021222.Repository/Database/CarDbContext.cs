using GYUZZ6_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYUZZ6_HFT_2021222.Repository.Database
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Rent> Rents { get; set; }

        public CarDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Car.mdf;Integrated Security=True;";
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseInMemoryDatabase("mydb").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasOne(car => car.Brand)
                .WithMany(brand => brand.Cars)
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Rent>()
                .HasOne(rent => rent.Car)
                .WithMany(car => car.Rents)
                .HasForeignKey(rent => rent.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand(){ Id = 1, Name = "Tesla"},
                new Brand(){ Id = 2, Name = "Mercedes"},
                new Brand(){ Id = 3, Name = "Audi"},
                new Brand(){ Id = 4, Name = "Bmw"},
            });

            builder.Entity<Rent>().HasData(new Rent[]
            {
                new Rent(){ Id = 1, CarId = 1, RenterName = "Drew", Date = new DateTime(2018,03,24), RentTime = 5, Rating = 5},
                new Rent(){ Id = 2, CarId = 4, RenterName = "Randy", Date = new DateTime(2018,03,24), RentTime = 4, Rating = 3},
                new Rent(){ Id = 3, CarId = 1, RenterName = "Drew", Date = new DateTime(2018,03,24), RentTime = 3, Rating = 3},
                new Rent(){ Id = 4, CarId = 4, RenterName = "Drew", Date = new DateTime(2018,05,24), RentTime = 3, Rating = 4},
                new Rent(){ Id = 5, CarId = 1, RenterName = "Nick", Date = new DateTime(2019,03,24), RentTime = 1.5, Rating = 3.5},
            });

            builder.Entity<Car>().HasData(new Car[]
            {
                new Car(){ Id = 1, Model = "Tesla Model 3", BasePrice = 45000, BrandId = 1},
                new Car(){ Id = 2, Model = "Tesla Model Y", BasePrice = 60000, BrandId = 1},
                new Car(){ Id = 3, Model = "Tesla Model S", BasePrice = 95000, BrandId = 1},
                new Car(){ Id = 4, Model = "Tesla Model X", BasePrice = 105000, BrandId = 1},
                new Car(){ Id = 5, Model = "Eqs", BasePrice = 105000, BrandId = 2},
                new Car(){ Id = 6, Model = "Etron", BasePrice = 75000, BrandId = 3},
                new Car(){ Id = 7, Model = "Bmw IX3", BasePrice = 105000, BrandId = 4},
            });
        }

    }
}
