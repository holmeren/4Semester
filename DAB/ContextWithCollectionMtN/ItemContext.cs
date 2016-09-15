using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextWithCollectionMtN
{
    class ItemContext
    {
        public ItemContext() {
            XCollection = new List<ItemX>();
            YCollection = new List<ItemY>();
        }
        public List<ItemX> XCollection { get; set; }
        public List<ItemY> YCollection { get; set; }
    }
}
