﻿using EcommerceDotNetPro.DataLayer;
using EcommerceDotNetPro.Models;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
namespace EcommerceDotNetPro.BusinessLogic.Authentication
{
    public class SignupService
    {
        private readonly Signupdll _signupdll;
        public SignupService(Signupdll signupdll)
        {
            _signupdll = signupdll;
        }
        public async Task<RequestSignup> FuncCreateUser(RequestSignup model) {


            var passwordHasher = new PasswordHasher<object>();

            string password = model.Password;
            string hashedPassword = passwordHasher.HashPassword(null, password);
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            // Map properties (if necessary)
            var user = new RequestSignup
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = hashedPassword,
                Phone = model.Phone
            };

            // Add the new user to the database
            // await _dbcontext.signup.AddAsync(user);
            //await _dbcontext.SaveChangesAsync();

            // Return the created user

            var response = await _signupdll.CreateUserindbAsync(user);
            if (!response)
            {
                return null;
            }
            return (user);

        }







    }

}
#region

#endregion