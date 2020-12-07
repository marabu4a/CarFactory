using System;
using CarFactory.Car;
using CarFactory.Custom;

namespace CarFactory.CarPart.TransmissionModel
{
    public class Clutch : CarPart
    {
        protected override int _cost { get; set; }
        protected override string _name => "Сцепление";

        public override string ToString()
        {
            return String.Format("{0} : цена: {1}, производитель : {2}", Name, Cost, Manufacturer);
        }

        public Clutch(int cost, string manufacturer) : base(1, manufacturer)
        {
            _cost = cost;
        }

        public override IActionPossible AvailableForThisCar<T>(Car<T> car)
        {
            return new ActionPossible();
        }
    }
}