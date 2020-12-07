using System;
using CarFactory.Car;
using CarFactory.Custom;

namespace CarFactory.CarPart.ChassisModel
{
    public class Drivetrain : CarPart
    {
        protected override int _cost { get; set; }

        protected override string _name => "Привод";
        

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
        public override string ToString()
        {
            return String.Format(
                " --- {0}: цена: {1}, тип привода: {2}, количество: {3}, призводитель: {4}", Name,
                Cost, Type, Count, Manufacturer);
        }
        

        public DrivetrainType Type { get; }

        public override IActionPossible AvailableForThisCar<T>(Car<T> car)
        {
            return new ActionPossible();
        }
    }
}