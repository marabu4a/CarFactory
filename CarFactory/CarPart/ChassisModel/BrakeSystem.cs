using CarFactory.Custom;
using static CarFactory.Car.BodyType;

namespace CarFactory.CarPart.ChassisModel
{
    public class BrakeSystem : CarPart
    {
        public override int _cost { get;}

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

        public override IActionPossible AvailableForThisCar(Car.Car car)
        {
            if (Type == BrakesType.Drum && car.BodyType == Offroad || car.BodyType == SUV)
            {
                return new ActionImpossible("Drum brakes can't be installed to SUV or Offroad");
            }
            return new ActionPossible();
        }
    }
}