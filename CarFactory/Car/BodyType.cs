using System;
using CarFactory.Custom;

namespace CarFactory.Car
{

    public class Body : CarPart.CarPart
    {
        protected override int _cost { get; set; }
        private BodyType _type;

        public BodyType Type => _type;

        protected override string _name => "Кузов";

        public override IActionPossible AvailableForThisCar<T>(Car<T> carParts)
        {
            return new ActionPossible();
        }

        public override string ToString()
        {
            return $" --- {Name}: , цена: {Cost}, тип: {Type}, производитель: {Manufacturer}";
        }

        public Body(int cost,BodyType type, string manufacturer) : base(1, manufacturer)
        {
            _cost = cost;
            _type = type;
        }
    }
    public enum BodyType
    {
        SUV,
        Van,
        Roadster,
        Coupe,
        Hatchback,
        Sedan,
        Offroad
    }
}