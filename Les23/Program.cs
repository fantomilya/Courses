using System;
using System.IO;

namespace Les23
{
    public class KeyPressedEventArgs : EventArgs
    {
        public KeyPressedEventArgs(ConsoleKeyInfo keyInfo, DateTime time, int countPressed)
        {
            KeyInfo = keyInfo;
            Time = time;
            CountPressed = countPressed;
        }

        public ConsoleKeyInfo KeyInfo { get; }
        public DateTime Time { get; }
        public int CountPressed { get; }
    }
    public class KeyReader
    {
        private int Count { get; set; }
        public event EventHandler<KeyPressedEventArgs> OnKeyPressed;
        public KeyReader()
        {

        }

        public void Exec()
        {
            while (Console.ReadKey(true) is ConsoleKeyInfo key)
            {
                EventHandler<KeyPressedEventArgs> handler = OnKeyPressed;
                handler?.Invoke(this, new KeyPressedEventArgs(key, DateTime.Now, ++Count));
                if (key.Key == ConsoleKey.Escape)
                    return;
            }
        }
    }

    class Program
    {
        public static void DeleteFile()
        {
            if (new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "MySpyDirectory", "SpyFile.txt")) is var file && file.Exists)
                file.Delete();
        } 
        public static void KeyPressedEventHandler(object sender, KeyPressedEventArgs args)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "MySpyDirectory"));
            dir.Create();
            using (StreamWriter sw = new FileInfo(Path.Combine(dir.FullName, "SpyFile.txt")).AppendText())
            {
                if (args.KeyInfo.Key == ConsoleKey.Escape)
                {
                    sw.WriteLine(new string('-', 26));
                    sw.WriteLine($"Всего было нажато клавиш: {(args.CountPressed - 1).ToString()}");
                }
                else
                    sw.WriteLine($"{args.Time.ToLongTimeString()}  |  Клавиша  '{args.KeyInfo.KeyChar.ToString()}' |");
            }
        }
        static void Main()
        {
            DeleteFile();
            KeyReader keyReader = new KeyReader();
            keyReader.OnKeyPressed += KeyPressedEventHandler;
            keyReader.Exec();
        }
    }

}