using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent06Opgave1
{
    class Specialities : ObservableCollection<string>
    {
        public Specialities()
        {
            Add("hej");
            Add("med");
            Add("dog");
            
        }
    }
}
