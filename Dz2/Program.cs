﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dz2
{
    class Program
    {
        static void Main(string[] args)
        {

            //SortedTrains trains = new SortedTrains();
            //trains.InsertTrains();
            //trains.SearchTrain();

            SortedWorkers workers = new SortedWorkers();
            workers.InputWorkersRand();
            workers.SearchWorker();
            Console.ReadKey();
        }
        class SortedWorkers : List<Worker>
        {
            static Random rand = new Random();
            public void InputWorkersRand()
            {
                for (int i = 1; i < 11; i++)
                    Add(new Worker(i.ToString(), i.ToString(), rand.Next(2000, DateTime.Today.Year)));

                Console.WriteLine(ToString());
            }
            public void InputWorkers()
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Должность: ");
                    string Position = Console.ReadLine();
                    Console.WriteLine("Введите Ф.И.О.: ");
                    string FIO = Console.ReadLine();
                    Console.WriteLine("Введите год начала работы: ");

                    try
                    {
                        int year = int.Parse(Console.ReadLine());
                        if (year < 1900 || year > DateTime.Today.Year)
                            throw new Exception("Неверный формат года.");

                        Add(new Worker(FIO, Position, year));
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Не удалось добавить работника", e);
                    }

                    Console.WriteLine();
                }
                Sort();
            }

            public void SearchWorker()
            {
                Console.WriteLine("\nВведите стаж для поиска: ");
                if (int.TryParse(Console.ReadLine(), out int exp))
                    Console.WriteLine(this.Where(p => p.GetExperience() > exp).Select(p => p.ToString() + '\n').DefaultIfEmpty("Ни одного работника не найдено").Aggregate(string.Concat).ToString());
                else
                    Console.WriteLine("Не удалось преобразовать стаж в число.");
            }
            public override string ToString() => Count > 0 ?this.Select(p=>p.ToString()+'\n').Aggregate(string.Concat): "";
        }
        struct Worker : IComparable<Worker>
        {
            string FIO;
            string Position;
            int Year;

            public Worker(string fIO, string position, int year)
            {
                FIO = fIO;
                Position = position;
                Year = year;
            }

            public int CompareTo(Worker other) => string.Compare(FIO, other.FIO, StringComparison.CurrentCultureIgnoreCase);

            public override string ToString() => $"{Position} {FIO}, работающий с {Year} г.";
            public int GetExperience() => DateTime.Today.Year - Year;
        }
    }
}