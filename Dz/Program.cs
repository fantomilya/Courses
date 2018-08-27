using System;

namespace Dz
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            //new PlayerRecorderWindow().ShowDialog();
            new XmlHandler().ShowDialog();
        }
    }
}
