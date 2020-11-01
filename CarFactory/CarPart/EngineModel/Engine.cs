using System;
using System.Collections.Generic;
using CarFactory.CarPart.TransmissionModel;
using CarFactory.Custom;

namespace CarFactory.CarPart.EngineModel
{
    public class Engine : ComponentCarPart
    {
        private int _displacement;
        private int _power;
        private int _torque;
        private int _numberOfCylinders;
        private EngineType _type;
        private Turbine _turbine { get; set; }
        private FuelSystem _fuelSystem { get; set; }
        private IgnitionSystem _ignitionSystem { get; set; }

        public override int _cost
        {
            get => _fuelSystem.Cost + _ignitionSystem.Cost;
        }
        
        public EngineType Type { get; }
        public string Displacement => _displacement + "cm3";
        public string Torque => _torque + "H/m";

        public Turbine Turbine => _turbine;

        public FuelSystem FuelSystem => _fuelSystem;

        public IgnitionSystem IgnitionSystem => _ignitionSystem;

        private bool HasTurbine()
        {
            switch (Type)
            {
                case EngineType.Diesel:
                {
                    return true;
                }
                case EngineType.Electric:
                {
                    return false;
                }
            }

            if (_fuelSystem.Type == FuelSystem.FuelSystemType.MPI)
            {
                return false;
            }

            return true;
        }

        public Engine(EngineType type, string manufacturer, int displacement, int power, int torque,
            int numberOfCylinders) : base(1, manufacturer)
        {
            _type = type;
            _displacement = displacement;
            _power = power;
            _torque = torque;
            _numberOfCylinders = numberOfCylinders;
        }

        public void setIgnitionSystem(IgnitionSystem ignitionSystem)
        {
            _ignitionSystem = ignitionSystem;
        }

        public void setTurbine(Turbine turbine)
        {
            _turbine = turbine;
        }

        public void setFuelSystem(FuelSystem fuelSystem)
        {
            _fuelSystem = fuelSystem;
        }

        public override bool HasAllComponent()
        {
            return _turbine != null && _fuelSystem != null && _ignitionSystem != null;
        }

        public override IActionPossible AvailableForThisCar(Car.Car car)
        {
            if (!_fuelSystem.AvailableForThisCar(car).IsPossible)
            {
                return new ActionImpossible(_fuelSystem.AvailableForThisCar(car).Reason);
            }

            if (!_ignitionSystem.AvailableForThisCar(car).IsPossible)
            {
                return new ActionImpossible(_ignitionSystem.AvailableForThisCar(car).Reason);
            }

            if (!_turbine.AvailableForThisCar(car).IsPossible)
            {
                return new ActionImpossible(_turbine.AvailableForThisCar(car).Reason);
            }
            return new ActionPossible();
        }

        public override void AddComponent(CarPart carPart)
        {
            _carParts.Add(carPart);
        }

        public override void RemoveComponent(CarPart carPart)
        {
            _carParts.Add(carPart);
        }
    }
}