using System;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Utilities
{
    public static class Randomizer
    {
        public static Random random = new Random();
        public static int RandomInteger()
        {
            /// Returns a random non negative integer
            return random.Next();
        }

        public static int RandomInteger(int maxValue)
        {
            /// Returns a random non negative integer from 0 to maxValue
            return random.Next(maxValue);
        }

        public static int RandomInteger(int minValue,int maxValue)
        {
            /// Returns a random non negative integer from minValue to maxValue
            return random.Next(minValue,maxValue);
        }

        public static double RandomFloat()
        {
            /// Returns a random double from 0.0 to 1.0
            return random.NextDouble();
        }

    }
}
