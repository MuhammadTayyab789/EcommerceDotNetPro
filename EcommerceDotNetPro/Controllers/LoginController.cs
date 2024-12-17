using EcommerceDotNetPro.BusinessLogic.Authentication;
using EcommerceDotNetPro.BusinessLogic.JWT;
using EcommerceDotNetPro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EcommerceDotNetPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _login;
        private readonly TokenService _tokenService;

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
                    UserName = user.UserName,
                    Token = user.Token
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


        [HttpPost]
        [Route("GetUserbysession")]
        public async Task<ActionResult<ResponseLogin>> LoginUserbysession([FromBody] RequestLogin requestModel)
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
                 HttpContext.Session.SetString("key", user.Token);
           // var sessionid =  HttpContext.Session.GetString("key");

                var response = new ResponseLogin
                {
                    UserName = user.UserName,
                    Token = user.Token
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

        [Authorize]
        [HttpGet("simple")]  // This specifies that it's a GET request
        public IActionResult SimpleMessage()
        {
            return Ok("Simple .NET");
        }

        
        [HttpGet("simplesession")]  // This specifies that it's a GET request
        public IActionResult SimpleMessagesession()
        {

            var userToken = HttpContext.Session.GetString("key");
            Console.WriteLine(userToken);

            if (string.IsNullOrEmpty(userToken))
            {
                return Unauthorized("Session expired. Please log in again.");
            }
            return Ok("Simplesession .NET");
        }


    }
}
