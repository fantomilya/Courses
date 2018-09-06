using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dz2
{
    internal struct Worker : IComparable<Worker>
    {
        private readonly string _fio;
        private readonly string _position;
        private readonly int _year;

        public Worker(string fio, string position, int year)
        {
            _fio = fio;
            _position = position;
            _year = year;
        }

        public int CompareTo(Worker other) => string.Compare(_fio, other._fio, StringComparison.CurrentCultureIgnoreCase);
        public int GetExperience() => DateTime.Today.Year - _year;
        public override string ToString() => $"{_position} {_fio}, работающий с {_year} г.";
    }

    internal class SortedWorkers : List<Worker>
    {
        private static readonly Random Rand = new Random();

        public void InputWorkersRand()
        {
            for (int i = 1; i < 11; i++)
                Add(new Worker(i.ToString(), i.ToString(), Rand.Next(2000, DateTime.Today.Year)));

            Sort();
            Console.WriteLine(ToString());
        }
        public void InputWorkers()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Должность: ");
                string position = Console.ReadLine();
                Console.WriteLine("Введите Ф.И.О.: ");
                string fio = Console.ReadLine();
                Console.WriteLine("Введите год начала работы: ");

                try
                {
                    int year = int.Parse(Console.ReadLine());
                    if (!year.Between(1900, DateTime.Today.Year))
                        throw new Exception("Неверный формат года.");

                    Add(new Worker(fio, position, year));
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
                Console.WriteLine(this.Where(p => p.GetExperience() > exp).GetString("\n", defaultIfEmpty: "Ни одного работника не найдено"));
            else
                Console.WriteLine("Не удалось преобразовать стаж в число.");
        }
        public override string ToString() => this.GetString("\n");
    }
}
