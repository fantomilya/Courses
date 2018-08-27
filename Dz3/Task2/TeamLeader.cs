using System;
using System.Linq;

namespace Dz3
{
    class TeamLeader : IWorker
    {
        public void Work(House house)
        {
            string report = $"Завершено {house.Parts.Sum(p => p.BuiltTime * p.DonePercents / 100) * 100/ house.Parts.Sum(p => p.BuiltTime):#0.##}%\n";
            var alreadyBuilt = house.Parts.Where(p => p.DonePercents == 100);
            report += alreadyBuilt.Any() ? $"Построены: {alreadyBuilt.GroupBy(p => p.GetName()).Select(p => $"{p.Key} - {p.Count()} шт., ").Aggregate(string.Concat).Trim(',', ' ')}" : "Полностью ничего не построено";
            var notDone = house.Parts.Where(p => p.DonePercents < 100);

            if (notDone.Count() > 0)
                report += '\n' + notDone.Select(p => $"{p.GetName()} {p.DonePercents:#0.##}%, ").Aggregate(string.Concat).Trim(',', ' ');

            Console.WriteLine(report + '\n');
        }
    }
}
