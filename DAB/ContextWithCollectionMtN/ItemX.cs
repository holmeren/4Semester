using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextWithCollectionMtN
{
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/system.object.memberwiseclone(v=vs.110).aspx
    /// </summary>
    class ItemX
    {
        public ItemX()
        {
            MyYs = new List<ItemY>();
            MyUUIDX = Guid.NewGuid(); //Identification of instance Only for unique identitication
        }
        public ItemX Clone()
        {
            return (ItemX)this.MemberwiseClone();//ShallowCopy !!! 
            // What is the problem here??
        }

        public ItemX DeepClone()
        {
            ItemX locx = (ItemX)this.MemberwiseClone(); //ShallowCopy 
            locx.MyUUIDX = Guid.NewGuid(); //Only for unique identitication
            locx.MyYs = new List<ItemY>(); // Give new instance its own ItemY references
            foreach (var y in this.MyYs)
                locx.MyYs.Add(y);
            return locx;
        }

        public int ValX1 { get; set; }
        public string ValX2 { get; set; }
        public List<ItemY> MyYs { get; set; }
        public Guid MyUUIDX { get; private set; }
    }
}
