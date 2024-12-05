using EcommerceDotNetPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceDotNetPro.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SigupController : ControllerBase
    {


        public SigupController() {


        }

        public async Task <ActionResult<mSignup>> CreateUser([FromBody] mSignup model)

        {
            if(model == null)
            {
                return BadRequest();
            }
            mSignup user =  new mSignup();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Phone = model.Phone;  

            await _dbcontext.signup.AddAsync(user);
            await _dbcontext.SaveChangesAsync();


            return Ok(user);
        }
      
        


    }
}
