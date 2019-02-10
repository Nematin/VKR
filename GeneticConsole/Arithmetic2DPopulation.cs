using System;

namespace GA
{
    public class Arithmetic2DPopulation : PopulationSetting
    {
        private readonly Func<ArithmeticSpecimen, double> environmentFittingFunction;

        public override Func<Specimen, double> FittingFunction
        {
            get
            {
                return (specimen) => environmentFittingFunction(specimen as ArithmeticSpecimen);
            }
        }

        public Arithmetic2DPopulation(Func<ArithmeticSpecimen, double> environmentFittingFunction)
        {
            this.environmentFittingFunction = environmentFittingFunction;
        }

        public override Specimen CreateOne()
        {
            return new ArithmeticSpecimen(2);
        }
    }
}
