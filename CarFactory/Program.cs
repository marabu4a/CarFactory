using System;

namespace CarFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var carFactory = new Factory.CarFactory();
            carFactory.ConstructCar();
        }
    }
}