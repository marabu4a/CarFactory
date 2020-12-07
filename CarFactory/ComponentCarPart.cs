using System.Collections.Generic;
using CarFactory.Car;
using CarFactory.Custom;

namespace CarFactory
{
    public abstract class ComponentCarPart : CarPart.CarPart
    {

        public ComponentCarPart(int count, string manufacturer) : base(count, manufacturer)
        {
            
        }
        protected List<CarPart.CarPart> _carParts;

        public abstract void AddComponent(CarPart.CarPart carPart);
        public abstract void RemoveComponent(CarPart.CarPart carPart);

        public abstract bool HasAllComponents();
        
        public IActionPossible CanRemoveComponent(CarPart.CarPart carPart)
        {
            if (carPart is null)
            {
                return new ActionImpossible("Cannot remove null part");
            }
            if (!_carParts.Contains(carPart))
            {
                return new ActionImpossible("Cannot remove part");
            }
            if (carPart is ComponentCarPart)
            {
                return new ActionImpossible("This part is non component");
            }
            return new ActionPossible();
        } 
        
        public IActionPossible CanAddComponent(CarPart.CarPart carPart)
        {
            if (carPart is null)
            {
                return new ActionImpossible("Cannot add null part");
            }

            if (_carParts.Contains(carPart))
            {
                return new ActionImpossible("Part already added");
            }

            if (carPart is ComponentCarPart)
            {
                return new ActionImpossible("This part is non component");
            }
            return new ActionPossible();
        }
        
    }
}