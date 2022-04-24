using GYUZZ6_HFT_2021222.Models;
using GYUZZ6_HFT_2021222.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYUZZ6_HFT_2021222.Repository
{
    public class CarRepository : Repository<Car>
    {
        public CarRepository(CarDbContext ctx) : base(ctx)
        {
        }

        public override Car Read(int id)
        {
            return ctx.Cars.FirstOrDefault(c=>c.Id == id);
        }

        public override void Update(Car item)
        {
            var oldItem = Read(item.Id);
            foreach (var prop in oldItem.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(p => p.IsVirtual) == null)
                    prop.SetValue(oldItem, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
