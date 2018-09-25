using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz8
{
    partial class Program
    {
        class Auto
        {
            public Auto(string mark, string model, int year, ConsoleColor color)
            {
                Mark = mark;
                Model = model;
                Year = year;
                Color = color;
            }

            public string Mark { get; }
            public string Model { get; }
            public int Year { get; }
            public ConsoleColor Color { get; }
        }

        class AutoPurchase
        {
            public AutoPurchase(string mark, string purchaser, string phone)
            {
                Mark = mark;
                Purchaser = purchaser;
                Phone = phone;
            }

            public string Mark { get; }
            public string Purchaser { get; }
            public string Phone { get; }
        }

        public static void Task2()
        {
            var autos = new List<Auto>
            {
                new Auto("asd", "dsa", 2010, ConsoleColor.Black),
                new Auto("asd", "dsa", 2010, ConsoleColor.Black),
                new Auto("asd", "dsa", 2010, ConsoleColor.Black),
                new Auto("asd", "dsa", 2010, ConsoleColor.Black)
            };
            var autoPurchases = new List<AutoPurchase>
            {
                new AutoPurchase("asd", "dsa", "123123123"),
                new AutoPurchase("asd", "dsa", "43211231"),
                new AutoPurchase("asd", "dsa", "123123"),
                new AutoPurchase("asd", "dsa", "45456345")
            };

            //autoPurchases.Select(p=>p.Purchaser + autos.Where(p=>p.))
        }
        /*
        Представьте, что вы пишите приложение для Автостанции и вам необходимо создать простую коллекцию автомобилей со следующими данными: 
        Марка автомобиля, модель, год выпуска, цвет. 
        А также вторую коллекцию с моделью автомобиля, именем покупателя и его номером телефона. 
        Используя простейший LINQ запрос, выведите на экран информацию о покупателе одного из автомобилей и полную характеристику приобретенной им модели автомобиля.
         */
        static void Task1()
        {
            /*
1)	Сформировать LINQ-запрос на получение коллекции заказчиков (Customer) из региона “Азия”.
2)	Сформировать LINQ-запрос на получение коллекции городов, в которых проживают заказчики (Customer) из региона “Азия”.
3)	Сформировать LINQ-запрос на получение общей суммы продаж конкретно по каждому региону и отсортировать по убыванию.
(сумма, имя региона)
(сумма, имя региона)
…..
(сумма, имя региона)

             */
            var customers = CIniCustomer.IniCustomer();

            var t1 = customers.Where(p => p.Region == "Азия");
            var t2 = t1.Select(p => p.City);
            var t3 = customers.GroupBy(p => p.Region).Select(p => new {Region = p.Key, Amount = p.Sum(c => c.Sales)}).OrderByDescending(p=>p.Amount);
        }
        static void Main(string[] args)
        {
        }
    }
}
