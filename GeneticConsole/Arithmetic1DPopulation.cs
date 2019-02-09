using System;

namespace GA
{
    public class Arithmetic1DPopulation : PopulationSetting
    {
        private readonly Arithmetic1DSpecimenGenerator generator;
        public override ISpecimenGenerator SpecimenGenerator
        {
            get { return generator; }
        }

        public readonly Func<ArithmeticSpecimen, double> EnvironmentFittingFunction;

        public override Func<Specimen, double> FittingFunction
        {
            get
            {
                return (specimen) => EnvironmentFittingFunction(specimen as ArithmeticSpecimen);
            }
        }

        public Arithmetic1DPopulation(Func<ArithmeticSpecimen, double> environmentFittingFunction)
        {
            generator = new Arithmetic1DSpecimenGenerator();
            EnvironmentFittingFunction = environmentFittingFunction;
        }
    }
}
