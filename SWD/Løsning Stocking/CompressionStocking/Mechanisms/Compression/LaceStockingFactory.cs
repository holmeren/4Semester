using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompressionStocking.BusinessLogic;
using CompressionStocking.Devices.Compression;

namespace CompressionStocking.Mechanisms.Compression
{
   public class LaceStockingFactory : IStockingFactory
    {
        public ICompressionMechanism CreateCompressionMechanism()
        {
            return new LaceCompressionMechanism(100 , 200, new LaceTighteningDevice());
        }
    }
}
