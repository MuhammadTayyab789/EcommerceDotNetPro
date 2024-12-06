using EcommerceDotNetPro.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;

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
        public async Task<bool> AuthenticateUserAsync(mLogin user)
        {

            // Validate input
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                return false;

            // Use LINQ to query the database for matching user
            var isUserAuthenticated = await _dbcontext.User
            .AnyAsync(u => u.UserName == user.UserName && u.Password == user.Password);

            return isUserAuthenticated;

         
        }
    }
}
