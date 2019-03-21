using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class CarsPopulation : PopulationSetting
    {
        private readonly Func<CarSpecimen, double> environmentFittingFunction;

        public override Func<Specimen, double> FittingFunction
        {
            get
            {
                return (specimen) => environmentFittingFunction(specimen as CarSpecimen);
            }
        }

        public CarsPopulation(Func<CarSpecimen, double> environmentFittingFunction)
        {
            this.environmentFittingFunction = environmentFittingFunction;
        }

        public override Specimen CreateOne()
        {
            return new CarSpecimen();
        }
    }
}
