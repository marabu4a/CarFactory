using System;
using System.Collections.Generic;

namespace CarFactory.Car
{
    public abstract class Car
    {
        private BodyType _bodyType;
        private DateTime _productionDate;
        private List<CarPart> _carParts;

        public abstract void addCarPart(CarPart carPart);

        public abstract void removeCarPart(CarPart carPart);

        public BodyType BodyType => _bodyType;

        public DateTime ProductionDate => _productionDate;

        public IReadOnlyList<CarPart> CarParts => _carParts;

        public bool hasThisPart(CarPart part)
        {
            return _carParts.Contains(part);
        }

        public abstract int CarPartsCount();
        public abstract bool CheckCarEquipment();
        
        
    }
}