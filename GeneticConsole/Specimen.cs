using System;
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
                    Genes[i] = random.Next(10, 100) * random.NextDouble();
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


                //if (random.NextDouble() < crossoverRate)
                //{
                //    child.Genes[i] = Genes[i] + random.NextDouble() * (Genes[i] / 5) - (Genes[i] / 10);
                //}
                //else
                //{
                //    child.Genes[i] = parent2.Genes[i] + random.NextDouble() * (parent2.Genes[i] / 5) - (parent2.Genes[i] / 10);
                //}
            }
            return child;
        }

        public void Mutate()
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = Genes[i] + random.NextDouble() * (Genes[i] / 5) - (Genes[i] / 10);
            }
        }

    }
}
