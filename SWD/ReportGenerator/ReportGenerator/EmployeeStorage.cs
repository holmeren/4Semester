using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeDB _employees;
        public List<Employee> employees;
        public Employee employee;

        public EmployeeStorage(EmployeeDB employees)
        {
            _employees = employees;
        }

        public List<Employee> GetEmployees()
        {
            while ((employee = _employees.GetNextEmployee()) != null)
            {
                employees.Add(employee);
            }
            return employees;
        }
    }
}
