using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class DNA<T>
    {
        public T[] Genes { get; private set; }
        public double Fitness { get; private set; }

        private Random random;
        private Func<T> getRandomGene; // Метод для получения случайного гена
        private Func<int, double> fitFunction; // Метод для подсчёта приспоабливаемости (подсчёт значения функции)

        //<summary>
        //Конструктор DNA отвечает за создание генов у особи
        //</summary>
        public DNA(int size, Random random, Func<T> getRandomGene, Func<int, double> fitFunction, bool initGene = true)
        {
            Genes = new T[size];
            this.random = random;
            this.getRandomGene = getRandomGene;
            this.fitFunction = fitFunction;

            if (initGene)
            {
                for (int i = 0; i < Genes.Length; i++)
                {
                    Genes[i] = getRandomGene();
                }
            }
        }

        //<summary>
        //Метод CalculateFitness отвечает за подсчёт приспособленности у i-ой особи
        //</summary>
        public double CalculateFitness(int index)
        {
            Fitness = fitFunction(index);
            return Fitness;
        }

        //<summary>
        //Метод Crossover отвечает за кроссовер у ребёнка
        //</summary>
        public DNA<T> Crossover(DNA<T> parent2, double crossoverRate)
        {
            DNA<T> child = new DNA<T>(Genes.Length, random, getRandomGene, fitFunction, initGene: false);

            for (int i = 0; i < Genes.Length; i++)
            {
                if (random.NextDouble() < crossoverRate)
                {
                    child.Genes[i] = Genes[i];
                }
                else
                {
                    child.Genes[i] = parent2.Genes[i];
                }
            }
            return child;
        }

        //<summary>
        //Метод Mutate отвечает за мутацию у ребёнка
        //</summary>
        public void Mutate(double mutationRate)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                if (random.NextDouble() > mutationRate)
                {
                    Genes[i] = getRandomGene();
                }
            }
        }
    }
}
