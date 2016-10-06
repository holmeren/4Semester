using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class FormatSalary : IFormat
    {
        private string salString = null;
        private string nameString = null;
        private string ageString = null;
        private string lineString = null;
        private string formatted = null;
        public string FormatString(List<Employee> emp)
        {

            foreach (var e in emp)
            {
                formatted += lineString+"\n";
                formatted += salString + "\n";
                formatted += nameString + "\n";
                formatted += ageString + "\n";
                formatted += lineString + "\n";
                
            }
            return formatted;
        }
    }
}
