using Fix_Tune.Logic;
using Fix_Tune.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fix_Tune.Endpoint.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CarIssueController:ControllerBase
    {
        ICarIssueLogic carIssueLogic;
        public CarIssueController(ICarIssueLogic carIssueLogic)
        {
            this.carIssueLogic = carIssueLogic;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Mechanic")]
        public IEnumerable<CarIssue> CarIssues()
        {
            return carIssueLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public CarIssue CarIssue(int id) { 
            return carIssueLogic.Read(id);
        }

        [HttpPut]
        public IActionResult UpdateCarIssue(CarIssue carIssue)
        {
            carIssueLogic.Update(carIssue);
            return Ok(carIssue);
        }

        [HttpDelete]
        public IActionResult DeleteCarIssue(int id)
        {
            carIssueLogic.Delete(id);
            return Ok("Deleted: " + id);
        }

        [HttpPost]
        public IActionResult CreateCarIssue([FromBody] CarIssue carIssue)
        {
            carIssueLogic.Create(carIssue);
            return Ok(carIssue);
        }
    }
}
