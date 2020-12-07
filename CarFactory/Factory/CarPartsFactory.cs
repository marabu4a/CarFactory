using System;
using System.Collections.Generic;
using CarFactory.CarPart.ChassisModel;

namespace CarFactory.Factory
{ 
    public abstract class CarPartsFactory : IFactory<CarPart.CarPart>
    {
        public string GetRandomManufacturer()
         {
             return listOfManufacturers[randomGenerator.GetRandomValueInRange(0,listOfManufacturers.Count)];
         }

        public IReadOnlyList<String> listOfManufacturers = new List<String>
         {
             "Mitsubishi motors",
             "VAG",
             "Nissan",
             "Renault-Nissan Group",
             "Ford",
             "Jaguar-Land Rover",
             "BMW Motors"
         };
        
        
    }
}