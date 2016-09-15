using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoStuff
{
    public class DoStuff
    {

    }

    public class DoHickey : IDoThings
    {
        public void DoNothing()
        {
            System.Console.WriteLine("DoHickey and DoNothing");
        }

        public int DoSomething(int number)
        {
            System.Console.WriteLine("DoHickey and DoSomehing nr. " + number);
            return number;
        }

        public string DoSomethingElse(string input)
        {
            System.Console.WriteLine("DoHickey and DoSomethingElse text er " + input);
            return input;
        }
    }

    public class DoDickey : IDoThings
    {
        public void DoNothing()
        {
            System.Console.WriteLine("DoDickey and DoNothing");
        }

        public int DoSomething(int number)
        {
            System.Console.WriteLine("DoDickey and DoSomehing nr. " + number);
            return number;
        }

        public string DoSomethingElse(string input)
        {
            System.Console.WriteLine("DoDickey and DoSomethingElse text er " + input);
            return input;
        }
    }
}
