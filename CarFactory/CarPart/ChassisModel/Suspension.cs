using System;
using CarFactory.Custom;

namespace CarFactory.CarPart.ChassisModel
{
    public class Suspension : CarPart
    {
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
        
        public SuspensionType Type { get; }
        public override int _cost { get; }

        public override IActionPossible AvailableForThisCar(Car.Car car)
        {
            return new ActionPossible();
        }
        
    }
}