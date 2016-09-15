using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoStuff.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IDoThings myShit = null;

            string choose = System.Console.ReadLine();

            if (choose == "1")
            {
                myShit = new DoHickey();

                
            }

            if (choose == "2")
            {
                myShit = new DoDickey();

         
            }
            myShit.DoNothing();

            myShit.DoSomething(2);

            myShit.DoSomethingElse("lol");
        }
    }
}
