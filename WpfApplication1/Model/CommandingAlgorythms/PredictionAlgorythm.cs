using System;
using System.Collections;
using WpfApplication1.Model.Models;
using WpfApplication1.Model.Models.PoliReactor;
using WpfApplication1.Model.OptimalisationAlgorythms.EvolutionAlgorythm;

namespace WpfApplication1.Model.CommandingAlgorythms
{
    public class PredictionAlgorythm : CommandingAlgorythm
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const double H_STEP_SIZE = 0.1; // TODO
        private int _horizonSize = 20; // TODO
        private Simulator _simulator;
        private EvolutionAlgorythm evolutionAlgorythm = new EvolutionAlgorythm();
        private Specimen _inputValue;
        private StateVector _initialState;

        public void Main()
        {
            _simulator = new Models.PoliReactor.PoliReactor();
            _initialState = new StateVector(0.0, 0.0, 0.0, 0.0); // TODO
            _inputValue = evolutionAlgorythm.GetNextInput(Evaluation, new Specimen(_horizonSize));
        }

        public PredictionAlgorythm(Simulator simulator)
        {
            simulator = _simulator;
            
            throw new NotImplementedException();
        }

        // z(k + 1) = z(k) + hf(k1 + 2*k2 + 2*k3 + k4)
        private StateVector GetMachinesNextState(StateVector previousState, double input)
        {
            // Verifying values
            // TODO

            // Modify values
            var k1 = _simulator.f(previousState, input);
            var k2 = _simulator.f(previousState + 0.5 * H_STEP_SIZE * k1, input);
            var k3 = _simulator.f(previousState + 0.5 * H_STEP_SIZE * k2, input);
            var k4 = _simulator.f(previousState + H_STEP_SIZE * k3, input);

            var result = previousState + (H_STEP_SIZE / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);

            return result;
        }

        private Double Evaluation(Specimen specimen)
        {
            var stateCourse = specimen.GetStateCourse();
            if (stateCourse == null)
            {
                stateCourse = new ArrayList();
                var previousState = _initialState;

                foreach (double input in specimen.GetInputValues())
                {
                    previousState = GetMachinesNextState(previousState, input);
                    stateCourse.Add(previousState);
                }

                specimen.SetStateCourse(stateCourse);
            }

            return _simulator.Evaluate(specimen); // TODO implement
        }

        public double GetInput()
        {
            // TODO Co dalej?
            return (double)_inputValue.GetInputValues()[0];
        }

        public void Emulate()
        {
            throw new NotImplementedException();
        }
    }
}