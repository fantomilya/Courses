using System;
using System.Collections.Generic;

namespace Dz2
{
    struct Train
    {
        private readonly string _stationName;
        private readonly int _number;
        private readonly TimeSpan _depatureTime;

        public Train(string stationName, int number, TimeSpan depatureTime)
        {
            _stationName = stationName;
            _number = number;
            _depatureTime = depatureTime;
        }
        public override string ToString() => $"Поезд №{_number.ToString()} отправляется со станции {_stationName} в {_depatureTime}";
    }

    class SortedTrains : SortedList<int, Train>
    {
        public void InsertTrains()
        {
            int position;
            do
            {
                position = Console.CursorTop;
                try
                {
                    Console.WriteLine("Введите номер поезда");
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите станцию отправления");
                    string station = Console.ReadLine();
                    Console.WriteLine("Введите время отправления");
                    string depatureTime = Console.ReadLine();
                    Add(number, new Train(station, number, TimeSpan.Parse(depatureTime)));
                    Console.WriteLine();
                    position = Console.CursorTop;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Не удалось добавить поезд: " + e.Message);
                }
            }
            while (IsContinue(position));
        }
        public void SearchTrain()
        {
            do
            {
                Console.WriteLine("\nВведите номер поезда для поиска: ");
                try
                {
                    Console.WriteLine(this[int.Parse(Console.ReadLine())].ToString());
                }
                catch
                {
                    Console.WriteLine("Информация по поезду с указанныим номером отсутствует.");
                }
            }
            while (IsContinue(Console.CursorTop));
        }
        private static bool IsContinue(int cursorPosition)
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу. Для завершения Esc.");
            ConsoleKey key = Console.ReadKey(true).Key;
            Console.SetCursorPosition(0, cursorPosition);
            Console.Write(new string(' ', Console.WindowWidth * 10));
            Console.SetCursorPosition(0, cursorPosition);
            return key != ConsoleKey.Escape;
        }
    }
}
