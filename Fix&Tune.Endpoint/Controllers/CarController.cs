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
        IRepository<Car> carRepo;
        public CarController(IRepository<Car> car)
        {
            carRepo = car;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Car> GetCars()
        {
            return carRepo.ReadAll();
        }
    }
}
