namespace CarFactory
{
    public class Engine : CarPart
    {
        public override int Cost { get; set; }

        public override bool availableForThisCar(Car.Car car)
        {
            return true;
        }
    }
}