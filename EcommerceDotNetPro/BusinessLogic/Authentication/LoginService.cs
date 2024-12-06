using EcommerceDotNetPro.DataLayer;
using EcommerceDotNetPro.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace EcommerceDotNetPro.BusinessLogic.Authentication
{
    public class LoginService
    {
        private readonly LoginDll _loginDll;
        public LoginService(LoginDll loginDll)
        {
            _loginDll = loginDll;
        }

    public async Task<RequestLogin> FuncLoginUser(RequestLogin req)
        {
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password))
            {
                throw new ArgumentException("Username or password cannot be empty.");
            }

            bool isAuthenticated = await _loginDll.AuthenticateUserAsync(req);
            if (isAuthenticated)
            {
                // If authentication succeeds, return the user details
                return req;
            }

            // If authentication fails, return null or throw an exception
            return null;
        }


    }
}
