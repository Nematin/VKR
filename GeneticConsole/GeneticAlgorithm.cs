using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class GeneticAlgorithm
    {
        public ArrayList allPopulation = new ArrayList();
        public List<Specimen> Population { get; set; }
        public int Generation { get; set; }
        public double MutationRate { get; set; }
        public double CrossoverRate { get; set; }
        public double BestFit { get; set; }
        public double[] BestGenes { get; set; }

        private Random random;
        private double totalFitness;


        public GeneticAlgorithm(int populationSize, int dnaSize, Random random, Func<double> getRandomGene, Func<int,double> fitFunction, double mutationRate, double crossoverRate)
        {
            Generation = 0;
            MutationRate = mutationRate;
            Population = new List<Specimen>();
            CrossoverRate = crossoverRate;

            this.random = random;

            BestGenes = new double[dnaSize];

            for (int i = 0; i < populationSize; i++)
            {
                Population.Add(new Specimen(dnaSize, random, getRandomGene, fitFunction, true));
                System.Threading.Thread.Sleep(100);
            }
        }

        public void NewGeneration(double crossoverRate)
        {
            if (Population.Count <= 0)
                return;

            CalculateFitness();

            List<Specimen> newPopulation = new List<Specimen>();

            allPopulation.Add(Population);

            for (int i = 0; i < Population.Count; i++)
            {
                Specimen firstParent = SelectParent();
                Specimen secondParent = SelectParent();

                Specimen child = firstParent.Crossover(secondParent);

                if (MutationRate > random.NextDouble())
                    child.Mutate();

                newPopulation.Add(child);
            }
            Population = newPopulation;
            Generation++;
        }

        public void CalculateFitness()
        {
            totalFitness = 0;
            Specimen best = Population[0];
            for (int i = 0; i < Population.Count; i++)
            {
                totalFitness += Population[i].CalculateFitness(i);

                if (Population[i].Fitness < best.Fitness)
                    best = Population[i];
            }
            BestFit = best.Fitness;
            best.Genes.CopyTo(BestGenes, 0);
        }

        private Specimen SelectParent()
        {
            System.Threading.Thread.Sleep(100);
            double randNumber = random.NextDouble() * totalFitness;
            int index = -1;
            int mid;
            int first = 0;
            int last = Population.Count - 1;

            mid = (first + last) / 2;
            while (index==-1 && first<=last)
            {
                if(randNumber < Population[mid].Fitness)
                {
                    last = mid;
                }
                else if(randNumber > Population[mid].Fitness)
                {
                    first = mid;
                }
                mid = (first + last) / 2;

                if ((last - first) == 1)
                    index = last;
            }

            return Population[index];
        }
    }
}
