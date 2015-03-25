using System;
using System.Windows.Media.Effects;
using WpfApplication1.Model.OptimalisationAlgorythms.EvolutionAlgorythm;

namespace WpfApplication1.Model.OptimalisationAlgorythms.EvolutionAlgorythm
{
    public class EvolutionAlgorythm
    {
        #region Const Data

        private const int M = 10;
        private const double C1 = 0.82;
        private const double C2 = 1.2;
        private const double SigmaMin = 10.0; // TODO

        #endregion Const Data

        private Specimen _specimen;
        // Standard deviation
        private double _sigma;
        // Number of times the child specimen was chosen over the parent specimen in the last cicle of M iterations
        private int _phi;
        private int _iteration;

        // Specimen evaluation function
        public delegate Double Evaluate(Specimen specimen);
        private Evaluate _evaluate;


        public EvolutionAlgorythm()
        {
        }

        public Specimen GetNextInput(Evaluate evaluationMethod, Specimen startingSpecimen)
        {
            _evaluate = evaluationMethod;
            _specimen = startingSpecimen;
            _phi = 0;
            _iteration = 0;
            _sigma = 20.0; // TODO

            while (!IsFinished())
            {
                ++_iteration;
                NextIteration();
            }

            return _specimen;
        }

        private bool IsFinished()
        {
            return _sigma < SigmaMin;
        }

        private Specimen GenerateChild()
        {
            var child = ModifySpecimen(_specimen);
            return child;
        }

        private Specimen ModifySpecimen(Specimen specimen)
        {
            throw new NotImplementedException();
        }

        private Specimen GetNextSpecimen()
        {
            var child = GenerateChild();
            return CompareSpecimens(_specimen, child);
        }

        private Specimen CompareSpecimens(Specimen specimen, Specimen child)
        {
            if (_evaluate(specimen) > _evaluate(child))
                return specimen;

            ++_phi;

            return child;
        }

        private void NextIteration()
        {
            _specimen = GetNextSpecimen();
            UpdateSigma();
        }

        private void UpdateSigma()
        {
            if (_iteration % M != 0)
                return;

            if ((double)_phi/M < 1.5)
            {
                _phi = 0;
                _sigma *= C1;
                return;
            }
            if ((double)_phi / M > 1.5)
            {
                _phi = 0;
                _sigma *= C2;
                return;
            }
            _phi = 0;
            // == 1.5
            return;
        }
    }
}