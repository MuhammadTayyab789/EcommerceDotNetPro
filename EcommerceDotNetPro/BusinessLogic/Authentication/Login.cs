using EcommerceDotNetPro.DataLayer;
using EcommerceDotNetPro.Models;

namespace EcommerceDotNetPro.BusinessLogic.Authentication
{
    public class Login
    {
        private readonly LoginDll _loginDll;
        public Login(LoginDll loginDll)
        {
            _loginDll = loginDll;
        }

    public async Task<mLogin> FuncLoginUser(mLogin model)
        {
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                throw new ArgumentException("Username or password cannot be empty.");
            }

            bool isAuthenticated = await _loginDll.AuthenticateUserAsync(model);
            if (isAuthenticated)
            {
                // If authentication succeeds, return the user details
                return model;
            }

            // If authentication fails, return null or throw an exception
            return null;
        }


    }
}
