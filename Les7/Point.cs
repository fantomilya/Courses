namespace Les7
{
    internal class Point
    {
        public double X { get; }
        public double Y { get; }
        public string Str { get; }

        public Point() : this(0, 0) { }
        public Point(double x, double y, string str = "")
        {
            X = x;
            Y = y;
            Str = str;
        }

        public override string ToString() => $"({X}, {Y})";
    }
}