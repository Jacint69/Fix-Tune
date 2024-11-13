using Fix_Tune.Logic;
using Fix_Tune.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fix_Tune.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TuningPartController : ControllerBase
    {

        ITuningPartLogic logic;

        public TuningPartController(ITuningPartLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<TuningPartController>
        [HttpGet]
        public IEnumerable<TuningPart> Get()
        {
            return logic.ReadAll();
        }

        // GET api/<TuningPartController>/5
        [HttpGet("{id}")]
        public TuningPart Get(int id)
        {
            return logic.Read(id);
        }

        // POST api/<TuningPartController>
        [HttpPost]
        public void Post([FromBody] TuningPart value)
        {
            logic.Create(value);
        }

        // PUT api/<TuningPartController>/5
        [HttpPut]
        public void Put([FromBody] TuningPart value)
        {
            logic.Update(value);
        }

        // DELETE api/<TuningPartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
