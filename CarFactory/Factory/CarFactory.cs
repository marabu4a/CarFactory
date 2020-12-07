using System;
using System.Threading;
using CarFactory.Car;
using CarFactory.CarPart.ChassisModel;
using CarFactory.CarPart.EngineModel;
using CarFactory.CarPart.TransmissionModel;
using CarFactory.Custom;

namespace CarFactory.Factory
{
    public class CarFactory : IFactory<Car<CarPart.CarPart>>
    {
        protected static event Logger.LogHandler Log;
        private ChassisFactory _chassisFactory = new ChassisFactory();
        private EngineFactory _engineFactory = new EngineFactory();
        private TransmissionFactory _transmissionFactory = new TransmissionFactory();
        private BodyFactory _bodyFactory = new BodyFactory();
        private Car<CarPart.CarPart> _car = new Car.Car<CarPart.CarPart>();
        public override Car<CarPart.CarPart> Create()
        {
            Log("Инициализация....");
            Log("-----------------------");
            Log("Выбираю тип кузова...");
            Thread.Sleep(2000);
            AddBody();
            Log("Создаю шасси....");
            Thread.Sleep(2000);
            AddChassis();
            Log("Создаю двигатель....");
            AddEngine();
            Thread.Sleep(2000); 
            Log("Создаю трансмиссию...");
            Thread.Sleep(2000);
            AddTransmission();
            return _car;
        } 
        public Car<CarPart.CarPart> ConstructCar()
        {
            var newCar = Create();
            if (CanGetThisCar(newCar).IsPossible)
            {
                Log("Машина создана!");
                return newCar;
            }
            throw new CarException("С этой машиной проблемы!",newCar);
        }

        private void AddBody()
        {
            var newBody = CreateBody();
            try
            {
                _car.Add(newBody);
            }
            catch (CarPartException e)
            {
                Log($"Данный кузов {e.CarPart.Id} не подойдет,поставлю другой");
                AddBody();
            }
        }

        private void AddEngine()
        {
            var newEngine = CreateEngine();
            try
            {
                _car.Add(newEngine);
            }
            catch (CarPartException e)
            {
                Log($"  Данный двигатель {e.CarPart.Id}  не подойдет, создаю другой");
                AddEngine();
            }
        }

        private void AddChassis()
        {
            var newChassis = CreateChassis();
            try
            {
                _car.Add(newChassis);
            }
            catch (CarPartException e)
            {
                Log($"Данное шасси {e.CarPart.Id} не подходит к этому автомобилю,создаю другое");
                AddChassis();
            }
        }

        private void AddTransmission()
        {
            var newTransmission = CreateTransmissin();
            try
            {
                _car.Add(newTransmission);
            }
            catch (CarPartException e)
            {
                Log($"$Данная трансмиссия {e.CarPart.Id} не подходит к этому автомобилю, создаю другую");
                AddTransmission();
            }
        }

        private Chassis CreateChassis()
        {
            return (Chassis) _chassisFactory.Create();
        }

        private Engine CreateEngine()
        {
            return (Engine) _engineFactory.Create();
        }

        private Body CreateBody()
        {
            return (Body) _bodyFactory.Create();
        }

        private Transmission CreateTransmissin()
        {
            return (Transmission) _transmissionFactory.Create();
        }

        public CarFactory()
        {
            Reset();
            Log += Logger.LogInConsole;
            Log += Logger.LogInFile;
        }

        public void Reset()
        {
            _car = new Car<CarPart.CarPart>();
        }

        private IActionPossible CanGetThisCar(Car<CarPart.CarPart> car)
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