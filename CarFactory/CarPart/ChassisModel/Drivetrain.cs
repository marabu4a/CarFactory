using System;
using CarFactory.Custom;

namespace CarFactory.CarPart.ChassisModel
{
    public class Drivetrain : CarPart
    {
        public override int _cost { get; }

        public Drivetrain(DrivetrainType type, int cost, string manufacturer) : base(1, manufacturer)
        {
            Type = type;
            _cost = cost;
        }

        public enum DrivetrainType
        {
            Allwheel,
            Rearwheel,
            Frontwheel
        }

        public DrivetrainType Type { get; }

        public override IActionPossible AvailableForThisCar(Car.Car car)
        {
            return new ActionPossible();
        }
    }
}