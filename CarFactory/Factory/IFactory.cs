using System;
using System.Collections.Generic;
using CarFactory.Custom;

namespace CarFactory.Factory
{
    public abstract class IFactory
    {
        public RandomGenerator randomGenerator = new RandomGenerator();
        
    }
}