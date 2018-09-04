using System.Collections.Generic;
using System.Linq;
namespace Dz3
{
    class Section
    {
        public double Capacity { get; private set; }
        public List<File> files { get; private set; }
        public double GetFreeMemory() => Capacity - files.Sum(p => p.size);

        public Section(double capacity)
        {
            Capacity = capacity;
            files = new List<File>();
        }
        public void Clear() => files.Clear();
    }
}
