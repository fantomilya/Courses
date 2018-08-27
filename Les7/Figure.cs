using System;
using System.Text;

namespace Les7
{
    class Figure
    {
        private Point[] _points;
        private void FillPoints(params Point[] points) => _points = points;
        public Figure(Point p1, Point p2, Point p3) => FillPoints(p1, p2, p3);
        public Figure(Point p1, Point p2, Point p3, Point p4) => FillPoints(p1, p2, p3, p4);
        public Figure(Point p1, Point p2, Point p3, Point p4, Point p5) => FillPoints(p1, p2, p3, p4, p5);

        public static double LengthSide(Point a, Point b) =>
            Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));

        public double PerimeterCalculator()
        {
            double perimeter = 0;
            for (int i = 1; i < _points.Length; i++)
                        perimeter += LengthSide(_points[i - 1], _points[i]);

            return perimeter + LengthSide(_points[0], _points[_points.Length - 1]);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            if (_points.Length == 3)
                s.Append("Треугольник");
            else if (_points.Length == 4)
                s.Append("Четырёхугольник");
            else if (_points.Length == 5)
                s.Append("Пятиугольник");

            s.Append($" с периметром = {PerimeterCalculator():##.##}");
            return s.ToString();
        }
    }
}