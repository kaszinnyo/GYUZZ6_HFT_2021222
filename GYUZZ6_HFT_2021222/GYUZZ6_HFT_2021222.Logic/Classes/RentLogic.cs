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
        IRepository<Rent> repo;
        public void Create(Rent item)
        {
            this.repo.Create(item);
        }
        public void Update(Rent item)
        {
            this.repo.Update(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Rent Read(int id)
        {
            var rent = this.repo.Read(id);
            if (rent == null) throw new ArgumentException("Rent not exists!");
            return this.repo.Read(id);
        }

        public IQueryable<Rent> ReadAll()
        {
            return this.repo.ReadAll();
        }
    }
}
