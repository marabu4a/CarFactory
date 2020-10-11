using System;
using System.Collections.Generic;

namespace CarFactory
{
    public abstract class CarPart
    {
        private int _count;
        private string _manufacturer;

        public abstract int Cost { get; set; }

        public abstract bool availableForThisCar(Car.Car car);
        public int Count
        {
            get => _count;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Количество должно быть больше 0");
                }
                else
                {
                    _count = value;
                }
            }
        }
        public string Manufacturer 
        {
            get => _manufacturer;
            set
            {
                if (value.Length == 0)
                {
                    Console.WriteLine("Название производителя должно быть больше 0");
                }
                else
                {
                    _manufacturer = value;
                }
            }
        }

        public int GetCost()
        {
            return Cost;
        }

        public int GetCount()
        {
            return Count;
        }

        public string GetManufacturer()
        {
            return Manufacturer;
        }
    }
}