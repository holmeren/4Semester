using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompressionStocking.Mechanisms.Compression;

namespace CompressionStocking.BusinessLogic
{
   public interface IStockingFactory
    {
        ICompressionMechanism CreateCompressionMechanism();
    }
}
