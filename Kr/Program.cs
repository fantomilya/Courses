using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Extensions;
using Kr;

namespace Kr
{
}
class Program
{
    private void M(object sender, EventArgs e) { }
    private static void M_Static(object sender, EventArgs e) { }
    static void Task1()
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

    public enum SortDirection
    {
        Ascending,
        Descending
    }
    public class MyObservableCollection<T> : IList<T>, INotifyCollectionChanged
    {

        public MyObservableCollection():this(4) { }

        public MyObservableCollection(int count)
        {
            arr = new T[count];
            Count = 0;
        }

        public MyObservableCollection(T[] array)
        {
            try
            {
                arr = new T[array.Length];
                array.CopyTo(arr, 0);
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, arr, 0));
            }
            catch
            {
                throw;
            }
        }

        private T[] arr;
        private IEnumerable<T> Arr
        {
            get
            {
                for (int i = 0; i < Count; i++)
                    yield return arr[i];
            }
        }
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public T this[int index]
        {
            get
            {
                try
                {
                    if (IsIndexValid(index))
                        return arr[index];
                    else
                        throw new IndexOutOfRangeException();
                }
                catch
                {
                    throw;
                }
            }

            set
            {
                try
                {
                    if (IsIndexValid(index))
                    {
                        var valueToReplace = arr[index];
                        arr[index] = value;
                        CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, valueToReplace, index));
                    }
                    else
                        throw new IndexOutOfRangeException();
                }
                catch
                {
                    throw;
                }
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
                if (EqualityComparer<T>.Default.Equals(arr[i], item))
                    return i;

            return -1;
        }
        private void TryResize(int count = 1)
        {
            if (Count + count > arr.Length)
            {
                var arrTmp = arr;
                arr = new T[arrTmp.Length * 2];
                arrTmp.CopyTo(arr, 0);
            }
        }
        private bool IsIndexValid(int index) => index.Between(0, Count);
        public void Insert(int index, T item)
        {
            if (IsIndexValid(index))
            {
                TryResize();
                Count++;
                for (int i = index + 1; i < Count; i++)
                {
                    arr[i - 1] = arr[i];
                    CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, arr[i - 1], i - 1, i));
                }
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, arr.Skip(index + 1), index + 1, index));
                arr[index] = item;
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
            }
            else
                throw new IndexOutOfRangeException();
        }

        public void RemoveAt(int index)
        {
            if (IsIndexValid(index))
                Remove(arr[index]);
            else
                throw new IndexOutOfRangeException();
        }

        public void Add(T item)
        {
            TryResize();
            arr[Count] = item;
            Count++;
            CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, Count - 1));
        }

        public void Clear()
        {
            var arrTmp = arr;
            Array.Clear(arr, 0, arr.Length);
            Count = 0;
            CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, arrTmp, 0));
        }

        public bool Contains(T item) => Arr.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            try
            {
                Arr.ToArray().CopyTo(array, arrayIndex);
            }
            catch
            {
                throw;
            }
        }

        public bool Remove(T item)
        {
            if (IndexOf(item) is int index && IsIndexValid(index))
            {
                for (int i = index + 1; i < Count; i++)
                {
                    arr[i - 1] = arr[i];
                    CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, arr[i - 1], i - 1, i));
                }

                Count--;
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, arr.Skip(index), index, index + 1));
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
                return true;
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator() => Arr.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public MyObservableCollection<T> Sort(SortDirection diraction = SortDirection.Ascending) => Sort(Comparer<T>.Default, diraction);
        public MyObservableCollection<T> Sort(IComparer<T> comparer, SortDirection diraction = SortDirection.Ascending) => new MyObservableCollection<T>((diraction == SortDirection.Ascending ? Arr.OrderBy(p => p, comparer) : Arr.OrderByDescending(p => p, comparer)).ToArray());
    }
    static void Task2()
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
    static void Task3()
    {
        var racers = Formula1.GetChampions();
        var teams = Formula1.GetContructorChampions().SelectMany(p => p.Years.Select(y => new { Year = y, p.Name }));

        var p1 = racers.Max(p => p.LastName.Length) + 1;
        var p2 = teams.Max(p => p.Name.Length) + 1;

        Console.WriteLine("Год".PadRight(5) + "Чемпион".PadRight(p1) + "Кубок конструкторов".PadRight(p2));
        Console.WriteLine(teams
                        .OrderByDescending(p => p.Year)
                        .Select(p => new { team = p, champion = racers.FirstOrDefault(r => r.Years.Contains(p.Year) && r.Cars.Contains(p.Name)) })
                        .Where(p => p.champion != null)
                        .Take(10)
                        .Select(p => $"{p.team.Year.ToString().PadRight(5)}{(p.champion?.LastName ?? new string('-', p1 - 1)).PadRight(p1)}{p.team.Name.PadRight(p2)} \n").Combine());
    }
    static void Main(string[] args)
    {
        Task1();
        Console.ReadKey(true);
    }
}
