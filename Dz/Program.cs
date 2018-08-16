using System;
using System.Threading;

namespace Dz
{
    public interface IPlayable
    {
        void Play();
        void Pause();
        void Stop();
        void Rewind(double percent);
        event EventHandler<PlayerEventArgs> OnTick;
    }
    public interface IRecordable
    {
        void Record();
        void Pause();
        void Stop();
        event EventHandler<TimeSpan> OnTick;
    }
    /*
     * Создайте 2 интерфейса IPlayable и IRecodable. В каждом из интерфейсов создайте по 3 метода void

    Play() / void Pause() / void Stop() и void Record() / void Pause() / void Stop() соответственно.

    Создайте производный класс Player от базовых интерфейсов IPlayable и IRecodable.

    Написать программу, которая выполняет проигрывание и запись
     */



    class Program
    {
        static void RunForm(System.Windows.Window f)
        {
            f.Show();
            f.Closed += (o, e) => Thread.CurrentThread.Abort();
        }
        static void RunForm(System.Windows.Forms.Form f)
        {
            f.Show();
            f.Closed += (o, e) =>
                {
                    Thread.CurrentThread.Abort();
                };
        }
        [STAThread]
        static void Main(string[] args)
        {
            new PlayerRecorderWindow().ShowDialog();
            new XMLHandler().ShowDialog();
        }
    }
}
