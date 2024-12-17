using Azure.Core;
using EcommerceDotNetPro.BusinessLogic.JWT;
using EcommerceDotNetPro.DataLayer;
using EcommerceDotNetPro.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace EcommerceDotNetPro.BusinessLogic.Authentication
{
    public class LoginService
    {
        private readonly LoginDll _loginDll;
        private readonly TokenService _tokenService;

        public LoginService(LoginDll loginDll ,TokenService tokenService)
        {
            _loginDll = loginDll;
            _tokenService = tokenService;
        }

    public async Task<ResponseLogin> FuncLoginUser(RequestLogin req)
        {     
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password))
            {
                throw new ArgumentException("Username or password cannot be empty.");
            }

            bool isAuthenticated = await _loginDll.AuthenticateUserAsync(req);
            if (isAuthenticated)
            {


                var token = _tokenService.GenerateToken(req.UserName);
                return new ResponseLogin
                {
                    UserName = req.UserName,
                    Token = token,
                };
                
            }

            // If authentication fails, return null or throw an exception
            return null;
        }





    }

}
