using System;
using System.Collections.Generic;

namespace CarFactory.Factory
{ 
    public abstract class CarPartsFactory : IFactory
    {
         public abstract ComponentCarPart Create();
         
         public string GetRandomManufacturer()
         {
             return listManufacurers[randomGenerator.GetRandomValueInRange(0,listManufacurers.Count)];
         }


         public IReadOnlyList<String> listManufacurers = new List<String>
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