using System;
using System.Threading;
using CarFactory.Car;
using CarFactory.CarPart.ChassisModel;
using CarFactory.CarPart.EngineModel;
using CarFactory.CarPart.TransmissionModel;
using CarFactory.Custom;

namespace CarFactory.Factory
{
    public class CarFactory : IFactory
    {
        private ChassisFactory _chassisFactory = new ChassisFactory();
        private EngineFactory _engineFactory = new EngineFactory();
        private TransmissionFactory _transmissionFactory = new TransmissionFactory();
        private Car.Car _car = new Car.Car();

        private Car.Car CreateCar()
        {
            Console.WriteLine("Инициализация....");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Выбираю тип кузова...");
            Thread.Sleep(2000);
            _car.AddBodyType(CreateBodyType());
            Console.WriteLine("Создаю шасси....");
            Thread.Sleep(2000);
            AddChassis();
            Console.WriteLine("Создаю двигатель....");
            AddEngine();
            Thread.Sleep(2000);
            Console.WriteLine("Создаю трансмиссию...");
            Thread.Sleep(2000);
            AddTransmission();
            return _car;
        }
        public void ConstructCar()
        {
            var newCar = CreateCar();
            if (CanGetThisCar(newCar).IsPossible)
            {
                Console.WriteLine("Машина создана!"
                );
            }
            else
            {
                Console.WriteLine(CanGetThisCar(newCar).Reason);
            }
        }

        private void AddEngine()
        {
            var newEngine = CreateEngine();
            while (!_car.AddEngine(newEngine))
            {
                Console.WriteLine("Данный двигатель не подойдет,создаю другой");
                newEngine = CreateEngine();
            }
        }

        private void AddChassis()
        {
            var newChassis = CreateChassis();
            while (!_car.AddChassis(newChassis))
            {
                Console.WriteLine("Данное шасси не подходит к этому автомобилю,создаю другое");
                newChassis = CreateChassis();
            }
        }

        private void AddTransmission()
        {
            var newTransmission = CreateTransmissin();
            while (!_car.AddTransmission(newTransmission))
            {
                Console.WriteLine("Данная трансмиссия не походит к этому автомобилю, создаю другую");
                newTransmission = CreateTransmissin();
            }
        }

        private BodyType CreateBodyType()
        {
            Array types = Enum.GetValues(typeof(BodyType));
            return (BodyType) types.GetValue(randomGenerator.GetRandomValue(types.Length));
        }


        private Chassis CreateChassis()
        {
            return (Chassis) _chassisFactory.Create();
            
        }

        private Engine CreateEngine()
        {
            return (Engine) _engineFactory.Create();
        }

        private Transmission CreateTransmissin()
        {
            return (Transmission) _transmissionFactory.Create();
        }

        public CarFactory()
        {
            Reset();
        }

        public void Reset()
        {
            _car = new Car.Car();
        }

        private IActionPossible CanGetThisCar(Car.Car car)
        {
            if (car == null)
            {
                return new ActionImpossible("the car can't be null,create it!");
            }

            if (!car.HasAllMainParts())
            {
                return new ActionImpossible("the car does not yet have all the main parts");
            }

            return new ActionPossible();
        }
    }
}