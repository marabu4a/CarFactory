using System;
using CarFactory.Car;

namespace CarFactory.Custom
{
    public class CarException : Exception
    {
        private static readonly string defaultCarExceptionMessage = "У этой машины неизвестная проблема!";

        public Car<CarPart.CarPart> Car { get; }

        public CarException() : base(defaultCarExceptionMessage)
        {
        }

        public CarException(string message, Guid carId) : base($"У этой машины с id: {carId} проблемы!: {message}")
        {
        }

        public CarException(string message, Car<CarPart.CarPart> car) : base(message)
        {
            Car = car;
        }

        public CarException(string message, Exception innerException) : base(
            $"Эта машина имеет проблемы: {message}", innerException)
        {
        }
    }
}