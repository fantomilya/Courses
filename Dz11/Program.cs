using Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dz11
{
    class FileManager
    {
        List<FileSystemInfo> items;
        DriveInfo driver;
        string pattern;
        public FileManager()
        {
            Console.WriteLine("Маска: ");
            pattern = Console.ReadLine();
            //Regex r;
            //do
            //{
            //    try
            //    {
            //        r = new Regex(mask, RegexOptions.IgnoreCase);
            //    }
            //    catch (Exception e)
            //    {
            //        r = null;
            //        Console.WriteLine(e.Message);
            //        Console.WriteLine("Неверная маска\nМаска: ");
            //        mask = Console.ReadLine();
            //    }
            //}
            //while (r is null);

            var drivers = DriveInfo.GetDrives().Where(p => p.IsReady).ToList();
            if (drivers.Count() > 1)
            {
                Console.WriteLine("Доступные диски:");
                for (int i = 0; i < drivers.Count(); i++)
                    Console.WriteLine($"{i.ToString()} - {drivers[i].Name}");

                Console.Write("Номер диска: ");
                int driverNumber = -1;
                while (Console.ReadLine() is string driverNumberStr && (!int.TryParse(driverNumberStr, out driverNumber) || !driverNumber.Between(0, drivers.Count - 1)))
                    Console.Write("Неверный номер диска\nНомер диска:");

                driver = drivers[driverNumber];
            }
            else if (drivers.Any())
                driver = drivers.First();
            else
            {
                Console.WriteLine("Нет доступных дисков");
                return;
            }
            DirectoryInfo di = new DirectoryInfo(driver.Name);
            List<FileSystemInfo> items = GetAvailableDirectories(di, pattern).Union(GetAvailableFiles(di, pattern)).OrderBy(p => p.FullName).ToList();

        }
        public override string ToString() => items.Select((p, index) => $"{index.ToString()}) {items[index].FullName}").Combine();
        private List<FileSystemInfo> GetAvailableFiles(DirectoryInfo topDirectory, string pattern)
        {
            var items = new List<FileSystemInfo>();

            try
            {
                items.AddRange(topDirectory.GetFiles(pattern, SearchOption.TopDirectoryOnly));
                foreach (var directory in topDirectory.GetDirectories())
                    items.AddRange(GetAvailableFiles(directory, pattern));
            }
            catch (UnauthorizedAccessException) { }

            return items;
        }
        private List<FileSystemInfo> GetAvailableDirectories(DirectoryInfo topDirectory, string pattern)
        {
            var items = new List<FileSystemInfo>();

            try
            {
                items.Add(topDirectory);
                foreach (var directory in topDirectory.GetDirectories(pattern))
                    items.AddRange(GetAvailableDirectories(directory, pattern));
            }
            catch (UnauthorizedAccessException) { }

            return items;
        }

        private void DeleteAll() => Delete(0, items.Count - 1);
        private void Delete(int index) => Delete(index, index);
        private void Delete(int indexFrom, int indexTo)
        {
            if (!IsRightIndex(indexFrom) || !IsRightIndex(indexTo))
                throw new IndexOutOfRangeException();

            for (int i = indexFrom; i <= indexTo; i++)
                items[i].Delete();

            items.RemoveRange(indexFrom, indexTo - indexFrom + 1);
        }
        private void Execute()
        {
            while(true)
            {
                Console.WriteLine("1) Удалить все");
                Console.WriteLine("2) Удалить один");
                Console.WriteLine("3) Удалить диапазон");
                Console.WriteLine("4) Вывести список");
                Console.WriteLine("Esc Выйти");
                int op = GetOperationNumber();
                switch (op)
                {
                    case 1:
                        DeleteAll();
                        break;
                    case 2:
                        Delete(GetIndex());
                        break;
                    case 3:
                        Delete(GetIndex(), GetIndex());
                        break;
                    case 4:
                        Console.WriteLine(ToString());
                        break;
                    default:
                        return;
                }
            }
        }
        private bool IsRightIndex(int index) => index.Between(0, items.Count);
        private int GetOperationNumber()
        {
            int positionLeft = Console.CursorLeft;
            int positionTop = Console.CursorTop;
            var color = Console.ForegroundColor;

            while (Console.ReadKey() is var key)
            {
                if (key.Key == ConsoleKey.Escape)
                    return -1;
                else if (!int.TryParse(key.KeyChar.ToString(), out int op) || !op.Between(1, 4))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nНеизвестная операция\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey(true);
                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(positionLeft, positionTop);
                    Console.WriteLine(new string('\n', 3));
                    Console.SetCursorPosition(positionLeft, positionTop);
                }
                else
                    return op;
            }
            return -1;
        }
        private int GetIndex()
        {
            int positionLeft = Console.CursorLeft;
            int positionTop = Console.CursorTop;
            var color = Console.ForegroundColor;

            int index = -1;
            while (Console.ReadLine() is var indexStr && (!int.TryParse(indexStr, out index) || !IsRightIndex(index)))
            {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nНеверный индекс\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey(true);
                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(positionLeft, positionTop);
                    Console.WriteLine(new string('\n', 3));
                    Console.SetCursorPosition(positionLeft, positionTop);
            }
            return index;
        }
    }
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("Введите логин");
            while (Console.ReadLine() is var login && !Regex.IsMatch(login, "^[a-zA-Z]+$"))
                Console.WriteLine("Не верный формат логина");

            Console.WriteLine("Введите пароль");
            while (Console.ReadLine() is var password && !Regex.IsMatch(password, "^.+$"))
                Console.WriteLine("Не верный формат пароля");

        }
        static void Task2()
        {
            //Console.WriteLine("Введите путь к файлу"); string path = Console.ReadLine();
            string path = "1.txt";
            string fileString = string.Empty;
            using (var sr = new StreamReader(path, encoding:Encoding.Default))
                fileString = sr.ReadToEnd();

            fileString = Regex.Replace(fileString, Prepositions.prepositionsTemplate, "Hello!", RegexOptions.IgnoreCase);

            using (var sr = new StreamWriter(path, false, Encoding.Default))
                sr.Write(fileString);
        }
        static void Task4()
        {
            var v = new MyObsoleteClass();
            v.LightObsoleteMethod();
            //v.VeryObsoleteMethod();
        }
        static void Task5()
        {


            while (Console.ReadKey() is var key &&  key.Key != ConsoleKey.Escape)
            {
                return;
            }
        }
        static void Main(string[] args)
        {
            Task5();
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

    }
}
