using Fix_Tune.Logic;
using Fix_Tune.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fix_Tune.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController :ControllerBase
    {
        IServiceLogic logic;
        public ServiceController(IServiceLogic logic)
        {
            this.logic= logic;
        }

        [HttpGet]
        public IEnumerable<Service> GetServices()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Service GetService(int id)
        {
            return logic.Read(id);
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id) { 
            logic.Delete(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Create([FromBody] Service service)
        {
            logic.Create(service);
        }

    }
}
