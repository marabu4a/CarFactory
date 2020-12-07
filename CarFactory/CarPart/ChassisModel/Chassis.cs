using System;
using System.Collections.Generic;
using CarFactory.Car;
using CarFactory.Custom;
using Microsoft.VisualBasic;

namespace CarFactory.CarPart.ChassisModel
{
    public class Chassis : ComponentCarPart
    {
        protected override string _name => "Шасси";

        public Chassis(string manufacturer, BrakeSystem brakeSystem, Drivetrain drivetrain,
            Suspension rearSuspension, Suspension frontSuspension, SteeringPowerType steeringPowerType, Wheel wheels) :
            base(1, manufacturer)
        {
            _brakesystem = brakeSystem;
            _rearSuspension = rearSuspension;
            _frontSuspension = frontSuspension;
            _drivetrain = drivetrain;
            _steeringPowerType = steeringPowerType;
            _wheels = wheels;
            _cost = _brakesystem.Cost + _drivetrain.Cost + _rearSuspension.Cost + _frontSuspension.Cost + _wheels.Cost;
        }

        protected override int _cost { get; set; }

        public override IActionPossible AvailableForThisCar<T>(Car<T> car)
        {
            if (!_brakesystem.AvailableForThisCar(car).IsPossible)
            {
                return new ActionImpossible(_brakesystem.AvailableForThisCar(car).Reason);
            }

            if (!_drivetrain.AvailableForThisCar(car).IsPossible)
            {
                return new ActionImpossible(_drivetrain.AvailableForThisCar(car).Reason);
            }

            if (!_rearSuspension.AvailableForThisCar(car).IsPossible)
            {
                return new ActionImpossible(_rearSuspension.AvailableForThisCar(car).Reason);
            }

            if (!_frontSuspension.AvailableForThisCar(car).IsPossible)
            {
                return new ActionImpossible(_frontSuspension.AvailableForThisCar(car).Reason);
            }

            if (!_wheels.AvailableForThisCar(car).IsPossible)
            {
                return new ActionImpossible(_wheels.AvailableForThisCar(car).Reason);
            }

            return new ActionPossible();
        }

        public override string ToString()
        {
            return String.Format(" --- {0} \n  --- Задняя {1} \n  --- Передняя {2} \n  --- {3} \n ---  {4} \n  --- {5} \n  --- Общая цена подвески: {6}",
                _brakesystem, _rearSuspension, _frontSuspension, _drivetrain, GetSteeringType(), _wheels, Cost);
        }

        private String GetSteeringType()
        {
            switch (_steeringPowerType)
            {
                case SteeringPowerType.Electric:
                {
                    return "Электроусилитель руля";
                }
                case SteeringPowerType.Hydraulic:
                {
                    return "Гидроусилитель руля";
                }
                case SteeringPowerType.ElectroHydraulic:
                {
                    return "Электро-гидроусилитель руля";
                }
            }
            return "";
        }

        private BrakeSystem _brakesystem { get; set; }
        private Drivetrain _drivetrain { get; set; }
        public Suspension _rearSuspension { get; set; }
        public Suspension _frontSuspension { get; set; }
        private SteeringPowerType _steeringPowerType { get; set; }

        private Wheel _wheels { get; set; }

        public void setBrakeSystem(BrakeSystem brakeSystem)
        {
            _brakesystem = brakeSystem;
            AddComponent(brakeSystem);
        }

        public void setDrivetrain(Drivetrain drivetrain)
        {
            _drivetrain = drivetrain;
            AddComponent(drivetrain);
        }

        public void setRearSuspension(Suspension rearSuspension)
        {
            _rearSuspension = rearSuspension;
            AddComponent(rearSuspension);
        }

        public void setFrontSuspension(Suspension frontSuspension)
        {
            _frontSuspension = frontSuspension;
            AddComponent(frontSuspension);
        }

        public void setSteeringPowerType(SteeringPowerType type)
        {
            _steeringPowerType = type;
        }

        public void setWheels(Wheel wheels)
        {
            _wheels = wheels;
            AddComponent(wheels);
        }

        public override bool HasAllComponents()
        {
            return _brakesystem != null && _drivetrain != null && _rearSuspension != null && _frontSuspension != null &&
                   _wheels != null && _steeringPowerType != null;
        }


        public override void AddComponent(CarPart carPart)
        {
            _carParts.Add(carPart);
        }

        public override void RemoveComponent(CarPart carPart)
        {
            _carParts.Remove(carPart);
        }
    }
}