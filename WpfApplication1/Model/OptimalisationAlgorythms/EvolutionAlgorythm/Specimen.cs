using System.Collections;
using WpfApplication1.Model.Models.PoliReactor;

namespace WpfApplication1.Model.OptimalisationAlgorythms.EvolutionAlgorythm
{
    public class Specimen
    {
        private readonly ArrayList _inputValues;
        private ArrayList _stateCourse = null;

        public Specimen(int size)
        {
            _inputValues = new ArrayList(size);
        }

        public Specimen(Specimen specimen)
        {
            _inputValues = new ArrayList(specimen.GetInputValues());
        }

        public ArrayList GetInputValues()
        {
            return _inputValues;
        }

        public ArrayList GetStateCourse()
        {
            return _stateCourse;
        }

        public void SetStateCourse(ArrayList stateCourse)
        {
            _stateCourse = stateCourse;
        }

        public void SetInput(int index, object value)
        {
            _inputValues[index] = value;
        }
    }
}