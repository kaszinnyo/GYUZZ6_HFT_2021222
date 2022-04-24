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
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> repo;

        public BrandLogic(IRepository<Brand> repo)
        {
            this.repo = repo;
        }

        public void Create(Brand item)
        {
            this.repo.Create(item);
        }

        public void Update(Brand item)
        {
            this.repo.Update(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        Brand IBrandLogic.Read(int id)
        {
            var brand = this.repo.Read(id);
            if (brand == null) throw new ArgumentException("Brand not exists!");
            return this.repo.Read(id);
        }

        IQueryable<Brand> IBrandLogic.ReadAll()
        {
            return this.repo.ReadAll();
        }
    }
}
