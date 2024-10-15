using Fix_Tune.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Repository
{
    public class CarRepository : Repository<Car>, IRepository<Car>
    {
        public CarRepository(FixTuneDbContext db) : base(db)
        {
        }

        public override Car? Read(int id)
        {
            var cars= db.Cars.FirstOrDefault(x => x.CarId == id);
            if (cars==null)
            {
                throw new Exception("Nemtalálható autó!");
            }
            return cars;
        }

        public override void Update(Car entity)
        {
            var old = Read(entity.CarId);
            var type = entity.GetType();
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            db.SaveChanges();
        }
    }
}
