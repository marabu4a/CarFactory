using CarFactory.Custom;

namespace CarFactory.CarPart.EngineModel
{
    public class IgnitionSystem : CarPart
    {
        public IgnitionSystem(IgnitionSystemType type, int cost, string manufacturer) : base(1,manufacturer)
        {
            Type = type;
            _cost = cost;
        }

        public override int _cost { get; }

        public enum IgnitionSystemType
        {
            Electric,
            MechanicallyTimed
        }

        public IgnitionSystemType Type { get; }

        public override IActionPossible AvailableForThisCar(Car.Car car)
        {
            if (car.Engine.Type == EngineType.Electric)
            {
                return new ActionImpossible("Electric car has no ignition system");
            }

            if (car.Engine.Type == EngineType.Diesel && Type == IgnitionSystemType.MechanicallyTimed)
            {
                return new ActionImpossible("Diesel must have electric ignition");
            }

            return new ActionPossible();
        }
    }
}