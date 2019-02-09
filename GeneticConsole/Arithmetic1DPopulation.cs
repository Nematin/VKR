using System;

namespace GA
{
    public class Arithmetic1DPopulation : PopulationSetting
    {
        private readonly Func<ArithmeticSpecimen, double> environmentFittingFunction;

        public override Func<Specimen, double> FittingFunction
        {
            get
            {
                return (specimen) => environmentFittingFunction(specimen as ArithmeticSpecimen);
            }
        }

        public Arithmetic1DPopulation(Func<ArithmeticSpecimen, double> environmentFittingFunction)
        {
            this.environmentFittingFunction = environmentFittingFunction;
        }

        public override Specimen CreateOne()
        {
            return new ArithmeticSpecimen(1);
        }
    }
}
