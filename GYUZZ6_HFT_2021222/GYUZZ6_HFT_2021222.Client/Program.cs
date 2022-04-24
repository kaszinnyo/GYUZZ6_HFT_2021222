using ConsoleTools;
using GYUZZ6_HFT_2021222.EndPoint;
using GYUZZ6_HFT_2021222.Models;
using System;
using System.Collections.Generic;

namespace GYUZZ6_HFT_2021222.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Brand")
            {
                Console.WriteLine("Enter Brand Name: ");
                string name = Console.ReadLine();
                rest.Post(new Brand() { Name = name }, "brand");
            }
            else if (entity == "Car")
            {
                Console.WriteLine("Enter Model: ");
                string model = Console.ReadLine();
                Console.WriteLine("Enter Price: ");
                int price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Brand Id: ");
                int brandId = int.Parse(Console.ReadLine());
                rest.Post(new Car() { Model = model, BasePrice = price, BrandId = brandId }, "car");
            }
            else if (entity == "Rent")
            {
                Console.WriteLine("Enter Car Id: ");
                int carId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Renter's Name: ");
                string renterName = Console.ReadLine();
                Console.WriteLine("Enter Date: --- YYYY-MM-DD");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Rent Time: ");
                double rentTime = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Rating: ");
                double rating = double.Parse(Console.ReadLine());
                rest.Post(new Rent() { CarId = carId, RenterName = renterName, Date = date, RentTime = rentTime, Rating = rating, }, "rent");
            }
        }

        static void List(string entity)
        {
            if (entity == "Brand")
            {
                List<Brand> brands = rest.Get<Brand>("brand");
                foreach (var brand in brands)
                {
                    Console.WriteLine($"Id:{brand.Id},  Name: {brand.Name}");
                }
            }
            else if (entity == "Car")
            {
                List<Car> cars = rest.Get<Car>("car");
                foreach (var car in cars)
                {
                    Console.WriteLine($"Id: {car.Id}, Model: {car.Model}, Price: {car.BasePrice}");
                }
            }
            else if (entity == "Rent")
            {
                List<Rent> rents = rest.Get<Rent>("rent");
                foreach (var rent in rents)
                {
                    Console.WriteLine($"Id: {rent.Id}, Renter's name: {rent.RenterName}, Date: {rent.Date.ToString()}, Rent Time: {rent.RentTime}, Rating: {rent.Rating}");
                }
            }
            Console.ReadLine();
        }

        static void One(string entity)
        {
            if (entity == "Brand")
            {
                Console.WriteLine("Enter Brand's: ");
                int id = int.Parse(Console.ReadLine());
                Brand one = rest.Get<Brand>(id,"brand");
                Console.WriteLine($"Id:{one.Id},  Name: {one.Name}");
            }
            else if (entity == "Car")
            {
                Console.WriteLine("Enter Car's: ");
                int id = int.Parse(Console.ReadLine());
                Car one = rest.Get<Car>(id, "car");
                Console.WriteLine($"Id: {one.Id}, Model: {one.Model}, Price: {one.BasePrice}");
            }
            else if (entity == "Rent")
            {
                Console.WriteLine("Enter Rent's: ");
                int id = int.Parse(Console.ReadLine());
                Rent one = rest.Get<Rent>(id,"rent");
                Console.WriteLine($"Id: {one.Id}, Renter's name: {one.RenterName}, Date: {one.Date.ToString()}, Rent Time: {one.RentTime}, Rating: {one.Rating}");
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Brand")
            {
                Console.WriteLine("Enter Brand's Id to update: ");
                int id = int.Parse(Console.ReadLine());
                Brand one = rest.Get<Brand>(id, "brand");
                Console.WriteLine($"New Name [old:{one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "brand");
            }
            else if (entity == "Car")
            {
                Console.WriteLine("Enter Car's Id to update: ");
                int id = int.Parse(Console.ReadLine());
                Car one = rest.Get<Car>(id, "car");
                Console.WriteLine("What do you want to update?");
                Console.WriteLine("Model[0]\tBasePrice[1]");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    Console.WriteLine($"New Model Name [old:{one.Model}]: ");
                    string model = Console.ReadLine();
                    one.Model = model;
                    rest.Put(one, "car");
                }
                else if(choice == 1)
                {
                    Console.WriteLine($"New BasePrice [old:{one.BasePrice}]: ");
                    int baseprice = int.Parse(Console.ReadLine());
                    one.BasePrice = baseprice;
                    rest.Put(one, "car");
                }
                else Console.WriteLine("Wrong number!");
                Console.ReadLine();
            }
            else if (entity == "Rent")
            {
                Console.WriteLine("Enter Rent's Id to update: ");
                int id = int.Parse(Console.ReadLine());
                Rent one = rest.Get<Rent>(id, "rent");
                Console.WriteLine($"New rating [old:{one.Rating}]: ");
                double rating = double.Parse(Console.ReadLine());
                one.Rating = rating;
                rest.Put(one, "rent");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Brand")
            {
                Console.WriteLine("Enter Brand's Id  to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "brand");
            }
            else if (entity == "Car")
            {
                Console.WriteLine("Enter Car's Id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "car");
            }
            else if (entity == "Rent")
            {
                Console.WriteLine("Enter Rent's Id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "rent");
            }
            else Console.WriteLine("Not valid.");
            Console.ReadLine();
        }

        static void BasePriceAverageByBrand()
        {
            List<KeyValuePair<string, double>> list = rest.Get<KeyValuePair<string, double>>("stat/basepriceaveragebybrand");
            foreach (var item in list)
            {
                Console.WriteLine($"Brand: {item.Key} - AvgPrice: {item.Value}");
            }
            Console.ReadLine();
        }

        static void RentCountByModel()
        {
            List<KeyValuePair<string, int>> list = rest.Get<KeyValuePair<string, int>>("stat/rentcountbymodel");
            foreach (var item in list)
            {
                Console.WriteLine($"Model: {item.Key} - RentCount: {item.Value}");
            }
            Console.ReadLine();
        }

        static void RentsSumByDate()
        {
            List<KeyValuePair<string, double>> list = rest.Get<KeyValuePair<string, double>>("stat/rentssumbydate");
            foreach (var item in list)
            {
                Console.WriteLine($"Date: {item.Key} - RentSum: {item.Value}");
            }
            Console.ReadLine();
        }

        static void BrandCarCount()
        {
            List<KeyValuePair<string, int>> list = rest.Get<KeyValuePair<string, int>>("stat/brandcarcount");
            foreach (var item in list)
            {
                Console.WriteLine($"Brand: {item.Key} - CarCount: {item.Value}");
            }
            Console.ReadLine();
        }

        static void AverageRatingByModel()
        {
            List<KeyValuePair<string, double>> list = rest.Get<KeyValuePair<string, double>>("stat/averageratingbymodel");
            foreach (var item in list)
            {
                Console.WriteLine($"Model: {item.Key} - AvgRating: {item.Value}");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:18131/", "car");

            var carSubMenu = new ConsoleMenu(args, level:1)
                .Add("List", ()=> List("Car"))
                .Add("One", ()=> One("Car"))
                .Add("Create", () => Create("Car"))
                .Add("Update", () => Update("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("One", () => One("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Exit", ConsoleMenu.Close);

            var rentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Rent"))
                .Add("One", () => One("Rent"))
                .Add("Create", () => Create("Rent"))
                .Add("Update", () => Update("Rent"))
                .Add("Delete", () => Delete("Rent"))
                .Add("Exit", ConsoleMenu.Close);

            var statSubMenu = new ConsoleMenu(args, level: 1)
                .Add("BasePriceAverageByBrand", () => BasePriceAverageByBrand())
                .Add("RentCountByModel", () => RentCountByModel())
                .Add("RentsSumByDate", () => RentsSumByDate())
                .Add("BrandCarCount", () => BrandCarCount())
                .Add("AverageRatingByModel", () => AverageRatingByModel())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Cars", () => carSubMenu.Show())
                .Add("Rents", () => rentSubMenu.Show())
                .Add("Stats", () => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
