using Fix_Tune.Models;

namespace Fix_Tune.Logic
{
    public interface IMechanicLogic
    {
        IEnumerable<Car> FixedCars();
        IEnumerable<Car> FixNeedCars();
        IEnumerable<Car> GroupByCarsToUser(User user);
    }
}