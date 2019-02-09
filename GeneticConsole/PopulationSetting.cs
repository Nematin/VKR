using System;

namespace GA
{
    abstract public class PopulationSetting
    {
        public abstract ISpecimenGenerator SpecimenGenerator { get; }
        public abstract Func<Specimen, double> FittingFunction { get; }
    }
}
