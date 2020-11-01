using System;
using CarFactory.Custom;

namespace CarFactory.CarPart
{
    public abstract class CarPart
    {

        public CarPart(int count, string manufacturer)
        {
            _count = count;
            _manufacturer = manufacturer;
        }
        public abstract int _cost { get; }
        protected int _count { get; }
        protected string _manufacturer { get; }

        public int Cost => _cost;
        public int Count => _count;
        public string Manufacturer => _manufacturer;
        public abstract IActionPossible AvailableForThisCar(Car.Car car);
    }
}