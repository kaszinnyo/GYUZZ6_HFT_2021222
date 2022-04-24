using GYUZZ6_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYUZZ6_HFT_2021222.Logic.Interfaces
{
    public interface ICarLogic
    {
        void Create(Car item);
        void Delete(int id);
        Car Read(int id);
        IQueryable<Car> ReadAll();
        void Update(Car item);
    }
}
