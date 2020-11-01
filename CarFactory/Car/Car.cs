using System;
using System.Collections.Generic;
using System.Linq;
using CarFactory.CarPart;
using CarFactory.CarPart.ChassisModel;
using CarFactory.CarPart.EngineModel;
using CarFactory.CarPart.TransmissionModel;
using CarFactory.Custom;

namespace CarFactory.Car
{
    public class Car
    {
        private BodyType _bodyType;
        private Engine _engine;
        private Chassis _chassis;
        private Transmission _transmission;
        private List<ComponentCarPart> _mainCarParts = new List<ComponentCarPart>();
        protected IReadOnlyList<ComponentCarPart> MainCarParts => _mainCarParts;

        public IActionPossible CanAddPart(ComponentCarPart carPart)
        {
            if (carPart is null)
            {
                return new ActionImpossible("Cannot add null part");
            }

            if (HasThisPart(carPart))
            {
                return new ActionImpossible("Part already added");
            }

            if (!carPart.AvailableForThisCar(this).IsPossible)
            {
                return new ActionImpossible("Cannot add this part");
            }

            return new ActionPossible();
        }

        public IActionPossible CanRemovePart(ComponentCarPart carPart)
        {
            if (carPart is null)
            {
                return new ActionImpossible("Cannot remove null part");
            }

            if (!MainCarParts.Contains(carPart))
            {
                return new ActionImpossible("Cannot remove part");
            }

            return new ActionPossible();
        }

        public bool AddEngine(Engine engine)
        {
            _engine = engine;
            return AddPart(engine);
        }

        public bool AddChassis(Chassis chassis)
        {
            _chassis = chassis;
            return AddPart(chassis);
        }

        public bool AddTransmission(Transmission transmission)
        {
            _transmission = transmission;
            return AddPart(transmission);
        }

        public void AddBodyType(BodyType bodyType)
        {
            _bodyType = bodyType;
        }

        private bool AddPart(ComponentCarPart part)
        {
            IActionPossible canAdd = CanAddPart(part);
            if (!canAdd.IsPossible)
            {
                Console.WriteLine(canAdd.Reason);
                return false;
            }

            _mainCarParts.Add(part);
            return true;
        }

        public bool RemovePart(ComponentCarPart part)
        {
            IActionPossible canRemove = CanRemovePart(part);
            if (!canRemove.IsPossible)
            {
                Console.WriteLine(canRemove.Reason);
                return false;
            }

            _mainCarParts.Remove(part);
            return true;
        }

        public Engine Engine => _engine;
        public Chassis Chassis => _chassis;
        public Transmission Transmission => _transmission;
        public BodyType BodyType => _bodyType;

        public bool HasThisPart(ComponentCarPart part)
        {
            return MainCarParts.Contains(part);
        }

        public bool HasAllMainParts()
        {
            return Engine != null && Chassis != null && Transmission != null && BodyType != null;
        }

        public int CarPartsCount => _engine.Count + _chassis.Count + _transmission.Count;
    }
}