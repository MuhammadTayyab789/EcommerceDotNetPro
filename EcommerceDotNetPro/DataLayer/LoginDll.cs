using EcommerceDotNetPro.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Identity;

namespace EcommerceDotNetPro.DataLayer
{
    public class LoginDll
    {
        public readonly EcommerceDbContext _dbcontext;

        public LoginDll(EcommerceDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public LoginDll()
        {
        }
        public async Task<bool> AuthenticateUserAsync(RequestLogin user)
        {
           
            // Validate input
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                return false;
            var existingUsers = await _dbcontext.Customer.Where(u => u.UserName == user.UserName).ToListAsync(); 
               foreach (var existu in existingUsers)
            {
                var passwordHasher = new PasswordHasher<object>();
                var result = passwordHasher.VerifyHashedPassword(null, existu.Password, user.Password);
                if (result == PasswordVerificationResult.Success)
                {
                    return true; // Authentication successful
                }

            }



            return false;
           



        }
    }
}
