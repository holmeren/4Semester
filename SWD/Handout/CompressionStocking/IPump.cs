using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CompressionStocking
{
   public interface IPump
    {
        void Forward();
        void Reverse();
    }

    public class PumpCtrl : IPump
    {

        
        public void Forward()
        {
            
        }

        public void Reverse()
        {
            
        }
    }
}
