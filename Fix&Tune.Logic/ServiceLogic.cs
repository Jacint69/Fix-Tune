using Fix_Tune.Models;
using Fix_Tune.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Logic
{
    internal class ServiceLogic : IServiceLogic
    {
        IRepository<Service> repo;
        public ServiceLogic(IRepository<Service> repo)
        {
            this.repo = repo;
        }
        public void Create(Service entity)
        {
            repo.Create(entity);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Service Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Service> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Service entity)
        {
            repo.Update(entity);
        }
    }
}
