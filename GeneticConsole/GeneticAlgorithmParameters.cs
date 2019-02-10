using System;

namespace GA
{
    public class GeneticAlgorithmParameters
    {
        public int PopulationSize { get; }
        public double MutationRate { get; }
        public double MutationAmplitude { get; }

        public GeneticAlgorithmParameters(int populationSize, double mutationRate, double mutationAmplitute)
        {
            this.PopulationSize = populationSize;
            this.MutationRate = mutationRate;
            this.MutationAmplitude = mutationAmplitute;
        }
    }
}
