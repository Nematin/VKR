﻿using System;
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
        private GeneticAlgorithm<double> geneticAlgorithm;

        public GeneticTestEnvironment()
        {
        }

        public void RunEvolution()
        {
            populationSize = 10;
            dnaSize = 1;
            mutationRate = 0.2;
            crossoverRate = 0.3;

            geneticAlgorithm = new GeneticAlgorithm<double>(populationSize,
                                                           dnaSize,
                                                           random,
                                                           GetRandomNumber,
                                                           FitFunction,
                                                           mutationRate,
                                                           crossoverRate);

            while (geneticAlgorithm.BestFit != 1)
            {
                geneticAlgorithm.NewGeneration(crossoverRate);
                Console.WriteLine("Поколение: " + geneticAlgorithm.Generation);
                ShowPopulation(geneticAlgorithm.Population);
            }
        }

        private void ShowPopulation(List<DNA<double>> population)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var specimen in population)
            {
                sb.Append(specimen.Genes[0] + " ");
            }
            Console.WriteLine(sb);
        }

        //<summary>
        //Метод GetRandomNumber создаёт массив чисел, одно из них будет в последствии геном у особи.
        //</summary>
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

        //<summary>
        //Метод FitFunction подсчёт значения функции. Или вычисление приспосабливаемости особи
        //</summary>
        public double FitFunction(int index)
        {
            double result = 0;
            DNA<double> dna = geneticAlgorithm.Population[index];

            result = (Math.Pow((dna.Genes[0] - 10), 2) - 3);
            return result;
        }
    }
}
