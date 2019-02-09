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
        private double mutationAmplitude;
        private GeneticAlgorithm geneticAlgorithm;

        public GeneticTestEnvironment()
        {
        }

        public void RunEvolution()
        {
            populationSize = 10;
            dnaSize = 2;
            mutationRate = 0.3;
            crossoverRate = 0.3;
            mutationAmplitude = 0.5;


            geneticAlgorithm = new GeneticAlgorithm(populationSize,
                                                           dnaSize,
                                                           random,
                                                           mutationRate,
                                                           mutationAmplitude);

            for (int i = 0; i < 1000; i++)
            {
                geneticAlgorithm.NewGeneration();
                Console.WriteLine();
                Console.WriteLine("Поколение: " + geneticAlgorithm.Generation);
                ShowPopulation(geneticAlgorithm.Population);
                ShowBestInGeneration(geneticAlgorithm.Population);
            }
            ShowBestOfAllTime(geneticAlgorithm.allPopulation);
        }

        private void ShowPopulation(List<Specimen> population)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < population.Count; i++)
            {
                Console.WriteLine(ShowResultString(population[i]));
            }
        }

        private void ShowBestInGeneration(List<Specimen> population)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Лучший в поколении №" + geneticAlgorithm.Generation + ": " + ShowResultString(population[0]) + "\n");
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
            sb.Append("Лучший из всех в поколении №" + (bestGeneration + 1) + ": " + ShowResultString(best) + " Значение функции: " + best.Fitness + "\n");
            sb.Append("Худший из всех в поколении №" + (worstGeneration + 1) + ": " + ShowResultString(worst) + " Значение функции: " + worst.Fitness + "\n");
            Console.WriteLine(sb);
        }

        public string ShowResultString(Specimen specimen)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("[");
            for (int i = 0; i < specimen.Genes.Length; i++)
            {
                sb1.Append(specimen.Genes[i]);
                if (i == specimen.Genes.Length)
                {

                }
                else
                    sb1.Append(" ");
            }
            sb1.Append("]");
            return sb1.ToString();
        }
    }
}