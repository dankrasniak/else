using System;
using System.Data;
using NUnit.Framework;

namespace WpfApplication1.Model.Algorythms.EvolutionAlgorythm
{
    public class EvolutionAlgorythm
    {
        #region Const Data

        private const double M = 10.0;
        private const double C1 = 0.82;
        private const double C2 = 1.2;

        #endregion Const Data

        private Specimen _specimen;
        private double _sigma;
        private double _sigmaMin;
        // TODO PHI

        // Specimen evaluation function, passed by the model
        public delegate Func<Boolean> Evaluate(Specimen specimen);
        private Evaluate _evaluate;


        public EvolutionAlgorythm(Evaluate evaluationMethod)
        {
            _evaluate = evaluationMethod;
            _specimen = GenerateFirstSpecimen();
            _sigmaMin = 10.0;
            _sigma = 20.0;

            while (!IsFinished())
            {
                NextIteration();
            }
        }

        private bool IsFinished()
        {
            return _sigma < _sigmaMin;
        }

        private Specimen GenerateChild()
        {
            var child = new Specimen();

            throw new NotImplementedException(); // TODO

            return child;
        }

        private Specimen GetNextSpecimen()
        {
            var child = GenerateChild();
            return CompareSpecimens(_specimen, child);
        }

        private Specimen CompareSpecimens(Specimen specimen, Specimen child)
        {
            throw new NotImplementedException(); // TODO
        }

        private void NextIteration()
        {
            _specimen = GetNextSpecimen();
            UpdatePhi();
            UpdateSigma();

        }

        private void UpdateSigma()
        {
            throw new NotImplementedException();
        }

        private void UpdatePhi()
        {
            throw new NotImplementedException();
        }

        private Specimen GenerateFirstSpecimen()
        {
            throw new NotImplementedException();
        }

        public Specimen GetResultSpecimen()
        {
            return _specimen;
        }
    }
}