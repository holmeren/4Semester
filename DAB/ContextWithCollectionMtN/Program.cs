using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextWithCollectionMtN
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemContext currentcontext = new ItemContext();

            ItemX curx = new ItemX();
            ItemY cury = new ItemY();
           
            curx.ValX1 = 1;
            curx.ValX2 = "First Item X";
            curx.MyYs.Add(cury); //Associated to Current Y

            cury.ValY1 = 1;
            cury.ValY2 = "First Item Y";
            cury.MyXs.Add(curx); //Associated to Current X

            System.Console.WriteLine("From CurrentY: "+cury.ValY2);//Simple test
            currentcontext.XCollection.Add(curx);//Add curx to context
            currentcontext.YCollection.Add(cury);//Add cury to context
            System.Console.WriteLine("Same From context: "+currentcontext.YCollection[0].ValY2);//Simple test

            curx = new ItemX();
            curx.MyYs.Add(cury); //Associated new current x to current y
            curx.ValX1 = 2;
            currentcontext.XCollection.Add(curx); //Add new curx to context
            cury.MyXs.Add(curx); //Associate current y to current x
            curx.ValX2 = "Second Item X 2";
            
            var temp1 = curx.Clone(); //Shallow clone current x
            currentcontext.XCollection.Add(temp1); //Add currx to context

            var yc = cury.Clone();
            temp1.MyYs.Add(yc); //Associate shallow clone of current y to temp1
            currentcontext.YCollection.Add(yc); //Add the newly to temp2 associated ItemY to context
            //temp1.MyYs[1] also reefers to clone instance of Item
            var temp2 = curx.DeepClone();//Deep clone curx, including its own list of associated ItemY
            currentcontext.XCollection.Add(temp2);//Add temp2 to context 

            var ydc = cury.DeepClone();
            temp2.MyYs.Add(ydc); //Associate Deep Clone of cury with temp2
            currentcontext.YCollection.Add(ydc);
            //temp2.MyYs[3]) also reefers to ydc deep clone instance of ItemY
            temp1.MyYs.Add(ydc); //Now associate ydc with temp1 and  ???? 

            //Next Step Persist context into a database, ie. save changes/added items with their associations

        }
    }
}
