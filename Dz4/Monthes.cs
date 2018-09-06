using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    internal class Monthes : IEnumerable<Month>
    {
        private Month[] MonthesArray { get; }

        public Monthes() : this(DateTime.Today.Year) { }
        public Monthes(int year)
        {
            MonthesArray = new Month[12];
            for (int i = 1; i < 13; i++)
                MonthesArray[i - 1] = new Month((MonthName)i, DateTime.DaysInMonth(year, i));
        }

        public Month this[int index] => index > 0 && index < 13 ? MonthesArray[index - 1] : default(Month);
        IEnumerator IEnumerable.GetEnumerator() => MonthesArray.GetEnumerator();
        public IEnumerator<Month> GetEnumerator() => ((IEnumerable<Month>)MonthesArray).GetEnumerator();
        public IEnumerable<Month> GetMonthesByDaysCount(int daysCount) => MonthesArray.Where(p => p.DaysCount == daysCount).DefaultIfEmpty();
    }
    internal struct Month
    {
        public int DaysCount { get; }
        public MonthName Name { get; }

        public Month(MonthName name, int daysCount)
        {
            DaysCount = daysCount;
            Name = name;
        }

        public override string ToString() => $"{Name.ToString()}({DaysCount.ToString()})";
    }
    internal enum MonthName
    {
        Январь = 1,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь
    }
}
