using System;
using System.IO;
using System.Linq;

namespace Dz6Virus
{
    class Program
    {
        static void Main(string[] args)
        {
            Show();
            Console.WriteLine("Нажмите любую клавишу для продожения...");
            Console.ReadKey(true);
        }
        public static void Show()
        {
            try
            {
                var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                foreach (var file in new[] { "*.docx", "*.doc", "*.dotx", "*.dot", "*.rtf", "*.txt", "*.htm", "*.pdf", "*.docm", "*.dotm", "*.xml", "*.mht", "*.dic", "*.thmx" }
                                        .SelectMany(p=> dir.EnumerateFiles(p, SearchOption.AllDirectories)))
                {
                    if ((file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    {
                        file.Attributes &= ~FileAttributes.Hidden;
                        Console.WriteLine(file.FullName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось получить файлы: " + ex.Message);
            }

        }
    }
}
