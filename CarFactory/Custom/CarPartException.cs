using System;

namespace CarFactory.Custom
{
    public class CarPartException : ArgumentException
    {
        
        public CarPart.CarPart CarPart { get; }

        public DateTime dateTime { get; }

        public CarPartException(string message, CarPart.CarPart carPart) : base(message)
        {
            CarPart = carPart;
            dateTime = DateTime.Now;
        }
    }
}