using System;
using System.Windows.Media.Effects;

namespace WpfApplication1.Model.Algorythms.EvolutionAlgorythm
{
    public class EvolutionAlgorythm
    {
        #region Const Data

        private const int M = 10;
        private const double C1 = 0.82;
        private const double C2 = 1.2;

        #endregion Const Data

        private Specimen _specimen;
        private double _sigma;
        private double _sigmaMin;
        private int _phi;
        private int _iteration;

        // Specimen evaluation function, passed by the model
        public delegate Double Evaluate(Specimen specimen);
        private Evaluate _evaluate;


        public EvolutionAlgorythm(Evaluate evaluationMethod, Specimen startingSpecimen)
        {
            _evaluate = evaluationMethod;
            _specimen = startingSpecimen;
            _phi = 0;
            _iteration = 0;
            _sigmaMin = 10.0; // TODO
            _sigma = 20.0; // TODO

            while (!IsFinished())
            {
                ++_iteration;
                NextIteration();
            }
        }

        private bool IsFinished()
        {
            return _sigma < _sigmaMin;
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

            if (_phi < 1.5)
            {
                _sigma *= C1;
                return;
            }
            if (_phi > 1.5)
            {
                _sigma *= C2;
                return;
            }
            // == 1.5
            return;
        }

        public Specimen GetResultSpecimen()
        {
            return _specimen;
        }
    }
}