using System;
using CarFactory.Car;
using CarFactory.Custom;

namespace CarFactory.CarPart
{
    public abstract class CarPart
    {
        public static event Logger.LogHandler Log;
        public CarPart(int count, string manufacturer)
        {
            _id = Guid.NewGuid();
            _count = count;
            _manufacturer = manufacturer;
        }
        
        private Guid _id;
        public Guid Id => _id;
        protected abstract int _cost { get; set; }
        
        protected abstract string _name { get; }
        private int _count { get; }
        private string _manufacturer { get; }
        public string Name => _name;
        public int Cost => _cost;
        public int Count => _count;
        public string Manufacturer => _manufacturer;
        public abstract IActionPossible AvailableForThisCar<T>(Car<T> carParts) where T : CarPart;
    }
}