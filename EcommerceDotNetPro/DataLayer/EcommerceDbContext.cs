using EcommerceDotNetPro.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EcommerceDotNetPro.DataLayer
{
    public class EcommerceDbContext: DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }

       // public DbSet<RequestSignup> Customer { get; set; }

        public DbSet<RequestSignup> Customer { get; set; }


    }
}
        