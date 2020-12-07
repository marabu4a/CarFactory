using System;
using CarFactory.Car;

namespace CarFactory.Factory
{
    public class BodyFactory : CarPartsFactory
    {
        public override CarPart.CarPart Create()
        {
            return new Body(
                cost:randomGenerator.GetRandomValueInRange(100000, 400000),
                type: CreateBodyType(),
                manufacturer:GetRandomManufacturer()
                );
        }
        
        private BodyType CreateBodyType()
        {
            Array types = Enum.GetValues(typeof(BodyType));
            return (BodyType) types.GetValue(randomGenerator.GetRandomValue(types.Length));
        }

    }
}