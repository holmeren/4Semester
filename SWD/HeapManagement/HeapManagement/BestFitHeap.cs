using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapManagement
{
    public class BestFitHeap : Heap
    {
        public BestFitHeap(int size) : base(size)
        {
        }

        protected override int FindBuffer(int size, List<Block> candidates)
        {
            if (candidates.Count == 0) throw new HeapManagementException("Unable to allocate memory", 0, size);

            var BestAdress = candidates[0].StartAddr;
            var BestLength = candidates[0].Length;
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].Length < BestLength)
                {
                    BestLength = candidates[i].Length;
                    BestAdress = candidates[i].StartAddr;
                }
            }

            return BestAdress;
        }
    }
}
