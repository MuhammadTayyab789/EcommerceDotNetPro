using EcommerceDotNetPro.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EcommerceDotNetPro.DataLayer
{
    public class Signupdll
    {
        public readonly EcommerceDbContext _dbcontext;

        public Signupdll(EcommerceDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        /*public LoginDll()
        {
        }*/
        public async Task<bool> CreateUserindbAsync(RequestSignup user)
        {

            // Validate input
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Phone) )
                return false;

            // Use LINQ to query the database for matching user

            var newuser = new RequestSignup
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone
            };
            var isusercreated = await _dbcontext.Customer.AddAsync(newuser);
            await _dbcontext.SaveChangesAsync();
            if (isusercreated==null)
            {
                return false;
            }
            
            

            return true;

        }
    }
}
