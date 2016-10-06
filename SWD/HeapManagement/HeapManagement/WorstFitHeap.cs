using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapManagement
{
   public class WorstFitHeap : Heap
    {
        public WorstFitHeap(int size) : base(size)
        {
        }

        protected override int FindBuffer(int size, List<Block> candidates)
        {
            if (candidates.Count == 0) throw new HeapManagementException("Unable to allocate memory", 0, size);

            var worstAdress = candidates[0].StartAddr;
            var worstLength = candidates[0].Length;
            for(int i = 0; i<candidates.Count; i++)
            {
                if (candidates[i].Length > worstLength)
                {
                    worstLength = candidates[i].Length;
                    worstAdress = candidates[i].StartAddr;
                }
            }

            return worstAdress;
        }
    }
}
