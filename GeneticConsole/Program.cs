using System;
using GA;

namespace Aga
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GeneticTestEnvironment environment = new GeneticTestEnvironment();
            environment.RunEvolution();
            Console.ReadKey();
        }
    }
}
