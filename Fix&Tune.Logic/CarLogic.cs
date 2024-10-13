using Fix_Tune.Models;
using Fix_Tune.Repository;

namespace Fix_Tune.Logic
{
    public class CarLogic : ICarLogic
    {
        IRepository<Car> repo;
        public CarLogic(IRepository<Car> repo)
        {
            this.repo = repo;
        }

        public void Create(Car entity)
        {
            repo.Create(entity);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Car Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Car> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Car entity)
        {
            repo.Update(entity);
        }
    }
}
