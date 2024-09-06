// See https://aka.ms/new-console-template for more information
using GeometricArea;
using GeometricArea.Figures;

Console.WriteLine("Hello, World!");

double[] prms = { 3, 2, 3.6055 };
Console.WriteLine(Area.GetArea(FigureType.triangle, prms));

/*
Triangle triangle = new Triangle();
triangle.SetParametrs(prms);
Console.WriteLine(triangle.IsRectangular);
*/
