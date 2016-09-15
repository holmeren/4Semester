using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class AgeFirst : IReportGenerator
    {
        private readonly EmployeeDB _employeeDb;

        public AgeFirst(EmployeeDB employeeDb)
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

            Console.WriteLine("Age-first report");
            foreach (var e in employees)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("Age: {0}", e.Age);
                Console.WriteLine("Name: {0}", e.Name);
                Console.WriteLine("Salary: {0}", e.Salary);
                Console.WriteLine("------------------");
            }
        }
    }
}
