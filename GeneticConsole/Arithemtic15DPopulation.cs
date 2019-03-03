using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class Arithemtic15DPopulation : PopulationSetting
    {
        private readonly Func<ArithmeticSpecimen, double> environmentFittingFunction;

        public override Func<Specimen, double> FittingFunction
        {
            get
            {
                return (specimen) => environmentFittingFunction(specimen as ArithmeticSpecimen);
            }
        }

        public Arithemtic15DPopulation(Func<ArithmeticSpecimen, double> environmentFittingFunction)
        {
            this.environmentFittingFunction = environmentFittingFunction;
        }

        public override Specimen CreateOne()
        {
            return new ArithmeticSpecimen(15);
        }
    }
}
