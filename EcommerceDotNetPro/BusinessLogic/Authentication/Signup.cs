using EcommerceDotNetPro.DataLayer;
using EcommerceDotNetPro.Models;
using System.Reflection;

namespace EcommerceDotNetPro.BusinessLogic.Authentication
{
    public class Signup
    {
        public Signup()
        {

        }

        public async Task<mSignup> FuncCreateUserAsync(mSignup model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            // Map properties (if necessary)
            var user = new mSignup
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                Phone = model.Phone
            };

            // Add the new user to the database
           // await _dbcontext.signup.AddAsync(user);
            //await _dbcontext.SaveChangesAsync();

            // Return the created user
            return user;
        }






    }

}
