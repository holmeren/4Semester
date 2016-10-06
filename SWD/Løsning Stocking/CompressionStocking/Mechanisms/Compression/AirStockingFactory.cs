using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompressionStocking.BusinessLogic;
using CompressionStocking.Devices.Compression;

namespace CompressionStocking.Mechanisms.Compression
{
    public class AirStockingFactory : IStockingFactory
    {
        public ICompressionMechanism CreateCompressionMechanism()
        {
            return new AirCompressionMechanism(new Pump(), 10 ,4);
        }
    }
}
