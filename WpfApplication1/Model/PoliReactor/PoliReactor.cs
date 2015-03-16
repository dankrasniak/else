using System;
using System.Collections;
using System.IO.Packaging;
using System.Linq.Expressions;
using System.Windows;

namespace WpfApplication1.Model.PoliReactor
{
    public class PoliReactor
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const double H_STEP_SIZE = 0.1;

        // z(k + 1) = z(k) + hf(z(k))
        public ArrayList NewVector(ArrayList inputVector)
        {
            // Verify vector
            if (inputVector.Count < 4)
                return new ArrayList();

            // Modify values
            var a = new ArrayList();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            var b = new ArrayList() {1, 1, 1};


            return new ArrayList();
        }



    }
}