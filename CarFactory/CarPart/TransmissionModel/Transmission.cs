using System.Collections.Generic;
using CarFactory.CarPart.EngineModel;
using CarFactory.Custom;

namespace CarFactory.CarPart.TransmissionModel
{
    public class Transmission : ComponentCarPart
    {
        public override int _cost { get; }

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
        public override bool HasAllComponent()
        {
            return _clutch != null;
        }

        public override IActionPossible AvailableForThisCar(Car.Car car)
        {
            if (car.Engine.Type == EngineType.Electric)
            {
                return new ActionImpossible("Electric car cannot have transmission");
                
            }
            return new ActionPossible();
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