using CarFactory.Custom;

namespace CarFactory.CarPart.TransmissionModel
{
    public class Clutch : CarPart
    {
        public override int _cost { get; }

        public Clutch(int cost, string manufacturer) : base(1, manufacturer)
        {
            _cost = cost;
        }

        public override IActionPossible AvailableForThisCar(Car.Car car)
        {
            return new ActionPossible();
        }
    }
}