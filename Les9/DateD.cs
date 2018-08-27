using System;

namespace Les9
{
    class DateD
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public DateD(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
        public static int DaysInMonth(int month, int year = 0)
        {
            if (month == 2)
                return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0) ? 29 : 28;
            if (month.In(4, 6, 9, 11))
                return 30;
            return 31;
        }
        public static bool operator <(DateD d1, DateD d2) => d1.Year * 1000 + d1.Month * 100 + d1.Day < d2.Year * 1000 + d2.Month * 100 + d2.Day;
        public static bool operator >(DateD d1, DateD d2) => d1.Year * 1000 + d1.Month * 100 + d1.Day > d2.Year * 1000 + d2.Month * 100 + d2.Day;

        public static int operator -(DateD d1, DateD d2)
        {
            DateD dateMin = d1 < d2 ? d1 : d2;
            DateD dateMax = d1 > d2 ? d1 : d2;
            int monthTmp = dateMin.Month;
            int YearTmp = dateMin.Year;
            int res = dateMax.Day - dateMin.Day;
            while (monthTmp != dateMax.Month || YearTmp != dateMax.Year)
            {
                res += DaysInMonth(monthTmp, YearTmp);
                monthTmp++;
                if (monthTmp > 12)
                {
                    monthTmp = 1;
                    YearTmp++;
                }
            }
            return d1 > d2 ? res : -res;
        }

        public static DateD operator +(DateD d, int days)
        {
            int daysRemain = Math.Abs(days);

            DateD result = new DateD(d.Year, d.Month, d.Day);

            while (daysRemain > 0)
            {
                if (days > 0)
                {
                    int count = DaysInMonth(result.Month, result.Year) - result.Day;
                    if (daysRemain > count)
                    {
                        daysRemain -= count + 1;
                        result.Month++;
                        result.Day = 1;
                        if (result.Month > 12)
                        {
                            result.Year++;
                            result.Month = 1;
                        }
                    }
                    else
                    {
                        result.Day += daysRemain;
                        break;
                    }
                }
                else
                {
                    int count = result.Day;
                    if (daysRemain >= count)
                    {
                        daysRemain -= count;
                        result.Month--;
                        result.Day = DaysInMonth(result.Month, result.Year);
                        if (result.Month < 1)
                        {
                            result.Year--;
                            result.Month = 12;
                        }
                    }
                    else
                    {
                        result.Day -= daysRemain;
                        break;
                    }
                }
            }

            return result;

        }
        public static DateD operator -(DateD d, int days) => d + -days;

        public static bool operator ==(DateD d, DateTime dt) => d.Year == dt.Year && d.Month == dt.Month && d.Day == dt.Day;
        public static bool operator !=(DateD d, DateTime dt) => !(d == dt);
        public override string ToString() => $"{Day.ToString().PadLeft(2, '0')}.{Month.ToString().PadLeft(2, '0')}.{Year.ToString()}";
    }
}