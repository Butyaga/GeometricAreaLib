using System;

namespace GeometricArea.Figures
{
    internal class Circle : FigureBase
    {
        private double _radius;

        public override void SetParametrs(params double[] prms)
        {
            base.SetParametrs(prms);
            CheckRadius(prms[0]);
            _radius = prms[0];
        }

        public override double Area => Math.PI * Math.Pow(_radius, 2);

        private void CheckRadius(double radius)
        {
            if (!(radius > 0))
            {
                throw new ArgumentOutOfRangeException("Радиус не должен быть отрицательным.");
            }
        }
    }
}
