using System;
using System.Windows.Input;

namespace WpfApplication1.Model
{
    public class BP
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );


    }
}



/*private const Double CI = 0.132906;

public double Min()
{
    /*
     * min E (P|i=1) gi 
     #1#
    return 0.0;
}

public double Cm()
{
    return ( -(2.4952 * Math.Pow(10,6) + 2.4522 * Math.Pow(10, 3)) * Cm() * P0() + 1.0 * (6.0 - Cm()) / 0.1 );
}

public double P0()
{
    return Math.Sqrt( (2 * 0.58 * 0.10225 * Ci()) / (1.093 * Math.Pow(10,11) + 1.3281 * Math.Pow(10,10)));
}

public double Ci()
{
    return ( -0.10225 * Ci() + (FI * 8.0 - 1.0 * Ci()) / 0.1);
}

public double D0()
{
    return ( (0.5 * 1.3281 * Math.Pow(10,10) + 1.093 * Math.Pow(10,11)) * Math.Pow(P0(),2) + 2.4522 * Math.Pow(10,3) * Cm() * P0() - (1.0 * D0()) / 0.1 );
}

public double Di()
{
    return ( 100.12 * (2.4952 * Math.Pow(10,6) + 2.4522 * Math.Pow(10,3)) * Cm() * P0() - (1.0 * Di()) / 0.1 );
}

public double y()
{
    return Di() / D0();
}*/