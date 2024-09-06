using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GeometricArea.Figures
{
    internal class Triangle : FigureBase
    {
        const int angleCount = 3;
        private double[] _side = new double[angleCount];

        public override void SetParametrs(params double[] prms)
        {
            base.SetParametrs(prms);
            CheckSides(prms);

            // side[0] - всегда большая сторона, что упростит проверку существования треугольника и проверку прямоугольности
            double[] side = ReorderSide(prms);
            CheckTriangleExist(side);
            _side = side;
        }

        public override double Area
        {
            get
            {
                // формула Герона
                double p = (_side[0] + _side[1] + _side[2]) / 2;
                return Math.Sqrt(p * (p - _side[0]) * (p - _side[1]) * (p - _side[2]));
            }
        }

        public bool IsRectangular
        {
            get
            {
                // Теорема косинусов
                double cosA = (Math.Pow(_side[1], 2) + Math.Pow(_side[2], 2) - Math.Pow(_side[0], 2)) / 2 * _side[1] * _side[2];
                return Math.Abs(cosA) < 0.001; // cos(90) = 0
            }
        }

        private void CheckSides(double[] side)
        {
            if (side.Length < angleCount)
            {
                throw new ArgumentException("Для треугольника должны быть заданы длины 3 сторон");
            }

            for (int i = 0; i < angleCount; i++)
            {
                if (!(side[i] > 0))
                {
                    throw new ArgumentException("Стороны треугольника должны быть больше нуля");
                }
            }
        }

        private void CheckTriangleExist(double[] prms)
        {
            if (!((prms[1] + prms[2]) > prms[0]))
            {
                throw new ArgumentOutOfRangeException("Треугольник с указанными сторонами не существует");
            }
        }

        /// <summary>
        /// Меняем порядок в массиве сторон треугольника, первая сторона теперь наибольшая
        /// </summary>
        private double[] ReorderSide(double[] prms)
        {
            double[] side = new double[angleCount];
            side[0] = prms[0];
            for (int i = 1; i < angleCount; i++)
            {
                if (side[0] > prms[i])
                {
                    side[i] = prms[i];
                }
                else
                {
                    side[i] = side[0];
                    side[0] = prms[i];
                }
            }
            return side;
        }
    }
}
