using System;

namespace GA
{
    abstract public class PopulationSetting
    {
        abstract public Specimen CreateOne();
        public abstract Func<Specimen, double> FittingFunction { get; }
    }
}
