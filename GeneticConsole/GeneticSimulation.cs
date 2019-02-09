using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GA
{
    public class GeneticSimulation
    {
        private GeneticAlgorithm geneticAlgorithm;

        public void RunEvolution()
        {
            GeneticAlgorithmParameters parameters = new GeneticAlgorithmParameters(
                populationSize: 10,
                mutationRate: 0.3,
                mutationAmplitute: 0.5);

            PopulationType specimenType = PopulationType.Arithmetic1D;

            PopulationSetting populationSetting;
            switch (specimenType)
            {
                case (PopulationType.Arithmetic1D):
                    populationSetting = new Arithmetic1DPopulation((s) => (Math.Pow(s.Genes[0] - 10, 2) + 5));
                    break;
                case (PopulationType.Arithmetic2D):
                    populationSetting = new Arithmetic2DPopulation((s) => (Math.Pow((s.Genes[0] + 2 * s.Genes[1] - 7), 2) + Math.Pow((2 * s.Genes[0] + s.Genes[1] - 5), 2)));
                    break;

                default: throw new Exception("Тип особей, для которых запускается симуляция, не задан! Завершение работы...");
            }



            geneticAlgorithm = new GeneticAlgorithm(parameters, populationSetting);

            for (int i = 0; i < 1000; i++)
            {
                geneticAlgorithm.NewGeneration();
                Console.WriteLine();
                Console.WriteLine("Поколение: " + geneticAlgorithm.GenerationNum);
                ShowPopulation(geneticAlgorithm.CurrentGeneration);
                ShowBestInGeneration(geneticAlgorithm.CurrentGeneration, populationSetting);
            }
            ShowBestOfAllTime(geneticAlgorithm.allGenerations, populationSetting);
        }

        private void ShowPopulation(List<Specimen> population)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < population.Count; i++)
            {
                Console.WriteLine(population[i]);
            }
        }

        private void ShowBestInGeneration(List<Specimen> generation, PopulationSetting population)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Лучший в поколении №" + geneticAlgorithm.GenerationNum + ": " + generation[0] + "\n");
            sb.Append("Значение функции: " + population.FittingFunction(generation[0]));
            Console.WriteLine(sb);
        }

        private void ShowBestOfAllTime(List<List<Specimen>> generations, PopulationSetting population)
        {
            Specimen best = null;
            Specimen worst = null;
            int bestGeneration = 0;
            int worstGeneration = 0;
            var bestList = new List<Specimen>();
            var tempList = new List<Specimen>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < generations.Count; i++)
            {
                tempList = generations[i];
                tempList.Sort((a, b) => population.FittingFunction(a).CompareTo(population.FittingFunction(b)));
                bestList.Add(tempList[0]);
            }

            for (int i = 0; i < bestList.Count; i++)
            {
                best = bestList[0];
                worst = bestList[1];

                if (population.FittingFunction(bestList[i]) < population.FittingFunction(best))
                {
                    best = bestList[i];
                    bestGeneration = i;
                }

                if (population.FittingFunction(bestList[i]) > population.FittingFunction(worst))
                {
                    worst = bestList[i];
                    worstGeneration = i;
                }
            }
            sb.Append("\nВывод\n");
            sb.Append("Лучший из всех в поколении №" + (bestGeneration + 1) + ": " + best + " Значение функции: " + population.FittingFunction(best) + "\n");
            sb.Append("Худший из всех в поколении №" + (worstGeneration + 1) + ": " + worst + " Значение функции: " + population.FittingFunction(worst) + "\n");
            Console.WriteLine(sb);
        }
    }
}