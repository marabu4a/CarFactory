using System;
using CarFactory.Car;
using CarFactory.Custom;

namespace CarFactory.CarPart.ChassisModel
{
    public class Suspension : CarPart
    {
        protected override string _name => "Подвеска";

        public Suspension(SuspensionType type,int cost,string manufacturer) : base(1,manufacturer)
        {
            _cost = cost;
            Type = type;
        }

        public enum SuspensionType
        {
            Dependent,
            Independent,
            SemiIndependent
        }
        
        public override string ToString()
        {
            return String.Format(
                " --- {0} : цена: {1}, тип подвески: {2}, количество: {3}, призводитель: {4}", Name,
                Cost, Type, Count, Manufacturer);
        }
        
        public SuspensionType Type { get; }
        protected override int _cost { get; set; }

        public override IActionPossible AvailableForThisCar<T>(Car<T> car)
        {
            return new ActionPossible();
        }
        
    }
}