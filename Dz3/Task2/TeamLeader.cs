using Extensions;
using System;
using System.Linq;

namespace Dz3
{
    internal class TeamLeader : IWorker
    {
        public void Work(House house)
        {
            string report = $"Завершено {(house.Parts.Sum(p => p.BuiltTime * p.DonePercents / 100) * 100/ house.Parts.Sum(p => p.BuiltTime)).ToString("#0.##")}%\n" +
                house.Parts.Where(p => p.DonePercents == 100).GroupBy(p => p.GetName()).Select(p => $"{p.Key} - {p.Count()} шт.").GetString(", ", preMessage: "Построены: ", defaultIfEmpty: "Полностью ничего не построено") + "\n" +
                house.Parts.Where(p => p.DonePercents < 100).Select(p => $"{p.GetName()} {p.DonePercents.ToString("#0.##")}%").GetString(", ") + "\n";

            Console.WriteLine(report);
        }
    }
}