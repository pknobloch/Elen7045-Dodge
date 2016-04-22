using System;

namespace Elen7045_Dodge.GameLogic
{
    public interface IRandomNumberGenerator
    {
        int Next(int minValue, int maxValue);
    }
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private Random Random { get; } = new Random(DateTime.Now.Millisecond);

#region Singleton pattern
        private static IRandomNumberGenerator _instance;
        public static IRandomNumberGenerator Instance => _instance ?? (_instance = new RandomNumberGenerator());
        private RandomNumberGenerator()
        {
        }
#endregion

        public int Next(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue);
        }
    }
}
