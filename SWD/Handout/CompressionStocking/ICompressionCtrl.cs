namespace CompressionStocking
{
    public interface ICompressionCtrl
    {
        void Compress();
        void Decompress();
    }

    public class CompressionCtrl : ICompressionCtrl
    {
        private readonly IPump _pumpCtrl;
        private ITimer _time;
        private ILed _led;
        private IVib _vib;
        

        public CompressionCtrl(IPump pumpCtrl)
        {
            _pumpCtrl = pumpCtrl;

        }
        public void Compress()
        {
            _time.setTime(5);
            while (_time.startTime())
            {
                _pumpCtrl.Forward();
                _led.TurnOn("green");
                _vib.StartVib();
            }
            _vib.StopVib();
            _led.TurnOff("green");
        }

        public void Decompress()
        {
            _time.setTime(2);
            while (_time.startTime())
            {
                _pumpCtrl.Reverse();

                _led.TurnOn("red");
                _vib.StartVib();
            }
            _vib.StopVib();
            _led.TurnOff("red");
        }
        
    }
}