using System;
using CarFactory.Car;
using CarFactory.Custom;

namespace CarFactory.CarPart.EngineModel
{
    public class FuelSystem : CarPart
    {
        protected override int _cost { get; set; }
        protected override string _name => "Топливная система";
        public FuelSystemType Type { get; }

        public FuelSystem(int cost, FuelSystemType type, string manufacturer) : base(1, manufacturer)
        {
            _cost = cost;
            Type = type;
        }

        public enum FuelSystemType
        {
            GDI,
            MPI,
            TDI
        }

        public override string ToString()
        {
            return String.Format(" --- {0} : тип топливной системы: {1} , цена: {2} ", Name, Cost,
                Manufacturer);
        }

        public override IActionPossible AvailableForThisCar<T>(Car<T> car)
        {
            if (Type == FuelSystemType.MPI && car.Engine.Type == EngineType.Diesel)
            {
                return new ActionImpossible("MPI cannot be added to diesel engine");
            }

            if (Type == FuelSystemType.TDI && car.Engine.Type == EngineType.Petrol)
            {
                return new ActionImpossible("TDI cannot be added to petrol engine");
            }

            if (car.Engine.Type == EngineType.Electric)
            {
                return new ActionImpossible("Electric car has no fuel system");
            }

            return new ActionPossible();
        }
    }
}