using Fix_Tune.Logic;
using Fix_Tune.Models;
using Fix_Tune.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fix_Tune.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic carLogic;
        public CarController(ICarLogic carLogic)
        {
            this.carLogic = carLogic;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Car> GetCars()
        {
            return carLogic.ReadAll();
        }

        [HttpPost]
        [Authorize]
        public void Create([FromBody] Car car)
        {
            carLogic.Create(car);
        }


        
    }
}
