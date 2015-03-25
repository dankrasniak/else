using System;
using WpfApplication1.Model.Models.PoliReactor;
using WpfApplication1.Model.OptimalisationAlgorythms.EvolutionAlgorythm;

namespace WpfApplication1.Model.Models
{
    public interface Simulator
    {
        VectorZ GetMachinesNextState(VectorZ previousState, double input);

        bool IsFirstBetter(VectorZ first, VectorZ second);

        Double Evaluate(Specimen specimen);
    }
}