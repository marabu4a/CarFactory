using System;
using CarFactory.Car;
using CarFactory.Custom;
using static CarFactory.Car.BodyType;

namespace CarFactory.CarPart.ChassisModel
{
    public class BrakeSystem : CarPart
    {
        protected override int _cost { get; set; }

        protected override string _name => "Тормозная система";

        public BrakesType Type { get; }
        
        public enum BrakesType
        {
            Disc,
            VentilatedDisc,
            Drum
        }
        public BrakeSystem(BrakesType type, int cost, string manufacturer) : base(1,manufacturer)
        {
            Type = type;
            _cost = cost;
        }

        public override string ToString()
        {
            return String.Format(
                " --- {0}: цена: {1}, тип тормозной системы: {2}, количество: {3}, призводитель: {4}", Name,
                Cost, Type, Count, Manufacturer);
        }

        public override IActionPossible AvailableForThisCar<T>(Car<T> car)
        {
            if (Type == BrakesType.Drum && (car.Body.Type == Offroad || car.Body.Type == SUV))
            {
                return new ActionImpossible("Drum brakes can't be installed to SUV or Offroad");
            }
            return new ActionPossible();
        }
    }
}