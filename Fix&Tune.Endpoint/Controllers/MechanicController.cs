using Fix_Tune.Logic;
using Fix_Tune.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fix_Tune.Endpoint.Controllers
{
    [Authorize(Roles = "Admin, Mechanic")]
    [Route("[controller]/[action]")]
    public class MechanicController : ControllerBase
    {
        IMechanicLogic mechanicLogic;
        UserManager<User> _userManager;
        public MechanicController(IMechanicLogic mechanicLogic, UserManager<User> userManager)
        {
            this.mechanicLogic = mechanicLogic;
            this._userManager = userManager;
        }

        [HttpGet]//TODO: User átírása userid-ra
        public async Task<IActionResult> GroupByCarsToUser()
        {
            var user = await _userManager.FindByNameAsync(this.User.Identity.Name);
            var result = mechanicLogic.GroupByCarsToUser(user);
            return Ok(result);

        }
    }
}
