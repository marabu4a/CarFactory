using System;
using CarFactory.Car;
using CarFactory.Custom;

namespace CarFactory.CarPart.ChassisModel
{
    public class Wheel : CarPart
    {
        protected override string _name => "Колеса";
        protected override int _cost { get; set; }

        public Wheel(int cost, string manufacturer) : base(4, manufacturer)
        {
            _cost = cost * 4;
        }

        public override string ToString()
        {
            return String.Format(" --- {0}: цена за 4 штуки: {1}, цена за 1 колесов: {2} , производитель: {3}", Name, Cost,
                Cost / 4, Manufacturer);
        }

        public override IActionPossible AvailableForThisCar<T>(Car<T> car)
        {
            return new ActionPossible();
        }
    }
}