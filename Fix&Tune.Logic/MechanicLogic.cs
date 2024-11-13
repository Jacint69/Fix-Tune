using Fix_Tune.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Logic
{
    public class MechanicLogic : IMechanicLogic
    {
        ICarLogic carLogic;
        IIssueLogic issueLogic;
        UserManager<User> _userManager;

        public MechanicLogic(ICarLogic carLogic, IIssueLogic issueLogic, UserManager<User> userManager)
        {
            this.carLogic = carLogic;
            this.issueLogic = issueLogic;
            _userManager = userManager;
        }

        public IEnumerable<Car> FixNeedCars()
        {
            return carLogic.ReadAll().Where(t => !t.Status);
        }

        public IEnumerable<Car> FixedCars()
        {
            return carLogic.ReadAll().Where(t => t.Status);
        }

        public IEnumerable<Car> GroupByCarsToUser(User user)
        {
            var items = carLogic.ReadAll().Where(t => t.UserId == user.Id).GroupBy(x => x.UserId).ToList();
            List<Car> cars = new List<Car>();
            foreach (var item in items)
            {
                foreach (var car in item)
                {
                    cars.Add(car);
                }

            }
            return cars;
        }




    }
}
