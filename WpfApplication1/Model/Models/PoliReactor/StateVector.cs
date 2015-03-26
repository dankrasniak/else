using System;
using System.Collections;

namespace WpfApplication1.Model.Models.PoliReactor
{
    public class StateVector
    {
        private readonly ArrayList _array;

        #region Constructors

        public StateVector(Double Cm, Double C1, Double D0, Double D1)
        {
            _array = new ArrayList() {Cm, C1, D0, D1};
        }

        public StateVector(StateVector stateVector)
        {
            this._array = stateVector._array;
        }

        private StateVector()
        {
        }

        #endregion Constructors

        #region Overloading operators

        public static StateVector operator +(StateVector first, StateVector second)
        {
            var ARRAY_SIZE = first._array.Count;
            if (ARRAY_SIZE != second._array.Count)
                return null;

            for (var i = 0; i < ARRAY_SIZE; ++i)
            {
                first._array[i] = (Double) first._array[i] + (Double) second._array[i];
            }

            return first;
        }

        public static StateVector operator *(Double num, StateVector stateVector)
        {
            var ARRAY_SIZE = stateVector._array.Count;
            for (var i = 0; i < ARRAY_SIZE; ++i)
            {
                stateVector._array[i] = (Double) stateVector._array[i]*num;
            }

            return stateVector;
        }

        public static StateVector operator *(StateVector stateVector, Double num)
        {
            return num * stateVector;
        }

        #endregion Overloading operators

        public int Size()
        {
            return _array.Count;
        }

        public Double Get(int index)
        {
            if (index < 0 || index >=_array.Count)
                throw new Exception("Impropper index size!");
            return (Double)_array[index];
        }

        public void Add(object value)
        {
            _array.Add(value);
        }
    }
}