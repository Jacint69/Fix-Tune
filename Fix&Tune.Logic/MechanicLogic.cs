using Fix_Tune.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Logic
{
    public class MechanicLogic
    {
        ICarLogic carLogic;
        IIssueLogic issueLogic;

        public MechanicLogic(ICarLogic carLogic, IIssueLogic issueLogic)
        {
            this.carLogic = carLogic;
            this.issueLogic = issueLogic;
        }

        public IEnumerable<Car> FixNeedCars()
        {
            return carLogic.ReadAll().Where(t => !t.Status);
        }

        public IEnumerable<Car> FixedCars() {
            return carLogic.ReadAll().Where(t => t.Status);
        }




    }
}
