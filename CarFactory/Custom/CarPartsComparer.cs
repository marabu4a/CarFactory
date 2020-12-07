using System;
using CarFactory.Car;

namespace CarFactory.Custom
{
    public static class CarPartsComparer
    {
        public static int CompareByCost(CarPart.CarPart firstPart, CarPart.CarPart secondPart)
        {
            return firstPart.Cost.CompareTo(secondPart.Cost);
        }

        public static int CompareByCount(CarPart.CarPart firstPart, CarPart.CarPart secondPart)
        {
            return firstPart.Count.CompareTo(secondPart.Count);
        }

        public static int CompareByManufacturer(CarPart.CarPart firstPart, CarPart.CarPart secondPart)
        {
            return String.Compare(firstPart.Manufacturer, secondPart.Manufacturer, StringComparison.Ordinal);
        }
    }
}