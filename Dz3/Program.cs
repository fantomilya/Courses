using System;
using System.Collections.Generic;
using System.Linq;

namespace Dz3
{
    public static class Task1
    {
        public static void Execute()
        {
            var files = Enumerable.Range(1, (int)Math.Ceiling(565 * 1024D / 780)).Select(p => new File(780D / 1024));
            var storages = new Storage[] { new Flash(100), new Hdd(15, 8), new Dvd(Type.OneSided, 5000)};
            Console.WriteLine($"Общий объем памяти = {storages.Sum(p=>p.GetCapacity())} ГБ\n");
            foreach (var storage in storages)
            {
                int count = 1;
                Console.WriteLine($"{storage.GetInfo()}\nВремя, необходимое для копирования = " + storage.CalcTime(files.Sum(p=>p.size)) + "с.");
                foreach (var file in files)
                {
                    if (storage.GetFreeMemory() < file.size)
                    {
                        storage.Clear();
                        count++;
                    }
                    storage.Copy(file);
                }
                Console.WriteLine($"Потребуется {count} шт.\n");
            }
            Console.ReadKey(true);
        }
    }
    public static class Task2
    {
        public static void Execute()
        {
            var house = new House();
            var team = new Team();
            team.Build(house);
            Console.ReadKey(true);
        }
    }
    public static class Task3
    {
        public static void Execute()
        {
            foreach (var u in new List<User> { new Administrator(), new Moderator(), new Guest() })
            {
                Console.WriteLine(u.GetType().Name);
                u.AddMaterial();
                u.EditMaterial();
                u.DeleteMaterial();
                u.ReadMaterial();
                Console.WriteLine();
            }
            Console.ReadKey(true);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Task1.Execute();
            //Task2.Execute();
            //Task3.Execute();
        }
    }
}
