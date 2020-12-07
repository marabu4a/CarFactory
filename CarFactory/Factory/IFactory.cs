using System;
using System.Collections.Generic;
using System.Timers;
using CarFactory.Custom;

namespace CarFactory.Factory
{
    public abstract class IFactory<T>
    {
        public RandomGenerator randomGenerator = new RandomGenerator();
        
        public abstract T Create();
    }
}