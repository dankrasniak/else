using System;

namespace WpfApplication1.Model.Models.PoliReactor
{
    public class PoliReactor
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const double H_STEP_SIZE = 0.1; // TODO

        // z(k + 1) = z(k) + hf(z(k))
        public VectorZ NewVector(VectorZ inputVector)
        {
            // Verify vector
            if (inputVector.Size() < 4)
                return null;

            // Modify values
            double input = 1.0; // TODO input
            var k1 = f(inputVector, input);
            var k2 = f(inputVector + 0.5 * H_STEP_SIZE * k1, input);
            var k3 = f(inputVector + 0.5 * H_STEP_SIZE * k2, input);
            var k4 = f(inputVector + H_STEP_SIZE * k3, input);

            var result = inputVector + (H_STEP_SIZE / 6.0) * (k1 + 2*k2 + 2*k3 + k4);

            return result;
        }

        #region f function
        private VectorZ f(VectorZ vectorZ, double input) // TODO input
        {
            var oldCm = vectorZ.Get(0);
            var oldC1 = vectorZ.Get(1);
            var oldD0 = vectorZ.Get(2);
            var oldD1 = vectorZ.Get(3);
            var P0 = GetNewP0(oldC1);

            return new VectorZ(
                GetNewCm(oldCm, P0),
                GetNewC1(oldC1, input), // TODO input
                GetNewD0(oldCm, oldD0, P0),
                GetNewD1(oldCm, oldD1, P0)
                );
        }

        private double GetNewP0(double C1)
        {
            return Math.Sqrt((2 * 0.58 * 0.10225 * C1) / (1.093 * Math.Pow(10, 11) + 1.3281 * Math.Pow(10, 10)));
        }

        private double GetNewD1(double Cm, double D1, double P0)
        {
            return (100.12 * (2.4952 * Math.Pow(10, 6) + 2.4522 * Math.Pow(10, 3)) * Cm * P0 - (1.0 * D1) / 0.1);
        }

        private double GetNewD0(double Cm, double D0, double P0)
        {
            return ((0.5 * 1.3281 * Math.Pow(10, 10) + 1.093 * Math.Pow(10, 11)) * Math.Pow(P0, 2) + 2.4522 * Math.Pow(10, 3) * Cm * P0 - (1.0 * D0) / 0.1);
        }

        private double GetNewC1(double C1, double input)
        {
            return (-0.10225 * C1 + (input * 8.0 - 1.0 * C1) / 0.1); // TODO input
        }

        private double GetNewCm(double Cm, double P0)
        {
            return (-(2.4952 * Math.Pow(10, 6) + 2.4522 * Math.Pow(10, 3)) * Cm * P0 + 1.0 * (6.0 - Cm) / 0.1);
        }
        #endregion f function
    }
}