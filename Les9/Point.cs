using System;

namespace Les9
{
    internal class Point
    {
        private int x;
        private int y;
        private int z;

        public Point() { }

        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Show() => Console.WriteLine($"x:{x}, y:{y}, z:{z}");

        public static Point operator -(Point p) => new Point(-p.x, -p.y, -p.z);

        public static Point operator +(Point p1, Point p2) => new Point(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);

        public static Point operator -(Point p1, Point p2) => p1 + -p2;

        public static Point operator +(Point p1, int n) => new Point(p1.x + n, p1.y + n, p1.z + n);

        public static Point operator -(Point p1, int n) => p1 + -n;

        public static Point operator ++(Point p)
        {
            p.x += 1;
            p.y += 1;
            p.z += 1;
            return p;
        }
        public override string ToString() => $"({x}, {y}, {z})";
        public static bool operator >(Point p1, Point p2) => p1.x + p1.y + p1.z > p2.x + p2.y + p2.z;
        public static bool operator <(Point p1, Point p2) => p1.x + p1.y + p1.z < p2.x + p2.y + p2.z;
        public static bool operator true(Point p1) => p1.x == 0 && p1.y == 0 && p1.z == 0;
        public static bool operator false(Point p1) => p1.x != 0 || p1.y != 0 || p1.z != 0;
        public static bool operator ==(Point p1, Point p2) => p1.x == p2.x && p1.y == p2.y && p1.z == p2.z;
        public static bool operator !=(Point p1, Point p2) => p1.x != p2.x || p1.y != p2.y || p1.z != p2.z;


        /// <summary>
        /// Д\з
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        //public static Point operator &(Point p1, Point p2) { }
        //public static Point operator |(Point p1, Point p2) { }
        //public static bool operator &&(Point p1, Point p2) { }
        //public static bool operator ||(Point p1, Point p2) { }
    }
}