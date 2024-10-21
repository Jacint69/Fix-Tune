using Fix_Tune.Models;
using Fix_Tune.Repository;
using Microsoft.AspNetCore.Identity;

namespace Fix_Tune.Logic
{
    public class CarLogic : ICarLogic
    {
        IRepository<Car> repo;
        UserManager<User> _userManager;
        public CarLogic(IRepository<Car> repo, UserManager<User> userManager)
        {
            this.repo = repo;
            this._userManager = userManager;
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

        public async Task<bool> CanUpdateCar(User user, Car car)
        {
            var roles = await _userManager.GetRolesAsync(user);

            if (!roles.Contains("Admin") && !roles.Contains("Mechanic") && user.Id != car.UserId)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CanGetCar(User user, int carId)
        {

            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Admin") && !roles.Contains("Mechanic"))
            {
                if (!user.Cars.Any(t=>t.CarId==carId))
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> CanDeleteCar(User user, int carId)
        {
            var roles= await _userManager.GetRolesAsync(user);

            if (!roles.Contains("Admin") && !roles.Contains("Mechanic"))
            {
                if (!user.Cars.Any(t=>t.CarId==carId))
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<List<Car>> OwnedCars(User user)
        {
           return ReadAll().Where(x=>x.UserId==user.Id).ToList();
        }

    }
}
