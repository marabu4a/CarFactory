using System;

namespace CarFactory.Custom
{
    public class RandomGenerator
    {
        private Random rnd = new Random();

        public int GetRandomValue(int max)
        {
            return rnd.Next(max);
        }

        public int GetRandomValueInRange(int min,int max)
        {
            return rnd.Next(min, max);
        }   
    }
}