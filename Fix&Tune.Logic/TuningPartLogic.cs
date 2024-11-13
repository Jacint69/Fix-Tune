using Fix_Tune.Models;
using Fix_Tune.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Logic
{
    public class TuningPartLogic : ITuningPartLogic
    {
        IRepository<TuningPart> repo;

        public TuningPartLogic(IRepository<TuningPart> repo)
        {
            this.repo = repo;
        }

        public void Create(TuningPart entity)
        {
            repo.Create(entity);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public TuningPart Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<TuningPart> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(TuningPart entity)
        {
            repo.Update(entity);
        }
    }
}
