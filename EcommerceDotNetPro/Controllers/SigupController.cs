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

        [HttpPost]
        [Route("CreateUser")]
        public async Task <ActionResult<UserData>> CreateUser([FromBody] UserData model)

        {
            if(model == null)
            {
                return BadRequest();
            }
            UserData user =  new UserData();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Phone = model.Phone;  

            //await _dbcontext.signup.AddAsync(user);
            //await _dbcontext.SaveChangesAsync();


            return Ok(user);
        }
      
        


    }
}
