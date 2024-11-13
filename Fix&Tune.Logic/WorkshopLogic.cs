using Fix_Tune.Models;
using Fix_Tune.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Logic
{
    public class WorkshopLogic : IWorkshopLogic
    {

        IRepository<Workshop> repo;
        public WorkshopLogic(IRepository<Workshop> repo)
        {
            this.repo = repo;
        }
        public void Create(Workshop entity)
        {
            repo.Create(entity);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Workshop Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Workshop> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Workshop entity)
        {
            repo.Update(entity);
        }
    }
}
