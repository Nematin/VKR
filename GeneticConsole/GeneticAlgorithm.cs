using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class GeneticAlgorithm<T>
    {
        public List<DNA<T>> Population { get; set; }
        public int Generation { get; set; }
        public double MutationRate { get; set; }
        public double CrossoverRate { get; set; }
        public double BestFit { get; set; }
        public T[] BestGenes { get; set; }

        private Random random;
        private double totalFitness;


        //<summary>
        //Конструктор GeneticAlgorithm отвечает за создание популяции с заданными параметрами
        //</summary>
        public GeneticAlgorithm(int populationSize, int dnaSize, Random random, Func<T> getRandomGene, Func<int,double> fitFunction, double mutationRate, double crossoverRate)
        {
            Generation = 1;
            MutationRate = mutationRate;
            Population = new List<DNA<T>>();
            CrossoverRate = crossoverRate;

            this.random = random;

            BestGenes = new T[dnaSize];

            for (int i = 0; i < populationSize; i++)
            {
                Population.Add(new DNA<T>(dnaSize, random, getRandomGene, fitFunction, true));
                System.Threading.Thread.Sleep(100);
            }
        }

        //<summary>
        //Метод NewGeneration отвечает создание нового поколения особей, со случайной мутацией у ребёнка
        //</summary>
        public void NewGeneration(double crossoverRate)
        {
            if (Population.Count <= 0)
                return;

            CalculateFitness();

            List<DNA<T>> newPopulation = new List<DNA<T>>();
            
            for (int i = 0; i < Population.Count; i++)
            {
                DNA<T> firstParent = SelectParent();
                DNA<T> secondParent = SelectParent();

                DNA<T> child = firstParent.Crossover(secondParent, crossoverRate);

                if(random.NextDouble() < 0.8)
                {
                    child.Mutate(MutationRate);
                }

                newPopulation.Add(child);
            }
            Population = newPopulation;
            Generation++;
        }

        //<summary>
        //Метод CalculateFitness отвечает нахождение лучшей особи в популяции
        //</summary>
        public void CalculateFitness()
        {
            totalFitness = 0;
            DNA<T> best = Population[0];
            for (int i = 0; i < Population.Count; i++)
            {
                totalFitness += Population[i].CalculateFitness(i);

                if (Population[i].Fitness < best.Fitness)
                    best = Population[i];
            }
            BestFit = best.Fitness;
            best.Genes.CopyTo(BestGenes, 0);
        }

        //<summary>
        //Метод SelectParent отвечает выбор случайного родителя
        //</summary>
        private DNA<T> SelectParent()
        {
            System.Threading.Thread.Sleep(100);
            double randNumber = random.NextDouble() * totalFitness;

            for (int i = 0; i < Population.Count; i++)
            {
                if(Population[i].Fitness < 200)
                {
                    if (randNumber < Population[i].Fitness)
                    {
                        return Population[i];
                    }
                    randNumber = Population[i].Fitness;
                }
            }
            return null;
        }
    }
}
