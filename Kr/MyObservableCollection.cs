using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Extensions;

namespace Kr
{
        public enum SortDirection
        {
            Ascending,
            Descending
        }
        public class MyObservableCollection<T> : IList<T>, INotifyCollectionChanged
        {

            public MyObservableCollection() : this(4) { }

            public MyObservableCollection(int count)
            {
                _arr = new T[count];
                Count = 0;
            }

            public MyObservableCollection(T[] array)
            {
                _arr = new T[array.Length];
                array.CopyTo(_arr, 0);
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, _arr, 0));
            }

            private T[] _arr;
            private IEnumerable<T> Arr
            {
                get
                {
                    for (int i = 0; i < Count; i++)
                        yield return _arr[i];
                }
            }
            public int Count { get; private set; }

            public bool IsReadOnly => false;

            public event NotifyCollectionChangedEventHandler CollectionChanged;

            public T this[int index]
            {
                get
                {
                    if (IsIndexValid(index))
                        return _arr[index];

                    throw new IndexOutOfRangeException();
                }

                set
                {
                    if (IsIndexValid(index))
                    {
                        var valueToReplace = _arr[index];
                        _arr[index] = value;
                        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, valueToReplace, index));
                    }
                    else
                        throw new IndexOutOfRangeException();
                }
            }

            public int IndexOf(T item)
            {
                for (int i = 0; i < Count; i++)
                    if (EqualityComparer<T>.Default.Equals(_arr[i], item))
                        return i;

                return -1;
            }
            private void TryResize(int count = 1)
            {
                if (Count + count > _arr.Length)
                {
                    var arrTmp = _arr;
                    _arr = new T[arrTmp.Length * 2];
                    arrTmp.CopyTo(_arr, 0);
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
                        _arr[i] = _arr[i - 1];

                    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, _arr.Skip(index + 1), index + 1, index));
                    _arr[index] = item;
                    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
                }
                else
                    throw new IndexOutOfRangeException();
            }

            public void RemoveAt(int index)
            {
                if (IsIndexValid(index))
                    Remove(_arr[index]);
                else
                    throw new IndexOutOfRangeException();
            }

            public void Add(T item)
            {
                TryResize();
                _arr[Count] = item;
                Count++;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, Count - 1));
            }

            public void Clear()
            {
                var arrTmp = _arr;
                Array.Clear(_arr, 0, _arr.Length);
                Count = 0;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, arrTmp, 0));
            }

            public bool Contains(T item) => Arr.Contains(item);

            public void CopyTo(T[] array, int arrayIndex) => Arr.ToArray().CopyTo(array, arrayIndex);

            public bool Remove(T item)
            {
                if (IndexOf(item) is int index && IsIndexValid(index))
                {
                    for (int i = index + 1; i < Count; i++)
                        _arr[i - 1] = _arr[i];

                    Count--;
                    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, _arr.Skip(index), index, index + 1));
                    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
                    return true;
                }
                return false;
            }
            public IEnumerator<T> GetEnumerator() => Arr.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public MyObservableCollection<T> Sort(SortDirection diraction = SortDirection.Ascending) => Sort(Comparer<T>.Default, diraction);
            public MyObservableCollection<T> Sort(IComparer<T> comparer, SortDirection diraction = SortDirection.Ascending) => new MyObservableCollection<T>((diraction == SortDirection.Ascending ? Arr.OrderBy(p => p, comparer) : Arr.OrderByDescending(p => p, comparer)).ToArray());
        }
}
