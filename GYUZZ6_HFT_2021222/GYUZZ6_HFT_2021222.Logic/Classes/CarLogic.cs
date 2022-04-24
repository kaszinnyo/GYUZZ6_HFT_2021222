using GYUZZ6_HFT_2021222.Logic.Interfaces;
using GYUZZ6_HFT_2021222.Models;
using GYUZZ6_HFT_2021222.Repository;
using System;
using System.Linq;

namespace GYUZZ6_HFT_2021222.Logic
{
    public class CarLogic : ICarLogic
    {
        IRepository<Car> repo;

        public CarLogic(IRepository<Car> repo)
        {
            this.repo = repo;
        }

        public void Create(Car item)
        {
            this.repo.Create(item);
        }

        public void Update(Car item)
        {
            this.repo.Update(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Car Read(int id)
        {
            var car = this.repo.Read(id);
            if (car == null) throw new ArgumentException("Car not exists!");
            return this.repo.Read(id);
        }

        public IQueryable<Car> ReadAll()
        {
            return this.repo.ReadAll();
        }
    }
}
