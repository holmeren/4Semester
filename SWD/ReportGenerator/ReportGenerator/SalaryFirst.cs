using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SalaryFirst : IReportGenerator
    {
        private readonly EmployeeDB _employeeDb;

        public SalaryFirst(EmployeeDB employeeDb)
        {
            if (employeeDb == null) throw new ArgumentNullException("employeeDb");
            _employeeDb = employeeDb;
        }
        public void CompileReport()
        {
            var employees = new List<Employee>();
            Employee employee;

            while ((employee = _employeeDb.GetNextEmployee()) != null)
            {
                employees.Add(employee);

            }

            Console.WriteLine("Salary-first report");
            foreach (var e in employees)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("Salary: {0}", e.Salary);
                Console.WriteLine("Name: {0}", e.Name);
                Console.WriteLine("Age: {0}", e.Age);
                Console.WriteLine("------------------");
            }
        }
    }
}
