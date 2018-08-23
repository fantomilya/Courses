using System;
using System.Collections.Generic;

namespace Dz2
{
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
            while (isContinue(position));
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
            while (isContinue(Console.CursorTop));
        }

        bool isContinue(int cursorPosition)
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу. Для окончания записи Esc.");

            if (Console.ReadKey().Key == ConsoleKey.Escape)
                return false;

            Console.SetCursorPosition(0, cursorPosition);
            Console.Write(new String(' ', Console.WindowWidth * Console.WindowHeight));
            Console.SetCursorPosition(0, cursorPosition);
            return true;
        }
    }
}
