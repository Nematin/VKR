using System;
using GA;

namespace Aga
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GeneticSimulation environment = new GeneticSimulation();
            environment.RunEvolution();
            Console.ReadKey();
        }
    }
}
