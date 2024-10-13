using Fix_Tune.Models;
using Fix_Tune.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Logic
{
    public class CarIssueLogic : ICarIssueLogic
    {
        IRepository<CarIssue> repo;

        public CarIssueLogic(IRepository<CarIssue> repo)
        {
            this.repo = repo;
        }

        public void Create(CarIssue entity)
        {
            repo.Create(entity);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public CarIssue Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<CarIssue> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(CarIssue entity)
        {
            repo.Update(entity);
        }
    }
}
