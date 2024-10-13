using Fix_Tune.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Repository
{
    public class IssueRepository : Repository<Issue>, IRepository<Issue>
    {
        public IssueRepository(FixTuneDbContext db) : base(db)
        {
        }

        public override Issue? Read(int id)
        {
            return db.Issues.FirstOrDefault(x => x.IssueID == id);
        }

        public override void Update(Issue entity)
        {
            var old = Read(entity.IssueID);
            var type = entity.GetType();
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            db.SaveChanges();
        }
    }
}
