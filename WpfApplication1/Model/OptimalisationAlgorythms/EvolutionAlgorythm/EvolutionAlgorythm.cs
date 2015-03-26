using System;
using System.Windows.Media.Effects;
using WpfApplication1.Model.Models.PoliReactor;
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
        private int _iterationNum;

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
            _iterationNum = 0;
            _sigma = 20.0; // TODO

            while (!IsFinished())
            {
                ++_iterationNum;
                NextIteration();
            }

            return _specimen;
        }

        private bool IsFinished()
        {
            return _sigma < SigmaMin;
        }

        private void NextIteration()
        {
            _specimen = GetNextSpecimen();
            UpdateSigma();
        }

        private Specimen GetNextSpecimen()
        {
            var child = GenerateChild();
            return CompareSpecimens(_specimen, child);
        }

        private Specimen GenerateChild()
        {
            var child = ModifySpecimen(_specimen);
            return child;
        }

        private Specimen ModifySpecimen(Specimen specimen) // TODO rework
        {
            var newSpecimen = new Specimen(specimen);
            var i = 0;
            foreach (var inputValue in specimen.GetInputValues())
            {
                newSpecimen.SetInput(i++, inputValue);
                GetGaussian();
            }
            return newSpecimen;
        }

        private Specimen CompareSpecimens(Specimen specimen, Specimen child)
        {
            if (_evaluate(specimen) > _evaluate(child))
                return specimen;

            ++_phi;

            return child;
        }

        private void UpdateSigma()
        {
            if (_iterationNum % M != 0)
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

        // Wiki - Gaussian // TODO Verify
        private static double _spare;
        private static bool _isSpareReady = false;
 
        private static double GetGaussian()
        {
            if (_isSpareReady) {
                _isSpareReady = false;
                return _spare;
            } else {
                double u, v, s;
                do
                {
                    var rand = new Random();
                    u = rand.Next() * 2 - 1;
                    v = rand.Next() * 2 - 1;
                    s = u * u + v * v;
                } while (s >= 1 || s.Equals(0.0));

                var mul = Math.Sqrt(-2.0 * Math.Log(s) / s);
                _spare = v * mul;
                _isSpareReady = true;
                return u * mul;
            }
        }
    }
}