using System;
using System.Data;

namespace WpfApplication1.Model.Algorythms.EvolutionAlgorythm
{
    public class EvolutionAlgorythm
    {
        private Specimen specimen = new Specimen();

        public delegate Func<Boolean> Evaluate(Specimen specimen);

        private Evaluate evaluate;

        public EvolutionAlgorythm(Evaluate evaluationMethod)
        {
            evaluate = evaluationMethod;
        }

        private Specimen GenerateChild()
        {
            var child = new Specimen();

            return child;
        }

        private void NextIteration()
        {
            //if (specimen) ;
        }



        public class Specimen
        {
            
        }
    }
}