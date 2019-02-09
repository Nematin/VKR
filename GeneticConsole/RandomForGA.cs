using System;

namespace GA
{
    static public class RandomForGA
    {
        static readonly Random random = new Random();

        public static Random Generator
        {
            get { return random; }
        }
    }
}
