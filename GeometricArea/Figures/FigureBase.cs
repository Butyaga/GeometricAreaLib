using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricArea.Figures
{
    internal abstract class FigureBase
    {
        public abstract double Area { get; }
        public virtual void SetParametrs(params double[] prms)
        {
            if (prms == null || prms.Length == 0)
            {
                throw new ArgumentException("Not enough arguments");
            }
        }
    }
}
