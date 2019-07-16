using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppCorelearning.Models
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbcontext context;
        private readonly ILogger<SqlEmployeeRepository> logger;

        public SqlEmployeeRepository(AppDbcontext dbcontext, ILogger<SqlEmployeeRepository> logger)
        {
            context = dbcontext;
            this.logger = logger;
        }

        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            logger.LogTrace("Getting all Employee Details");
            var employeesRstls = context.Employees;
            logger.LogInformation("Pulled all the information success fully");
            return employeesRstls;
        }
    }
}
