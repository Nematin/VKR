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
                                                           GetRandomNumber,
                                                           FitFunction,
                                                           mutationRate,
                                                           crossoverRate,
                                                           mutationAmplitude);

            for (int i = 0; i < 100; i++)
            {
                geneticAlgorithm.NewGeneration(crossoverRate);
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

        public double FitFunction(Specimen specimen)
        {
            double result = 0;
            //Specimen dna = geneticAlgorithm.Population[index];

            //result = (Math.Pow((dna.Genes[0] - 10), 2) - 3);

            //result = Math.Pow(dna.Genes[0], 3) - 3 * Math.Pow(dna.Genes[0], 2) + 2;

            //result = -Math.Pow(dna.Genes[0],2)+2;

            //result = Math.Pow(dna.Genes[0], 4) - 4 * Math.Pow(dna.Genes[0], 3) - 2 * Math.Pow(dna.Genes[0], 2) + 5 * dna.Genes[0] + 9;

            //result = Math.Pow(dna.Genes[0], 2) + Math.Pow(dna.Genes[1], 2) + 2;

            result = Math.Pow((specimen.Genes[0] + 2 * specimen.Genes[1] - 7), 2) + Math.Pow((2 * specimen.Genes[0] + specimen.Genes[1] - 5), 2);
            return result;
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
