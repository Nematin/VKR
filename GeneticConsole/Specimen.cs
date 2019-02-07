﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class Specimen
    {
        public double[] Genes { get; private set; }
        public double Fitness { get; private set; }

        private Random random;
        private Func<double> getRandomGene; // Метод для получения случайного гена
        private Func<int, double> fitFunction; // Метод для подсчёта приспоабливаемости (подсчёт значения функции)

        public Specimen(int size, Random random, Func<double> getRandomGene, Func<int, double> fitFunction, bool initGene = true)
        {
            Genes = new double[size];
            this.random = random;
            this.getRandomGene = getRandomGene;
            this.fitFunction = fitFunction;

            if (initGene)
            {
                for (int i = 0; i < Genes.Length; i++)
                {
                    Genes[i] = Math.Round(random.Next(150, 1500) * Math.Round(random.NextDouble(),5),5);
                }
            }
        }

        public double CalculateFitness(int index)
        {
            Fitness = fitFunction(index);
            return Fitness;
        }

        public Specimen Crossover(Specimen parent2)
        {
            Specimen child = new Specimen(Genes.Length, random, getRandomGene, fitFunction, initGene: false);

            for (int i = 0; i < Genes.Length; i++)
            {
                child.Genes[i] = (Genes[i] + parent2.Genes[i]) / 2;
            }
            return child;
        }

        public void Mutate(double[] Genes)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = Genes[i] + random.NextDouble() * (Genes[i] / 5) - (Genes[i] / 3);
            }
        }

    }
}