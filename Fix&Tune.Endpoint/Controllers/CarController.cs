using AutoMapper;
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
        IMapper _mapper;
        public CarController(UserManager<User> userManager, ICarLogic carLogic, IMapper mapper)
        {
            _userManager = userManager;
            this.carLogic = carLogic;
            _mapper = mapper;
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
        public async Task<CarDTO> GetCar(int id)
        {
            //Azonosítás
            
            var user = await _userManager.FindByNameAsync(this.User.Identity.Name);

            if (!await carLogic.CanGetCar(user,id))
            {
                throw new Exception("Nincs hozzá jogosultságod!");
            }

            var car = carLogic.Read(id);
            var carDTO = _mapper.Map<CarDTO>(car);
            return carDTO;

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Car car)
        {
            var name = await _userManager.FindByNameAsync(this.User.Identity.Name);
            //TODO: ezt majd a kliens oldal küldi
            car.User = name;
            car.UserId = name.Id;
            //
            carLogic.Create(car);
            return Ok(_mapper.Map<CarDTO>(car));
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> Update(Car car)
        {
            var user = await _userManager.FindByNameAsync(this.User.Identity.Name);

            if (await carLogic.CanUpdateCar(user, car))
            {
                carLogic.Update(car);
                return Ok(_mapper.Map<CarDTO>(car));
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
