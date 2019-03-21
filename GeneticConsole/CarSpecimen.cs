using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class CarSpecimen : Specimen
    {
        public double[] Genes { get; private set; }
        public double[] ShapeCoordinates { get; private set; }
        public double[] WheelSizes { get; private set; }
        public double[] WheelPositions { get; private set; }
        public double[] WheelWeights { get; private set; }
        public double[] BodyWeight { get; private set; }

        readonly private Func<double> fittingFunction;

        public CarSpecimen(int numberOfShapeCoordinates = 8, int wheelSize = 2, int wheelPosition = 4, int wheelWeight = 2, int bodyWeigth = 1)
        {
            //int size = numberOfShapeCoordinates + wheelSize + wheelPosition + wheelWeight + bodyWeigth;
            //Genes = new double[size];

            ShapeCoordinates = new double[numberOfShapeCoordinates];
            WheelSizes = new double[wheelSize];
            WheelPositions = new double[wheelPosition];
            WheelWeights = new double[wheelWeight];
            BodyWeight = new double[bodyWeigth];

            for (int i = 0; i < ShapeCoordinates.Length; i++)
            {
                ShapeCoordinates[i] = Math.Round(RandomForGA.Generator.Next(1, 100) * Math.Round(RandomForGA.Generator.NextDouble(), 5), 5);
            }
            for (int i = 0; i < WheelSizes.Length; i++)
            {
                WheelSizes[i] = Math.Round(RandomForGA.Generator.Next(1, 100) * Math.Round(RandomForGA.Generator.NextDouble(), 5), 5);
            }
            for (int i = 0; i < WheelPositions.Length; i++)
            {
                WheelPositions[i] = Math.Round(RandomForGA.Generator.Next(1, 100) * Math.Round(RandomForGA.Generator.NextDouble(), 5), 5);
            }
            for (int i = 0; i < WheelWeights.Length; i++)
            {
                WheelWeights[i] = Math.Round(RandomForGA.Generator.Next(1, 100) * Math.Round(RandomForGA.Generator.NextDouble(), 5), 5);
            }
            for (int i = 0; i < BodyWeight.Length; i++)
            {
                BodyWeight[i] = Math.Round(RandomForGA.Generator.Next(1, 100) * Math.Round(RandomForGA.Generator.NextDouble(), 5), 5);
            }
        }

        public CarSpecimen(CarSpecimen parent1, CarSpecimen parent2)
        {
            //Genes = new double[parent1.Genes.Length];
            fittingFunction = parent1.fittingFunction;
            
            ShapeCoordinates = new double[parent1.ShapeCoordinates.Length];
            WheelSizes = new double[parent1.WheelSizes.Length];
            WheelPositions = new double[parent1.WheelPositions.Length];
            WheelWeights = new double[parent1.WheelWeights.Length];
            BodyWeight = new double[parent1.BodyWeight.Length];

            for (int i = 0; i < ShapeCoordinates.Length; i++)
            {
                ShapeCoordinates[i] = (parent1.ShapeCoordinates[i] + parent2.ShapeCoordinates[i]) / 2;
            }
            for (int i = 0; i < WheelSizes.Length; i++)
            {
                WheelSizes[i] = (parent1.WheelSizes[i] + parent2.WheelSizes[i]) / 2;
            }
            for (int i = 0; i < WheelPositions.Length; i++)
            {
                WheelPositions[i] = (parent1.WheelPositions[i] + parent2.WheelPositions[i]) / 2;
            }
            for (int i = 0; i < WheelWeights.Length; i++)
            {
                WheelWeights[i] = (parent1.WheelWeights[i] + parent2.WheelWeights[i]) / 2;
            }
            for (int i = 0; i < BodyWeight.Length; i++)
            {
                BodyWeight[i] = (parent1.BodyWeight[i] + parent2.BodyWeight[i]) / 2;
            }
            //for (int i = 0; i < Genes.Length; i++)
            //{
            //    Genes[i] = (parent1.Genes[i] + parent2.Genes[i]) / 2;
            //}
        }

        override public void Mutate(double mutationAmplitude)
        {

            for (int i = 0; i < ShapeCoordinates.Length; i++)
            {
                ShapeCoordinates[i] = ShapeCoordinates[i] + (2 * RandomForGA.Generator.Next(0, 2) - 1) * ShapeCoordinates[i] * mutationAmplitude;
            }
            for (int i = 0; i < WheelSizes.Length; i++)
            {
                WheelSizes[i] = WheelSizes[i] + (2 * RandomForGA.Generator.Next(0, 2) - 1) * WheelSizes[i] * mutationAmplitude;
            }
            for (int i = 0; i < WheelPositions.Length; i++)
            {
                WheelPositions[i] = WheelPositions[i] + (2 * RandomForGA.Generator.Next(0, 2) - 1) * WheelPositions[i] * mutationAmplitude;
            }
            for (int i = 0; i < WheelWeights.Length; i++)
            {
                WheelWeights[i] = WheelWeights[i] + (2 * RandomForGA.Generator.Next(0, 2) - 1) * WheelWeights[i] * mutationAmplitude;
            }
            for (int i = 0; i < BodyWeight.Length; i++)
            {
                BodyWeight[i] = BodyWeight[i] + (2 * RandomForGA.Generator.Next(0, 2) - 1) * BodyWeight[i] * mutationAmplitude;
            }

            //for (int i = 0; i < Genes.Length; i++)
            //{
            //    Genes[i] = Genes[i] + (2 * RandomForGA.Generator.Next(0, 2) - 1) * Genes[i] * mutationAmplitude;
            //}
        }

        public override Specimen CrossoverWith(Specimen secondParent)
        {
            return new CarSpecimen(this, secondParent as CarSpecimen);
        }
        public override string ToString()
        {

            StringBuilder sb1 = new StringBuilder();
            sb1.Append("[");

            for (int i = 0; i < ShapeCoordinates.Length; i++)
            {
                sb1.Append("Vertex position " + i + ": " + ShapeCoordinates[i] + "\n");
            }
            for (int i = 0; i < WheelSizes.Length; i++)
            {
                sb1.Append("Wheel " + i + "size: " + WheelSizes[i] + "\n");
            }

            for (int i = 0; i < WheelPositions.Length; i++)
            {
                if (i < 2)
                    sb1.Append("Wheel 1 position " + i + ": " + WheelSizes[i] + "\n");
                else
                    sb1.Append("Wheel 2 position " + i + ": " + WheelSizes[i] + "\n");
            }

            for (int i = 0; i < WheelWeights.Length; i++)
            {
                sb1.Append("Wheel " + i + "weight: " + WheelWeights[i] + "\n");
            }

            for (int i = 0; i < BodyWeight.Length; i++)
            {
                sb1.Append("Body weight: " + BodyWeight[i] + "\n");
            }
            
            //for (int i = 0; i < Genes.Length; i++)
            //{
            //    sb1.Append(Genes[i]);
            //    if (i == Genes.Length)
            //    {

            //    }
            //    else
            //        sb1.Append(" ");
            //}

            sb1.Append("]");
            return sb1.ToString();

        }
    }
}
