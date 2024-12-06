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
        private readonly LoginService _login;
        public LoginController(LoginService login)
        {
            _login = login; 
        }

        [HttpPost]
        [Route("GetUser")]
        public async Task<ActionResult<ResponseLogin>> LoginUser([FromBody] RequestLogin requestModel)
        {
            if (requestModel == null)
            {
                return BadRequest();
            }

            try
            {
                var user = await _login.FuncLoginUser(requestModel);
                if (user == null)
                {
                    return NotFound("Invalid username or password. Please try again.");
                }

                var response = new ResponseLogin
                {
                    UserName = requestModel.UserName,
                    Status = "Login successful"
                };

                return Ok(response);
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
