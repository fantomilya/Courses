using System;
using CarLibrary;

public static void Main()
{
    SportsCar sportcar = new SportsCar("Viper", 240, 40);
    sportcar.Acceleration();

    MiniVan minivan = new MiniVan();
    minivan.Acceleration();

    Console.ReadKey();
}
