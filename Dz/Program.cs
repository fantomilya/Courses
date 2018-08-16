using System;

namespace Dz
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new PlayerRecorderWindow().ShowDialog();
            new XMLHandler().ShowDialog();
        }
    }
}
