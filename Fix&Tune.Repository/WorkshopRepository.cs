using Fix_Tune.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Repository
{
    public class WorkshopRepository : Repository<Workshop>, IRepository<Workshop>
    {
        public WorkshopRepository(FixTuneDbContext db) : base(db)
        {

        }

        public override Workshop? Read(int id)
        {
            var workshop = db.Workshops.FirstOrDefault(x => x.WorkshopId == id);
            if (workshop == null)
            {
                throw new Exception("Nemtalálható telephely");
            }
            return workshop;
        }

        public override void Update(Workshop entity)
        {
            var old = Read(entity.WorkshopId);
            var type = entity.GetType();
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            db.SaveChanges();
        }
    }
}
