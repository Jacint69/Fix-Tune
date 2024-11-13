using Fix_Tune.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Repository
{
    public class TuningPartRepository : Repository<TuningPart>, IRepository<TuningPart>
    {
        public TuningPartRepository(FixTuneDbContext db) : base(db)
        {
        }

        public override TuningPart? Read(int id)
        {
            var tuningpart = db.TuningParts.FirstOrDefault(x => x.TuningPartID == id);
            if (tuningpart == null)
            {
                throw new Exception("Nemtalálható tuningalkatrész!");
            }
            return tuningpart;
        }

        public override void Update(TuningPart entity)
        {
            var old = Read(entity.TuningPartID);
            var type = entity.GetType();
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            db.SaveChanges();
        }
    }
}
