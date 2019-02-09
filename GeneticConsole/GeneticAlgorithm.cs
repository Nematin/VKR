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
        public List<List<Specimen>> allGenerations = new List<List<Specimen>>();

        private List<Specimen> newGeneration = new List<Specimen>();
        private List<Specimen> oldGeneration = new List<Specimen>();

        public List<Specimen> CurrentGeneration { get; set; }
        public int GenerationNum { get; set; }
        public double BestFit { get; set; }
        public Specimen BestSpecimen { get; set; }

        private double totalFitness;

        public GeneticAlgorithmParameters Parameters { get; }
        private readonly PopulationSetting population;


        public GeneticAlgorithm(GeneticAlgorithmParameters parameters, PopulationSetting population)
        {
            GenerationNum = 0;
            this.Parameters = parameters;
            this.population = population;

            CurrentGeneration = new List<Specimen>();
            for (int i = 0; i < parameters.PopulationSize; i++)
            {
                CurrentGeneration.Add(population.SpecimenGenerator.CreateOne());
                System.Threading.Thread.Sleep(100);
            }

            BestSpecimen = CurrentGeneration[0];
        }

        public void NewGeneration()
        {
            if (CurrentGeneration.Count <= 0)
                return;

            newGeneration = new List<Specimen>();
            oldGeneration = new List<Specimen>();
            List<Specimen> bestOfTheBest = new List<Specimen>();
            allGenerations.Add(CurrentGeneration);

            for (int i = 0; i < CurrentGeneration.Count; i++)
            {
                for (int j = 0; j < CurrentGeneration.Count; j++)
                {
                    if (i == j)
                    {
                        j++;
                    }
                    if (j == CurrentGeneration.Count)
                        break;

                    var firstParent = CurrentGeneration[i];
                    var secondParent = CurrentGeneration[j];

                    var child = firstParent.CrossoverWith(secondParent);
                    if (RandomForGA.Generator.NextDouble() < Parameters.MutationRate)
                        child.Mutate(Parameters.MutationAmplitude);


                    newGeneration.Add(child);
                }
            }

            for (int i = 0; i < CurrentGeneration.Count; i++)
            {
                oldGeneration.Add(CurrentGeneration[i]);
            }

            CurrentGeneration.Clear();
            for (int i = 0; i < oldGeneration.Count; i++)
            {
                CurrentGeneration.Add(oldGeneration[i]);
            }

            for (int i = 0; i < newGeneration.Count; i++)
            {
                CurrentGeneration.Add(newGeneration[i]);
            }

            CalculateFitness();

            CurrentGeneration.Sort((a, b) => population.FittingFunction(a).CompareTo(population.FittingFunction(b)));

            for (int i = 0; i < Parameters.PopulationSize; i++)
            {
                bestOfTheBest.Add(CurrentGeneration[i]);
            }
            CurrentGeneration = bestOfTheBest;
            GenerationNum++;
        }

        public void CalculateFitness()
        {
            totalFitness = 0;
            var best = CurrentGeneration[0];
            double fitOfCurrentBest = population.FittingFunction(best);
            for (int i = 0; i < CurrentGeneration.Count; i++)
            {
                totalFitness += population.FittingFunction(CurrentGeneration[i]);

                double fitOfIthSpesimen = population.FittingFunction(CurrentGeneration[i]);
                if (fitOfIthSpesimen < fitOfCurrentBest)
                {
                    best = CurrentGeneration[i];
                    fitOfCurrentBest = fitOfIthSpesimen;
                }
            }
            BestFit = fitOfCurrentBest;
            BestSpecimen = best;
        }
    }
}
