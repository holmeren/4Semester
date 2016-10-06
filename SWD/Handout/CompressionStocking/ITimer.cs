using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking
{
   public interface ITimer
   {
       void setTime(int t);
        bool startTime();
    }

    public class Timer : ITimer
    {
        private int _time;

        public Timer()
        {
            _time = 0;
        }

        public void setTime(int t)
        {
            _time = t;
        }

        public bool startTime()
        {
            while (_time > 0)
            {
                _time--;
                System.Threading.Thread.Sleep(1000);
            }
            return false;
        }
    }
}
