using Fix_Tune.Logic;
using Fix_Tune.Models;
using Fix_Tune.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fix_Tune.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic carLogic;
        UserManager<User> _userManager { get; set; }
        public CarController(UserManager<User> userManager, ICarLogic carLogic)
        {
            _userManager = userManager;
            this.carLogic = carLogic;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Car> GetCars()
        {

            //var data = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            return carLogic.ReadAll();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<Car> GetCar(int id)
        {
            //Azonosítás
            var requestedUserName = (this.User.Identity.Name);
            var requestedUser = await _userManager.FindByNameAsync(requestedUserName);

            //Szerepkörök
            var roles = await _userManager.GetRolesAsync(requestedUser);

            if(!roles.Contains("Admin") && !roles.Contains("Mechanic"))
            {
                var ownsCar = requestedUser.Cars.Any(t => t.CarId == id);
                if (!ownsCar)
                {
                    throw new Exception("Nemlétezik ilyen autó!");
                }
            }

            return carLogic.Read(id);

           
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Car car)
        {
            var name = await _userManager.FindByNameAsync(this.User.Identity.Name);
            car.User = name;
            car.UserId = name.Id;
            carLogic.Create(car);
            return Ok();
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> Update(Car car)
        {
            var user = await _userManager.FindByNameAsync(this.User.Identity.Name);

            if (await carLogic.CanUpdateCar(user, car))
            {
                carLogic.Update(car);
                return Ok(car);
            }
            else
            {
                throw new Exception("Nem létező autó / Nincs jogosultságod!");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var requestedUserName = this.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(requestedUserName);

            var roles = await _userManager.GetRolesAsync(user);

            var car = carLogic.Read(id);

            if (!roles.Contains("Admin") && !roles.Contains("Mechanic"))
            {
                if (!user.Cars.Any(t=>t.CarId==id))
                {
                    return Forbid("Nincs jogosultságod");
                }
            }

            carLogic.Delete(id);
            return Ok("Deleted: " + id);
        }


    }
}
