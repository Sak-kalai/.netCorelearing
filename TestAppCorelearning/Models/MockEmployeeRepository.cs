using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppCorelearning.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee(){Id=1,Name="kalai",Email="kalai.nemesis@gmail.com",Deptartment=Dept.Maths},
                new Employee(){Id=2,Name="Gowsi", Email="gowsikalai@gmail.com", Deptartment=Dept.Science},

            };
        }

        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}
