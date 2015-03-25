using System.Collections;

namespace WpfApplication1.Model.OptimalisationAlgorythms.EvolutionAlgorythm
{
    public class Specimen
    {
        private readonly ArrayList inputValues;

        public Specimen(int size)
        {
            inputValues = new ArrayList(size);
        }

        public Specimen(Specimen specimen)
        {
            inputValues = new ArrayList(specimen.inputValues);
        }
    }
}