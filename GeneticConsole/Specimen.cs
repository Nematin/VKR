using System;

namespace GA
{
    abstract public class Specimen
    {
        abstract public void Mutate(double mutationAmplitude);

        abstract public Specimen CrossoverWith(Specimen secondParent);
    }
}
