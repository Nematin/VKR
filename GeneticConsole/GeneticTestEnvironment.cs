using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GA
{
    public class GeneticTestEnvironment
    {
        private int populationSize;
        private int dnaSize;
        private Random random = new Random();
        private double mutationRate;
        private double crossoverRate;
        private GeneticAlgorithm geneticAlgorithm;

        public GeneticTestEnvironment()
        {
        }

        public void RunEvolution()
        {
            populationSize = 10;
            dnaSize = 1;
            mutationRate = 0.3;
            crossoverRate = 0.3;

            geneticAlgorithm = new GeneticAlgorithm(populationSize,
                                                           dnaSize,
                                                           random,
                                                           GetRandomNumber,
                                                           FitFunction,
                                                           mutationRate,
                                                           crossoverRate);

            for (int i = 0; i < 1000; i++)
            {
                geneticAlgorithm.NewGeneration(crossoverRate);
                Console.WriteLine("Поколение: " + geneticAlgorithm.Generation);
                ShowPopulation(geneticAlgorithm.Population);
                ShowBestInGeneration(geneticAlgorithm.Population);
            }
            ShowBestOfAllTime(geneticAlgorithm.allPopulation);
        }

        private void ShowPopulation(List<Specimen> population)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var specimen in population)
            {
                sb.Append(specimen.Genes[0] + " ");
            }
            Console.WriteLine(sb);
        }

        private void ShowBestInGeneration(List<Specimen> population)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Лучший в поколении №" + geneticAlgorithm.Generation + ": " + population[0].Genes[0] + "\n");
            sb.Append("Значение функции: " + population[0].Fitness);
            Console.WriteLine(sb);
        }

        private void ShowBestOfAllTime(ArrayList generations)
        {
            Specimen best = null;
            Specimen worst = null;
            int bestGeneration = 0;
            int worstGeneration = 0;
            List<Specimen> bestList = new List<Specimen>();
            List<Specimen> tempList = new List<Specimen>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < generations.Count; i++)
            {
                tempList = (List<Specimen>)generations[i];
                tempList.Sort((a, b) => a.Fitness.CompareTo(b.Fitness));
                bestList.Add(tempList[0]);
            }

            for (int i = 0; i < bestList.Count; i++)
            {
                best = bestList[0];
                worst = bestList[1];

                if (bestList[i].Fitness < best.Fitness)
                {
                    best = bestList[i];
                    bestGeneration = i;
                }

                if (bestList[i].Fitness > worst.Fitness)
                {
                    worst = bestList[i];
                    worstGeneration = i;
                }
            }
            sb.Append("\nВывод\n");
            sb.Append("Лучший из всех в поколении №" + (bestGeneration + 1) + ": " + best.Genes[0] + " Значение функции: " + best.Fitness + "\n");
            sb.Append("Худший из всех в поколении №" + (worstGeneration + 1) + ": " + worst.Genes[0] + " Значение функции: " + worst.Fitness + "\n");
            Console.WriteLine(sb);
        }

        public double GetRandomNumber()
        {
            double[] newArr = new double[100];
            Random random = new Random();
            for (int i = 0; i < newArr.Length; i++)
            {
                if (random.NextDouble() < 0.6)
                {
                    newArr[i] = ((i + 1) + (0.1)) / 5;
                }
                else
                {
                    newArr[i] = (Math.Pow((i + 1), 3) + (0.1)) / 200;
                }

                if (newArr[i] > 100)
                    newArr[i] = newArr[i] / 5;
            }

            Random rand = new Random();
            return newArr[rand.Next(newArr.Length)];
        }

        public double FitFunction(int index)
        {
            double result = 0;
            Specimen dna = geneticAlgorithm.Population[index];

            //result = (Math.Pow((dna.Genes[0] - 10), 2) - 3);

            //result = Math.Pow(dna.Genes[0], 3) - 3 * Math.Pow(dna.Genes[0], 2) + 2;

            //result = -Math.Pow(dna.Genes[0],2)+2;

            result = Math.Pow(dna.Genes[0], 4) - 4 * Math.Pow(dna.Genes[0], 3) - 2 * Math.Pow(dna.Genes[0], 2) + 5 * dna.Genes[0] + 9; 
            return result;
        }
    }
}
