using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class ArithmeticSpecimen : Specimen
    {
        public double[] Genes { get; private set; }

        readonly private Func<double> fittingFunction;

        public ArithmeticSpecimen(int size)
        {
            Genes = new double[size];
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = Math.Round(RandomForGA.Generator.Next(10, 1500) * Math.Round(RandomForGA.Generator.NextDouble(), 5), 5);
            }

        }

        public ArithmeticSpecimen(ArithmeticSpecimen parent1, ArithmeticSpecimen parent2)
        {
            fittingFunction = parent1.fittingFunction;
            Genes = new double[parent1.Genes.Length];
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = (parent1.Genes[i] + parent2.Genes[i]) / 2;
            }
        }

        override public void Mutate(double mutationAmplitude)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = Genes[i] + (2 * RandomForGA.Generator.Next(0, 2) - 1) * Genes[i] * mutationAmplitude;
            }
        }

        public override Specimen CrossoverWith(Specimen secondParent)
        {
            return new ArithmeticSpecimen(this, secondParent as ArithmeticSpecimen);
        }

        public override string ToString()
        {

            StringBuilder sb1 = new StringBuilder();
            sb1.Append("[");
            for (int i = 0; i < Genes.Length; i++)
            {
                sb1.Append(Genes[i]);
                if (i == Genes.Length)
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
