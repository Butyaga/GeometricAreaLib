using System;
using GeometricArea.Figures;

namespace GeometricArea
{
    public static class Area
    {
        public static double GetArea(FigureType figure, params double[] prms)
        {
            FigureBase figire = GetFigure(figure, prms);

            return figire.Area;
        }

        private static FigureBase GetFigure(FigureType figure, params double[] prms)
        {
            FigureBase newFigure = figure switch
            {
                FigureType.circle => new Circle(),
                FigureType.triangle => new Triangle(),
                _ => throw new ArgumentException(nameof(figure)),
            };
            newFigure.SetParametrs(prms);
            return newFigure;
        }
    }
}
