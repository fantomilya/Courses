using System;

namespace Les7
{
    class Program
    {
        static void Main()
        {
            Figure f = new Figure(new Point(1, 2), new Point(2, 3), new Point(3, 4));
            Bike[] bikes = { new Bike(ConsoleColor.Blue), new Bike(new Point(3, 5)), new Bike(250, 200, 70), new Bike(200, 190, 65, ConsoleColor.Gray, 1300, 1000, 8, new Point(0, 0)), new Bike() };
            var b = new Bike();
            var c = b.Move(5, 5, out double t, out double p);
            Console.WriteLine(f);
            Console.ReadKey(true);
        }
    }

    partial class Bike
    {
        public Point Move(double x, double y, out double time, out double fuelTankPercent)
        {
            time = 0;
            if (!_isStarted)
            {
                Start();
                time += 5;
            }
            double lenght = (Coordinates.X - x) * (Coordinates.X - x) + (Coordinates.Y - y) * (Coordinates.Y - y);
            double diractionAngle = Math.Atan((y - Coordinates.Y) / (x - Coordinates.X));
            double fuelLenght = FuelCapacity  * FuelTankPercent / (100 * FuelСonsumptionPerKm);
            double realLenght = Math.Min(lenght, fuelLenght);
            fuelTankPercent = FuelTankPercent -= FuelCapacity * 100 / (FuelСonsumptionPerKm * realLenght);
            time += realLenght * 2 / MaxSpeed;
            return Coordinates = new Point((y - Coordinates.Y) * Math.Cos(diractionAngle), (x - Coordinates.X) * Math.Sin(diractionAngle));
        }
    }
}