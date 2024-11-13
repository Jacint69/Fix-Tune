using Fix_Tune.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Repository
{
    public class DiscountRepository : Repository<Discount>, IRepository<Discount>
    {
        public DiscountRepository(FixTuneDbContext db) : base(db)
        {
        }

        public override Discount? Read(int id)
        {
            var discounts= db.Discounts.FirstOrDefault(x => x.DiscountId == id);
            if (discounts==null)
            {
                throw new Exception("Nemtalálható akció!");
            }
            return discounts;
        }

        public override void Update(Discount entity)
        {
            var old = Read(entity.DiscountId);
            var type = entity.GetType();
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            db.SaveChanges();
        }
    }
}
