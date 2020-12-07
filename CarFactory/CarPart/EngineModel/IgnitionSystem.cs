using System;
using CarFactory.Car;
using CarFactory.Custom;

namespace CarFactory.CarPart.EngineModel
{
    public class IgnitionSystem : CarPart
    {
        public IgnitionSystem(IgnitionSystemType type, int cost, string manufacturer) : base(1, manufacturer)
        {
            Type = type;
            _cost = cost;
        }

        protected override int _cost { get; set; }
        protected override string _name => "Система зажигания";

        public enum IgnitionSystemType
        {
            Electric,
            MechanicallyTimed
        }

        public override string ToString()
        {
            return String.Format(" --- {0}: тип топливной системы: {1}, цена : {2} , производитель: {3}", Name, Type,Cost,
                Manufacturer);
        }

        public IgnitionSystemType Type { get; }

        public override IActionPossible AvailableForThisCar<T>(Car<T> car)
        {
            if (car.Engine.Type == EngineType.Electric)
            {
                return new ActionImpossible("Electric car has no ignition system");
            }

            if (car.Engine.Type == EngineType.Diesel && Type == IgnitionSystemType.MechanicallyTimed)
            {
                return new ActionImpossible("Diesel must have electric ignition");
            }

            return new ActionPossible();
        }
    }
}