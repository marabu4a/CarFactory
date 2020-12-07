using System;
using System.Collections.Generic;
using CarFactory.Car;
using CarFactory.CarPart.EngineModel;
using CarFactory.Custom;
using Microsoft.VisualBasic;

namespace CarFactory.CarPart.TransmissionModel
{
    public class Transmission : ComponentCarPart
    {
        protected override int _cost { get; set; }
        protected override string _name => "Трансмиссия";

        private Clutch _clutch { get; set; }
        private TransmissionType _type;

        public Clutch Clutch => _clutch;
        public TransmissionType Type => _type;

        public Transmission(TransmissionType type, int cost, string manufacturer,Clutch clutch) : base(1, manufacturer)
        {
            _clutch = clutch;
            _cost = cost + _clutch.Cost;
            _type = type;
        }
        public override bool HasAllComponents()
        {
            return _clutch != null;
        }

        public override IActionPossible AvailableForThisCar<T>(Car<T> car)
        {
            if (car.Engine.Type == EngineType.Electric)
            {
                return new ActionImpossible("Electric car cannot have transmission");
            }
            return new ActionPossible();
        }

        public override string ToString()
        {
            return String.Format(" --- {0} : тип трансмиссии {1} , цена : {2}, производитель : {3}\n", Name,Type, Cost, Manufacturer);
        }

        public override void AddComponent(CarPart carPart)
        {
            _carParts.Add(carPart);
        }

        public override void RemoveComponent(CarPart carPart)
        {
            _carParts.Remove(carPart);
        }
    }
}