using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Console : IOutput
    {
        public void vomitText(string str)
        {
            System.Console.WriteLine(str);
        }
    }
}
