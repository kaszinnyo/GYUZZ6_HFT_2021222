using GYUZZ6_HFT_2021222.Models;
using GYUZZ6_HFT_2021222.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYUZZ6_HFT_2021222.Repository
{
    public class RentRepository : Repository<Rent>
    {
        public RentRepository(CarDbContext ctx) : base(ctx)
        {
        }

        public override Rent Read(int id)
        {
            return ctx.Rents.FirstOrDefault(r => r.Id == id);
        }

        public override void Update(Rent item)
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
