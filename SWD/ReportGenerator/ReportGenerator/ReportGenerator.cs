using System;
using System.Collections.Generic;

namespace ReportGenerator
{
    public enum ReportOutputFormatType
    {
        NameFirst,
        SalaryFirst
    }

    internal class ReportGenerator
    {
        //private readonly EmployeeDB _employeeDb;
        private ReportOutputFormatType _currentOutputFormat;
        private IEmployeeStorage _storage;
        private IFormat _format;


        public ReportGenerator(IEmployeeStorage storage)
        {
            _storage = storage;
        }


        public void CompileReport()
        {
            _format = new FormatSalary();
        }


    }
}