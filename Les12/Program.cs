using System;

namespace Les12
{
    public static class Program
    {
        public static void Main()
        {
            foreach (var p in new ClassRoom())
                Console.WriteLine($"Ученик {p}");

            do
            {
                Console.WriteLine("\nВведите ключ...при его отсутствии нажмите Enter");
                string s = Console.ReadLine();

                if (s == string.Empty)
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                DocumentWorker doc = DocumentLicense.GetDocumentInstance(s);
                Console.WriteLine(doc.GetType().Name);
                doc.OpenDocument();
                doc.EditDocument();
                doc.SaveDocument();
                Console.Write("Для продолжения нажмите любую клавишу...для выхода Esc\n");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
    //Испытание
    public class Trial { }
    // Тест
    public class Test : Trial { }
    //Экзамен
    public class Exam : Trial { }
    //Выпускной экзамен
    public class FinalExam : Exam { }
}