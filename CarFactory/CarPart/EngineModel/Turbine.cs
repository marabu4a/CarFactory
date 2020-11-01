using CarFactory.Custom;

namespace CarFactory.CarPart.EngineModel
{
    public class Turbine : CarPart
    {
        public override int _cost { get; }


        public Turbine(int cost, string manufacturer) : base(1, manufacturer)
        {
            _cost = cost;
        }

        public override IActionPossible AvailableForThisCar(Car.Car car)
        {
            switch (car.Engine.Type)
            {
                case EngineType.Diesel:
                {
                    return new ActionPossible();
                }
                case EngineType.Electric:
                {
                    return new ActionImpossible("Turbine cant be installed to electric engine");
                }
            }

            if (car.Engine.FuelSystem.Type == FuelSystem.FuelSystemType.MPI)
            {
                return new ActionImpossible("Turbine cant be installed to MPI engine");
            }

            return new ActionPossible();
        }
    }
}