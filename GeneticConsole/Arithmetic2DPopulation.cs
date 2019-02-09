using System;

namespace GA
{
    public class Arithmetic2DPopulation : PopulationSetting
    {
        private readonly Arithmetic2DSpecimenGenerator generator;
        public override ISpecimenGenerator SpecimenGenerator
        {
            get { return generator; }
        }

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
            generator = new Arithmetic2DSpecimenGenerator();
            this.environmentFittingFunction = environmentFittingFunction;
        }
    }
}
