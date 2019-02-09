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
        public double Fitness
        {
            get
            {
                return CalculateFitness();
            }
        }

        public double MutationAmplitude { get; private set; }

        private Random random;

        public Specimen(int size, Random random, double mutationAmplitude)
        {
            Genes = new double[size];
            this.random = random;
            this.MutationAmplitude = mutationAmplitude;


            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = Math.Round(random.Next(150, 1500) * Math.Round(random.NextDouble(), 5), 5);
            }

        }

        public Specimen(Specimen paren1, Specimen parent2)
        {
            Genes = new double[paren1.Genes.Length];
            this.random = paren1.random;
            this.MutationAmplitude = paren1.MutationAmplitude;
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = (paren1.Genes[i] + parent2.Genes[i]) / 2;
            }
        }

        public void Mutate()
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = Genes[i] + (2 * random.Next(0, 2) - 1) * Genes[i] * MutationAmplitude;
            }
        }

        private double CalculateFitness()
        {
            double result = 0;
            //Specimen dna = geneticAlgorithm.Population[index];

            //result = (Math.Pow((dna.Genes[0] - 10), 2) - 3);

            //result = Math.Pow(dna.Genes[0], 3) - 3 * Math.Pow(dna.Genes[0], 2) + 2;

            //result = -Math.Pow(dna.Genes[0],2)+2;

            //result = Math.Pow(dna.Genes[0], 4) - 4 * Math.Pow(dna.Genes[0], 3) - 2 * Math.Pow(dna.Genes[0], 2) + 5 * dna.Genes[0] + 9;

            //result = Math.Pow(dna.Genes[0], 2) + Math.Pow(dna.Genes[1], 2) + 2;

            result = Math.Pow((Genes[0] + 2 * Genes[1] - 7), 2) + Math.Pow((2 * Genes[0] + Genes[1] - 5), 2);

            return result;
        }

    }
}
