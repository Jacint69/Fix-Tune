using Fix_Tune.Models;

namespace Fix_Tune.Logic
{
    public interface ICarLogic
    {
        void Create(Car entity);
        void Delete(int id);
        Car Read(int id);
        IQueryable<Car> ReadAll();
        void Update(Car entity);
    }
}