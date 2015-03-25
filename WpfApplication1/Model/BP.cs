using System;
using System.Windows.Input;
using WpfApplication1.Model.Models;
using WpfApplication1.Model.Models.CommandingAlgorythm;
using WpfApplication1.Model.Models.PoliReactor;
using WpfApplication1.Model.OptimalisationAlgorythms;
using WpfApplication1.Model.OptimalisationAlgorythms.EvolutionAlgorythm;

namespace WpfApplication1.Model
{
    public class BP
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        private Simulator simulator;
        private CommandingAlgorythm commandingAlgorythm;
        private OptimalisationAlgorythm optimalisationAlgorythm;
    
        public void Main()
        {
            simulator = new PoliReactor();
            optimalisationAlgorythm = new EvolutionAlgorythm(simulator.Evaluate, new Specimen());
        }
    }
}