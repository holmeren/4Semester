using System;

namespace ReportGenerator
{
    internal class ReportGeneratorClient
    {
        private static void Main()
        {
            var db = new EmployeeDB();

            // Add some employees
            db.AddEmployee(new Employee("Anne", 3000, 30));
            db.AddEmployee(new Employee("Berit", 2000, 24));
            db.AddEmployee(new Employee("Christel", 1000, 42));

            var reportGenerator = new NameFirst(db);

            // Create a default (name-first) report
            reportGenerator.CompileReport();

            Console.WriteLine("");
            Console.WriteLine("");

            db.Reset();
            // Create a salary-first report
           var reportGenerator1 = new SalaryFirst(db);
            reportGenerator1.CompileReport();

            db.Reset();

            var reportGenerator2 = new AgeFirst(db);
            reportGenerator2.CompileReport();
        }
    }
}