using System;
using System.Collections.Generic;
using System.Linq;
using CarFactory.Car;
using CarFactory.Custom;

namespace CarFactory
{
    class Program
    {
        public static event Logger.LogHandler Log;

        static void Main(string[] args)
        {
            Log += Logger.LogInConsole;
            Log += Logger.LogInFile;
            
            Log("Производим первую машину:\n");
            var carFactory = new Factory.CarFactory();
            var firstCar = carFactory.ConstructCar();

            Log(firstCar.ToString());
            Log("\n \n \n Производим вторую машину:\n");

            var secondCar = carFactory.ConstructCar();

            Log(secondCar.ToString());

            firstCar.Sort();
            firstCar.Sort(CarPartsComparer.CompareByManufacturer);

            foreach (var carPart in firstCar)
            {
                Log($"Цена: {carPart.Cost}");
            }

            firstCar.Sort(CarPartsComparer.CompareByManufacturer);

            foreach (var carPart in firstCar)
            {
                Log($"Производитель: {carPart.Manufacturer}");
            }
        }
    }
}