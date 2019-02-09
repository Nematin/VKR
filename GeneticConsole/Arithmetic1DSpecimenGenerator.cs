using System;
namespace GA
{
    public class Arithmetic1DSpecimenGenerator:ISpecimenGenerator
    {
        public Specimen CreateOne()
        {
            return new ArithmeticSpecimen(1);
        }
    }
}
