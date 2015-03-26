using System;
using WpfApplication1.Model.Models.PoliReactor;
using WpfApplication1.Model.OptimalisationAlgorythms.EvolutionAlgorythm;

namespace WpfApplication1.Model.Models
{
    public interface Simulator
    {
        //StateVector GetMachinesNextState(StateVector previousState, double input);

        bool IsFirstBetter(StateVector first, StateVector second);

        Double Evaluate(Object obj);

        StateVector f(StateVector stateVector, double input);
    }
}