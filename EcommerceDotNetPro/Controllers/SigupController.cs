using EcommerceDotNetPro.BusinessLogic.Authentication;
using EcommerceDotNetPro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EcommerceDotNetPro.Controllers
{
   // [ApiController]
    [Route("api/[controller]")]
    public class SignupController : ControllerBase
    {
        private readonly SignupService _signup;
        public SignupController(SignupService signup)
        {
            _signup = signup;
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<ActionResult<RequestSignup>> CreateUser([FromBody] RequestSignup requestModel)
        {
            if (requestModel == null)
            {
                return BadRequest();
            }

            try
            {
                var user = await _signup.FuncCreateUser(requestModel);
                if (user == null)
                {
                    return NotFound("We are unable to create User.Kindly Provide Valid Data");
                }

                var response = new ResponseSignup
                {
                    UserName = requestModel.UserName,
                    Status = "Signup Successfull"
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
