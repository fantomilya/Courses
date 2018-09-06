using System;

namespace Les7
{
    internal partial class Bike
    {
        public double MaxSpeed { get; set; }
        public double Weight { get; set; }
        public double Power { get; set; }
        public ConsoleColor Color { get; set; }
        public double Price { get; set; }
        private bool _isStarted;
        private double _fuelTankPercent = 100;
        private double FuelTankPercent
        {
            get => _fuelTankPercent;
            set => _fuelTankPercent = value > 100? 100: value < 0? 0: value;
        }
        public static string Brand { get; set; }
        public static string Model { get; set; }
        public double FuelCapacity { get; set; }

        public double FuelСonsumptionPerKm { get; set; }
        public static Point Coordinates { get; private set; }

        static Bike()
        {
            Brand = "KAWASAKI";
            Model = "ER600N";
        }
        public Bike(double maxSpeed, double weight, double power, ConsoleColor color, double price, double fuelCapacity, double fuelСonsumptionPerKm, Point coordinates)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            Power = power;
            Color = color;
            Price = price;
            Coordinates = coordinates;
            FuelCapacity = fuelCapacity;
            FuelСonsumptionPerKm = fuelСonsumptionPerKm;
        }
        public Bike(double maxSpeed, double weight, double power, double fuelCapacity, double fuelConsumptionPerKm) : this(maxSpeed, weight, power, ConsoleColor.Black, 1300, fuelCapacity, fuelConsumptionPerKm, new Point(0, 0)) { }
        public Bike(double maxSpeed, double weight, double power) : this(maxSpeed, weight, power, ConsoleColor.Black, 1300, 100, 7, new Point(0, 0)) { }
        public Bike(ConsoleColor color) : this(205, 211, 72.1, color, 1300, 100, 7, new Point(0, 0)) { }
        public Bike(Point coordinates) : this(205, 211, 72.1, ConsoleColor.Black, 1300, 100, 7, coordinates) { }
        public Bike() : this(205, 211, 72.1, ConsoleColor.Black, 1300, 100, 7, new Point(0, 0)) { }

        public void Start() => _isStarted = true;
        public void Stop() => _isStarted = false;
        public void Beep() => Console.Beep();
        public void GasUp(double fuelAmount) => FuelTankPercent += FuelCapacity / fuelAmount;
    }
}