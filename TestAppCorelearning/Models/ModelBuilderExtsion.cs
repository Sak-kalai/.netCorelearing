using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppCorelearning.Models
{
    public static class ModelBuilderExtsion
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee() { Id = 1, Name = "kalai", Email = "kalai.nemesis@gmail.com", Deptartment = Dept.Maths }
               );
        }
    }
}
