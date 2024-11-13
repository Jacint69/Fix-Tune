using Fix_Tune.Models;
using Fix_Tune.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Logic
{
    public class DiscountLogic : IDiscountLogic
    {
        IRepository<Discount> repo;
        public DiscountLogic(IRepository<Discount> repo)
        {
            this.repo = repo;
        }
        public void Create(Discount entity)
        {
            repo.Create(entity);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Discount Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Discount> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Discount entity)
        {
            repo.Update(entity);
        }
    }
}
