using GYUZZ6_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYUZZ6_HFT_2021222.Logic.Interfaces
{
    public interface IRentLogic
    {
        void Create(Rent item);
        void Delete(int id);
        Rent Read(int id);
        IQueryable<Rent> ReadAll();
        void Update(Rent item);
    }
}
