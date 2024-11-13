using Fix_Tune.Logic;
using Fix_Tune.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fix_Tune.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        IWorkshopLogic logic;
        // GET: api/<WorkshopController>
        public WorkshopController(IWorkshopLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Workshop> Get()
        {
            return logic.ReadAll();
        }

        // GET api/<WorkshopController>/5
        [HttpGet("{id}")]
        public Workshop Get(int id)
        {
            return logic.Read(id);
        }

        // POST api/<WorkshopController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] Workshop value)
        {
            logic.Create(value);
        }

        // PUT api/<WorkshopController>/5
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put([FromBody] Workshop value)
        {
            logic.Update(value);
        }

        // DELETE api/<WorkshopController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
