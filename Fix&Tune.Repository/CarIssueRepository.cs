using Fix_Tune.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Repository
{
    public class CarIssueRepository : Repository<CarIssue>, IRepository<CarIssue>
    {
        public CarIssueRepository(FixTuneDbContext db) : base(db)
        {
        }

        public override CarIssue? Read(int id)
        {
            return db.CarIssues.FirstOrDefault(x => x.CarIssueId == id);
        }

        public override void Update(CarIssue entity)
        {
            var old = Read(entity.CarIssueId);
            var type = entity.GetType();
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            db.SaveChanges();
        }
    }
}
