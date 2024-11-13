using Fix_Tune.Logic;
using Fix_Tune.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fix_Tune.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController :ControllerBase
    {
        IDiscountLogic logic;
        public DiscountController(IDiscountLogic logic)
        {
            this.logic= logic;
        }

        [HttpGet]
        public IEnumerable<Discount> GetDiscounts()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Discount GetDiscount(int id)
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
        public void Create([FromBody] Discount service)
        {
            logic.Create(service);
        }

    }
}
