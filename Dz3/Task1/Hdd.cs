﻿using System.Collections.Generic;
using System.Linq;

namespace Dz3
{
    class Hdd : Storage
    {
        const double speed = 61440;
        List<Section> sections;

        public Hdd(int sectionsCount, double sectionCapacity) =>
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

        public override string GetInfo() => $"HDD скорость {speed} КБ/c, кол-во секций {sections.Count}, размер секции {sections.FirstOrDefault().Capacity} ГБ";

        public override void Clear()
        {
            foreach (var section in sections)
                section.Clear();
        }
    }
}