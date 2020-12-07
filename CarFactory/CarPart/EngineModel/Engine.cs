using System;
using System.Collections.Generic;
using System.Drawing;
using CarFactory.Car;
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

        protected override int _cost { get; set; }
        protected override string _name => "Двигатель";

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

        public Engine(EngineType type,int baseCost, string manufacturer, int displacement, int power, int torque,
            int numberOfCylinders) : base(1, manufacturer)
        {
            _type = type;
            _displacement = displacement;
            _power = power;
            _torque = torque;
            _numberOfCylinders = numberOfCylinders;
            _cost = baseCost;
        }

        public void setIgnitionSystem(IgnitionSystem ignitionSystem)
        {
            _ignitionSystem = ignitionSystem;
            _cost += ignitionSystem.Cost;
        }

        public void setTurbine(Turbine turbine)
        {
            _turbine = turbine;
            _cost += _turbine.Cost;
        }

        public void setFuelSystem(FuelSystem fuelSystem)
        {
            _fuelSystem = fuelSystem;
            _cost += fuelSystem.Cost;
        }

        public override string ToString()
        {
            return String.Format(
                " --- {0}: \n ---  Мощность: {1} \n  --- Крутящий момент: {2}\n ---  Объем: {3}\n ---  Количество цилиндров: {4} \n ---  Тип: {5} \n  --- {6} \n  --- {7} \n  --- Цена: {8}\n",
                Name, _power, _torque, _displacement, _numberOfCylinders, Type, _ignitionSystem, _fuelSystem, _cost);
        }

        public override bool HasAllComponents()
        {
            return _turbine != null && _fuelSystem != null && _ignitionSystem != null;
        }

        public override IActionPossible AvailableForThisCar<T>(Car<T> car)
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