namespace CarFactory
{
    public class Suspension : CarPart
    {
        private int _cost;

        public override int Cost
        {
            get => _cost;
            set => _cost = value;
        }

        public override bool availableForThisCar(Car.Car car)
        {
            return true;
        }
    }
}