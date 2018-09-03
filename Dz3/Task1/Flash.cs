using System.Collections.Generic;
using System.Linq;

namespace Dz3
{
    class Flash : Storage
    {
        const double speed = 655360;
        double capacity;
        List<File> files = new List<File>();
        public Flash(double capacity) => this.capacity = capacity;

        public override double CalcTime(double size) => size * 1024 * 1024 / speed;

        public override void Clear() => files.Clear();

        public override double Copy(params File[] files)
        {
            double time = 0;
            foreach (var file in files)
            {
                if (GetFreeMemory() > file.size)
                {
                    this.files.Add(file);
                    time += CalcTime(file.size);
                }
                else
                    break;
            }
            return time;
        }

        public override double GetCapacity() => capacity;

        public override double GetFreeMemory() => capacity - files.Sum(p => p.size);

        public override string GetInfo() => $"Flash скорость {speed} КБ/c, объем {capacity} ГБ, свободное место {GetFreeMemory()} ГБ";
    }
}
