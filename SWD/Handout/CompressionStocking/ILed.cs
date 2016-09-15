using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompressionStocking
{
    interface ILed
    {
        void TurnOn(string color);
        void TurnOff(string color);
    }

    public class Led : ILed
    {
        private bool greenLed;
        private bool redLed;

        public Led()
        {
            greenLed = false;
            redLed = false;
        }

        public void TurnOn(string color)
        {
            if (color == "red")
                redLed = true;
            else if (color == "green")
                greenLed = true;
            else
            {}
        }

        public void TurnOff(string color)
        {
            if (color == "red")
                redLed = false;
            else if (color == "green")
                greenLed = false;
            else
            { }
        }
    }
}
