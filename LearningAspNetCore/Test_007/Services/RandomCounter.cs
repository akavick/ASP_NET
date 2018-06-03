using System;

namespace Test_007.Services
{
    public class RandomCounter : ICounter
    {
        private static readonly Random _rand = new Random();

        public int Value { get; } = _rand.Next(0, 1000000);
    }
}