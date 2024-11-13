using Fix_Tune.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Repository
{
    public class ServiceRepository : Repository<Service>, IRepository<Service>
    {
        public ServiceRepository(FixTuneDbContext db) : base(db)
        {
        }

        public override Service? Read(int id)
        {
            var services= db.Services.FirstOrDefault(x => x.ServiceId == id);
            if (services==null)
            {
                throw new Exception("Nemtalálható szolgáltatás!");
            }
            return services;
        }

        public override void Update(Service entity)
        {
            var old = Read(entity.ServiceId);
            var type = entity.GetType();
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            db.SaveChanges();
        }
    }
}
