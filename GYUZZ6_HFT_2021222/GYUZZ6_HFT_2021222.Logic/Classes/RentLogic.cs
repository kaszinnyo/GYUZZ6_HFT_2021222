using GYUZZ6_HFT_2021222.Logic.Interfaces;
using GYUZZ6_HFT_2021222.Models;
using GYUZZ6_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYUZZ6_HFT_2021222.Logic.Classes
{
    public class RentLogic : IRentLogic
    {
        IRepository<Rent> rentRepo;
        IRepository<Car> carRepo;

        public RentLogic(IRepository<Rent> rentRepo, IRepository<Car> carRepo, IRepository<Brand> brandRepo)
        {
            this.rentRepo = rentRepo;
            this.carRepo = carRepo;
        }

        public void Create(Rent item)
        {
            if (item.RenterName.Length < 2) throw new ArgumentException("Túl rövid!");
            else this.rentRepo.Create(item);
        }
        public void Update(Rent item)
        {
            this.rentRepo.Update(item);
        }

        public void Delete(int id)
        {
            this.rentRepo.Delete(id);
        }

        public Rent Read(int id)
        {
            var rent = this.rentRepo.Read(id);
            if (rent == null) throw new ArgumentException("Rent not exists!");
            return this.rentRepo.Read(id);
        }

        public IQueryable<Rent> ReadAll()
        {
            return this.rentRepo.ReadAll();
        }

        //non crcud

        //1 - Avgerge baseprice by brand
        public IEnumerable<KeyValuePair<string, double>> BasePriceAverageByBrand()
        {
            return from c in carRepo.ReadAll()
                   group c by c.Brand.Name into g
                   select new KeyValuePair<string, double>(g.Key, g.Average(c => c.BasePrice).GetValueOrDefault());
        }

        //2 - Rent count by model
        public IEnumerable<KeyValuePair<string, int>> RentCountByModel()
        {
            return from r in rentRepo.ReadAll()
                   group r by r.Car.Model into g
                   select new KeyValuePair<string, int>(g.Key, g.Count());
        }

        //3 - Sum rent by date(in hours)
        public IEnumerable<KeyValuePair<string, double>> RentsSumByDate()
        {
            return from r in rentRepo.ReadAll()
                   group r by r.Date into g
                   select new KeyValuePair<string, double>(g.Key.ToString(), g.Sum(r => r.RentTime).GetValueOrDefault());
        }

        //4 - car count by brand
        public IEnumerable<KeyValuePair<string, int>> BrandCarCount()
        {
            return from c in carRepo.ReadAll()
                   group c by c.Brand.Name into g
                   select new KeyValuePair<string, int>(g.Key, g.Count());
        }

        //5 - average rating by model
        public IEnumerable<KeyValuePair<string, double>> AverageRatingByModel()
        {
            return from r in rentRepo.ReadAll()
                   group r by r.Car.Model into g
                   select new KeyValuePair<string, double>(g.Key, g.Average(r => r.Rating).GetValueOrDefault());
        }
    }
}
