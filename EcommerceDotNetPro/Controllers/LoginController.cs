using EcommerceDotNetPro.BusinessLogic.Authentication;
using EcommerceDotNetPro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EcommerceDotNetPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Login _login;
        public LoginController(Login login)
        {
            _login = login; 
        }

        [HttpPost]
        [Route("GetUser")]
        public async Task<ActionResult<mLogin>> LoginUser([FromBody] mLogin model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                var user = await _login.FuncLoginUser(model);
                if (user == null)
                {
                    return NotFound("Invalid username or password. Please try again.");
                }

                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                // Handle bad input (e.g., missing username/password)
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
