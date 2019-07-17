using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppCorelearning.Models
{
    public class AppDbcontext : IdentityDbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> option) : base(option)
        {


        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.seed();
        }

    }
}
