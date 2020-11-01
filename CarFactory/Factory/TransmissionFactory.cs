using System;
using CarFactory.CarPart.ChassisModel;
using CarFactory.CarPart.TransmissionModel;

namespace CarFactory.Factory
{
    public class TransmissionFactory : CarPartsFactory
    {

        public TransmissionType GetRandomTransmissionType()
        {
            Array types = Enum.GetValues(typeof(TransmissionType));
            return (TransmissionType) types.GetValue(randomGenerator.GetRandomValue(types.Length));
        }
        public override ComponentCarPart Create()
        {

            var type = GetRandomTransmissionType();
            var transmission = new Transmission(
                manufacturer:GetRandomManufacturer(),
                cost:randomGenerator.GetRandomValueInRange(100000,300000),
                type:type,
                clutch:new Clutch(
                    cost:randomGenerator.GetRandomValueInRange(20000,40000),
                    manufacturer:GetRandomManufacturer())
                );

            return transmission;
        }
    }
}