using System.Collections.Generic;
using System.Linq;

namespace Dz3
{
    internal class Hdd : Storage
    {
        private const double speed = 61440;
        private List<Section> sections;

        public Hdd(int sectionsCount, double sectionCapacity, string name, string model):base(name, model) =>
            sections = new List<Section>(Enumerable.Range(1, sectionsCount).Select(p => new Section(sectionCapacity)));

        public override double Copy(params File[] files)
        {
            double time = 0;
            foreach (var file in files)
            {
                if (sections.FirstOrDefault(p => p.GetFreeMemory() > file.size) is Section s)
                {
                    s.files.Add(file);
                    time += CalcTime(file.size);
                }
                else
                    break;
            }
            return time;
        }
        public override double CalcTime(double size) => size * 1024 * 1024 / speed;

        public override double GetCapacity() => sections.Sum(p => p.Capacity);

        public override double GetFreeMemory() => sections.Max(p => p.Capacity - p.files.Sum(f => f.size));

        public override string GetInfo() => $"HDD {ToString()} скорость {speed.ToString()} КБ/c, кол-во секций {sections.Count.ToString()}, размер секции {sections.FirstOrDefault().Capacity.ToString()} ГБ";

        public override void Clear()
        {
            foreach (var section in sections)
                section.Clear();
        }
    }
}
