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
    class ItemY
    {
        public ItemY()
        {
            MyXs = new List<ItemX>();
            MyUUIDY = Guid.NewGuid(); //Identification of instance Only for unique identitication

        }

        public ItemY Clone()
        {
            return (ItemY)this.MemberwiseClone();//ShallowCopy !!! 
            // What is the problem here??
        }

        public ItemY DeepClone()
        {
            ItemY locy = (ItemY)this.MemberwiseClone(); //ShallowCopy !!!  
            locy.MyUUIDY = Guid.NewGuid();//Only for unique identitication
            locy.MyXs = new List<ItemX>(); // Give new instance its own ItemX references
            foreach (var y in this.MyXs)
                locy.MyXs.Add(y);
            return locy;
        }
        public int ValY1 { get; set; }
        public string ValY2 { get; set; }
        public List<ItemX> MyXs { get; set; }
        public Guid MyUUIDY
        {
            get; private set;

        }
    }
}
