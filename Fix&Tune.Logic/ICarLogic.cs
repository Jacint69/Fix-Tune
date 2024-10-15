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
        Task<bool> CanUpdateCar(User user, Car car);
        Task<bool> CanGetCar(User user, int carId);
        Task<bool> CanDeleteCar(User user, int carId);
    }
}