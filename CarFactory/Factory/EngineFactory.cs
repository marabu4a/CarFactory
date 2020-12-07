using System;
using CarFactory.CarPart.EngineModel;
using CarFactory.Custom;

namespace CarFactory.Factory
{
    public class EngineFactory : CarPartsFactory
    {
        public EngineType GetRandomEngineType()
        {
            Array types = Enum.GetValues(typeof(EngineType));

            return (EngineType) types.GetValue(randomGenerator.GetRandomValue(types.Length));
        }

        public FuelSystem.FuelSystemType GetRandomFuelSystem()
        {
            Array types = Enum.GetValues(typeof(FuelSystem.FuelSystemType));
            return (FuelSystem.FuelSystemType) types.GetValue(randomGenerator.GetRandomValue(types.Length));
        }

        public IgnitionSystem.IgnitionSystemType GetRandomIgnitionSystemType()
        {
            Array types = Enum.GetValues(typeof(IgnitionSystem.IgnitionSystemType));
            return (IgnitionSystem.IgnitionSystemType) types.GetValue(randomGenerator.GetRandomValue(types.Length));
        }

        public override CarPart.CarPart Create()
        {
            var type = GetRandomEngineType();
            var engine = new Engine(
                type: GetRandomEngineType(),
                baseCost: randomGenerator.GetRandomValueInRange(10000, 30000),
                manufacturer: GetRandomManufacturer(),
                displacement: randomGenerator.GetRandomValueInRange(1000, 6300),
                power: randomGenerator.GetRandomValueInRange(100, 400),
                torque: randomGenerator.GetRandomValueInRange(100, 300),
                numberOfCylinders: randomGenerator.GetRandomValueInRange(3,8)
            );
            
            engine.setTurbine(new Turbine(
                cost: randomGenerator.GetRandomValueInRange(10000,50000),
                manufacturer: GetRandomManufacturer()
                ));
            
            engine.setFuelSystem(new FuelSystem(
                cost: randomGenerator.GetRandomValueInRange(5000,25000),
                manufacturer: GetRandomManufacturer(),
                type: GetRandomFuelSystem()
                ));
            
            engine.setIgnitionSystem(new IgnitionSystem(
                type:GetRandomIgnitionSystemType(),
                cost:randomGenerator.GetRandomValueInRange(10000,50000),
                manufacturer:GetRandomManufacturer()));
            return engine;
        }
    }
}