using System;
using System.Linq;
using Extensions;

namespace Kr
{
    internal class Program
    {
        private void M(object sender, EventArgs e) { }
        private static void M_Static(object sender, EventArgs e) { }

        private static void Task1()
        {
            /*
            Описать класс, предоставляющий события. Перед подпиской на события сторонних экземпляров обеспечить проверку:
            - на то, подписан ли уже объект, предоставляющий обработчик для события. Если объект подписан, то выдать предупреждающее сообщение и проигнорировать подписку.
            - подписан ли конкретный метод-обработчик конкретного объекта на данное событие либо нет. Если метод подписан, то выдать предупреждающее сообщение и проигнорировать подписку.
            Обеспечить данный функционал двумя способами: либо средствами самого события, либо с помощью внешних сущностей.
            */
            var m = new MyClass();
            m.OnSomeAction += new Program().M;
            m.OnSomeAction += M_Static;
            m.OnSomeAction += new Program().M;
            m.OnSomeAction += M_Static;
            m.OnSomeAction -= M_Static;
            m.OnSomeAction += M_Static;
        }

        private static void Task2()
        {
            MyObservableCollection<string> c = new MyObservableCollection<string> { "asd", "ds" };
            /*
            Создать свой класс наблюдаемой коллекции. Экземпляр коллекции должен реагировать на добавление и удаление элементов коллекции. 
            Также экземпляр коллекции должен быть перечислимым, иметь индексатор, иметь возможность добавлять элементы (в том числе и с помощью блока инициализатора), 
                вставлять элементы по индексу, получать индекс элемента, удалять элементы (в том числе и по индексу), 
                копировать элементы в массив, а также иметь возможность проверить наличие в коллекции элемента и возможность очистить всю коллекцию. 
            Экземпляр коллекции должен уметь сортировать свое внутреннее содержимое с возможностью поддержки специальных интерфейсов для задания логики компаратора.
             */
        }
        //private static void Task3_1()
        //{
        //    var racers = Formula1.GetChampions().SelectMany(p => p.Years.Select(y => new { Year = y, Name = p.LastName + " " + p.FirstName, p.Cars }).SelectMany(q => q.Cars.Select(c => new { q.Year, q.Name, Car = c }))).ToList();
        //    var teams = Formula1.GetContructorChampions().SelectMany(p => p.Years.Select(y => new { Year = y, p.Name, Car = p.Name })).ToList();

        //    var p1 = racers.Max(p => p.Name.Length) + 1;
        //    var p2 = teams.Max(p => p.Name.Length) + 1;

        //    Console.WriteLine("Год".PadRight(5) + "Чемпион".PadRight(p1) + "Кубок конструкторов".PadRight(p2));
        //    Console.WriteLine(teams.Union(racers).GroupBy(p=>new{Year = p.Year, Name = p.Name, })
                
        //        teams
        //        .OrderByDescending(p => p.Year)
        //        .Select(p => new { team = p, champion = racers.FirstOrDefault(r => r.Years.Contains(p.Year) && r.Cars.Contains(p.Name)) })
        //        //.Where(p => p.champion != null)
        //        .Take(10)
        //        .Select(p => $"{p.team.Year.ToString().PadRight(5)}{(p.champion?.LastName ?? new string('-', p1 - 1)).PadRight(p1)}{p.team.Name.PadRight(p2)} \n").Combine());
        //}
        private static void Task3()
        {
            var racers = Formula1.GetChampions();
            var teams = Formula1.GetContructorChampions().SelectMany(p => p.Years.Select(y => new { Year = y, p.Name })).ToList();

            var p1 = racers.Max(p => p.LastName.Length) + 1;
            var p2 = teams.Max(p => p.Name.Length) + 1;

            Console.WriteLine("Год".PadRight(5) + "Чемпион".PadRight(p1) + "Кубок конструкторов".PadRight(p2));
            Console.WriteLine(teams
                            .OrderBy(p => p.Year)
                            .Select(p => new { team = p, champion = racers.FirstOrDefault(r => r.Years.Contains(p.Year) && r.Cars.Contains(p.Name)) })
                            .Where(p => p.champion != null)
                            .Take(10)
                            .Select(p => $"{p.team.Year.ToString().PadRight(5)}{(p.champion?.LastName ?? new string('-', p1 - 1)).PadRight(p1)}{p.team.Name.PadRight(p2)} \n").Combine());
        }

        private static void Main(string[] args)
        {
            Task3();
            Console.ReadKey(true);
        }
    }
}
