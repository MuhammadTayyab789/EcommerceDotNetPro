using EcommerceDotNetPro.BusinessLogic.Authentication;
using EcommerceDotNetPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceDotNetPro.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SigupController : ControllerBase
    {

        private readonly Signup signup;
        public SigupController()
        {


        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUser([FromBody] mSignup model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            mSignup user =  new mSignup();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Phone = model.Phone;  

            await _dbcontext.signup.AddAsync(user);
            await _dbcontext.SaveChangesAsync();


            try
            {
                var user = await signup.FuncCreateUserAsync(model);
                //return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
