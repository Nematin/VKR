using System;
namespace GA
{
    public class Arithmetic2DSpecimenGenerator : ISpecimenGenerator
    {
        public Specimen CreateOne()
        {
            return new ArithmeticSpecimen(2);
        }
    }
}
