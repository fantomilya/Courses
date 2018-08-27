using System;

namespace Les9
{
    /*
     Создайте класс, который будет содержать информацию о дате (день, месяц, год). 
     С помощью механизма перегрузки операторов, определите операцию разности двух дат (результат в виде количества дней между датами), 
     а также операцию увеличения даты на определенное количество дней (результат в виде новой даты). 
     */
    class Date
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
        public Date (DateTime dt): this (dt.Year, dt.Month, dt.Day) { }

        public static int operator -(Date d1, Date d2) => (d1.ToDateTime() - d2.ToDateTime()).Days;
        public static Date operator +(Date d, int days) => new Date(d.ToDateTime().AddDays(days));

        public DateTime ToDateTime() => new DateTime(Year, Month, Day);
        public override string ToString() => $"{Day.ToString().PadLeft(2, '0')}.{Month.ToString().PadLeft(2, '0')}.{Year.ToString()}";
    }
}