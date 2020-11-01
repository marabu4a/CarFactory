using System;
using CarFactory.CarPart.ChassisModel;
using CarFactory.CarPart.EngineModel;

namespace CarFactory.Factory
{
    public class ChassisFactory : CarPartsFactory
    {
        public Suspension.SuspensionType GetRandomSuspensionType()
        {
            Array types = Enum.GetValues(typeof(Suspension.SuspensionType));

            return (Suspension.SuspensionType) types.GetValue(randomGenerator.GetRandomValue(types.Length));
        }

        public Drivetrain.DrivetrainType GetRandomDrivetrainType()
        {
            Array types = Enum.GetValues(typeof(Drivetrain.DrivetrainType));
            return (Drivetrain.DrivetrainType) types.GetValue(randomGenerator.GetRandomValue(types.Length));
        }

        public SteeringPowerType GetRandomSteeringPowerType()
        {
            Array types = Enum.GetValues(typeof(SteeringPowerType));
            return (SteeringPowerType) types.GetValue(randomGenerator.GetRandomValue(types.Length));
        }

        public BrakeSystem.BrakesType GetRandomBrakeType()
        {
            Array types = Enum.GetValues(typeof(BrakeSystem.BrakesType));
            return (BrakeSystem.BrakesType) types.GetValue(randomGenerator.GetRandomValue(types.Length));
        }

        public override ComponentCarPart Create()
        {
            var rearSuspension = new Suspension(
                type: GetRandomSuspensionType(),
                cost: randomGenerator.GetRandomValueInRange(40000, 100000),
                manufacturer: GetRandomManufacturer());
            var frontSuspension = new Suspension(
                type: GetRandomSuspensionType(),
                cost: randomGenerator.GetRandomValueInRange(40000, 100000),
                manufacturer: GetRandomManufacturer());

            var drivetrain = new Drivetrain(
                cost: randomGenerator.GetRandomValueInRange(30000, 100000),
                type: GetRandomDrivetrainType(),
                manufacturer: GetRandomManufacturer());

            var steeringPowerType = GetRandomSteeringPowerType();

            var brakeSystem = new BrakeSystem(
                type: GetRandomBrakeType(),
                cost: randomGenerator.GetRandomValueInRange(10000, 50000),
                manufacturer: GetRandomManufacturer());

            return new Chassis(
                manufacturer: GetRandomManufacturer(),
                brakeSystem: brakeSystem,
                drivetrain: drivetrain,
                rearSuspension: rearSuspension,
                frontSuspension: frontSuspension,
                steeringPowerType: steeringPowerType,
                wheels: new Wheel(
                    cost: randomGenerator.GetRandomValueInRange(10000, 30000),
                    manufacturer: GetRandomManufacturer()));
        }
    }
}