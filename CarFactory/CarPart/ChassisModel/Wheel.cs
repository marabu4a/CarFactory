using CarFactory.Custom;

namespace CarFactory.CarPart.ChassisModel
{
    public class Wheel : CarPart
    {
        public override int _cost { get; }

        public Wheel(int cost, string manufacturer) : base(4,manufacturer)
        {
            _cost = cost * 4;
        }
        public override IActionPossible AvailableForThisCar(Car.Car car)
        {
            return new ActionPossible();
        }
        
    }
}