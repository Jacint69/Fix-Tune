using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected FixTuneDbContext db;
        protected Repository(FixTuneDbContext db)
        {
            this.db = db;   
        }
        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Set<T>().Remove(Read(id));
            db.SaveChanges();
        }

        public abstract T Read(int id);
        
        
        public IQueryable<T> ReadAll()
        {
            return db.Set<T>();
        }

        public abstract void Update(T entity);
        
    }
}
