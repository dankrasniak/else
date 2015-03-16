﻿using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Windows;

namespace WpfApplication1.Model.PoliReactor
{
    public class VectorZ
    {
        private readonly ArrayList _array;

        #region Constructors

        public VectorZ(Double Cm, Double C1, Double D0, Double D1)
        {
            _array = new ArrayList() {Cm, C1, D0, D1};
        }

        public VectorZ(VectorZ vector)
        {
            this._array = vector._array;
        }

        private VectorZ()
        {
        }

        #endregion Constructors


        public static VectorZ operator +(VectorZ first, VectorZ second)
        {
            var ARRAY_SIZE = first._array.Count;
            if (ARRAY_SIZE != second._array.Count)
                return null;

            for (int i = 0; i < ARRAY_SIZE; ++i)
            {
                first._array[i] = (Double)first._array[i] + (Double)second._array[i];
            }

            return first;
        }

        public static VectorZ operator *(Double num, VectorZ vector)
        {
            var ARRAY_SIZE = vector._array.Count;
            if (ARRAY_SIZE != 4)
                return null;

            for (int i = 0; i < ARRAY_SIZE; ++i)
            {
                vector._array[i] = (Double)vector._array[i] * num;
            }

            return vector;
        }
    }
}