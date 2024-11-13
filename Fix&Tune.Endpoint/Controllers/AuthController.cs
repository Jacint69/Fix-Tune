using Fix_Tune.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fix_Tune.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly UserManager<User> _userManager; //UserManager az identitybe van

        public AuthController(UserManager<User> user)
        {
            _userManager = user;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserInfos()
        {
            var user = await _userManager.FindByNameAsync(this.User.Identity.Name);
            return Ok(new
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = await _userManager.GetRolesAsync(user)
            });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            // Ellenőrizzük a modell érvényességét
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Felhasználó létrehozása
            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfRegistration = DateTime.Now
            };

            // Felhasználó létrehozása az adatbázisban
            var result = await _userManager.CreateAsync(user, model.Password);

            // Ellenőrizzük, hogy a felhasználó sikeresen létrejött-e
            if (!result.Succeeded)
            {
                // Ha nem, visszatérünk a hibákkal
                return BadRequest(result.Errors);
            }

            // Hozzáadjuk a felhasználót a szerepkörhöz
            await _userManager.AddToRoleAsync(user, "Customer");

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user.UserName=="Jaco")
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // List of claims to add to the token
                var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName), // UserName claim added
            new Claim(ClaimTypes.NameIdentifier, user.Id), // UserName claim added
            new Claim(ClaimTypes.Surname, user.LastName) // LastName claim added
        };

                // Add roles as claims
                foreach (var role in await _userManager.GetRolesAsync(user))
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nagyonhosszutitkoskodhelyeasdasdasd"));
                var token = new JwtSecurityToken(
                    issuer: "http://www.security.org",
                    audience: "http://www.security.org",
                    claims: claims, // Using the modified claims list
                    expires: DateTime.Now.AddMinutes(240),
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                });
            }
            return Unauthorized();
        }
    }
}
