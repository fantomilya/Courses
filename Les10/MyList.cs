using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace Les10
{
    [Serializable]
    public class MyList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        [XmlElement("Array")]
        protected T[] arr;
        private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
        [XmlElement("Count")]
        public int Count { get; private set; }

        public MyList() : this(4) { }
        public MyList(int length) { arr = new T[length]; }

        public T this[int index]
        {
            get
            {
                if (!IsValueExists(index))
                {
                    DoSomethingOnError();
                    return default(T);
                }
                locker.EnterReadLock();
                T result = arr[index];
                locker.ExitReadLock();
                return result;

            }
            set
            {
                if (!IsValueExists(index))
                {
                    DoSomethingOnError();
                    return;
                }

                locker.EnterWriteLock();
                arr[index] = value;
                locker.ExitWriteLock();
            }
        }

        public void Add(T item)
        {
            Resize();
            locker.EnterWriteLock();
            arr[Count++] = item;
            locker.ExitWriteLock();
        }
        public void Insert(T item, int index)
        {
            if (!IsValueExists(index))
            {
                DoSomethingOnError();
                return;
            }
            Resize();
            locker.EnterWriteLock();
            Array.Copy(arr, index, arr, index + 1, Count - index - 1);
            Count++;
            arr[index] = item;
            locker.ExitWriteLock();
        }
        public void AddRange(params T[] item)
        {
            Resize(item.Length);
            locker.EnterWriteLock();
            item.CopyTo(arr, Count);
            Count += item.Length;
            locker.ExitWriteLock();
        }
        public void Clear()
        {
            locker.EnterWriteLock();
            Array.Clear(arr, 0, Count);
            Count = 0;
            locker.ExitWriteLock();
        }
        public void Remove(T value) => RemoveAt(Array.IndexOf(arr, value));

        public void RemoveAt(int index)
        {
            if (index < 0)
                return;

            locker.EnterWriteLock();
            Array.Copy(arr, index + 1, arr, index, Count - index - 1);
            Count--;
            locker.ExitWriteLock();
        }
        public MyList<T> Sort(SortDiraction dir = SortDiraction.Ascending)
        {
            locker.EnterReadLock();
            MyList<T> result = new MyList<T>(Count);
            result.AddRange(arr);
            locker.ExitReadLock();

            int Compare(T t1, T t2) => dir == SortDiraction.Ascending ? t1.CompareTo(t2) : t2.CompareTo(t1);

            for (int i = 1; i < Count; i++)
            {
                T current = result[i];

                int j = i;
                while (j > 0 && Compare(arr[j - 1], current) > 0)
                {
                    result[j] = result[j - 1];
                    j = j - 1;
                }
                result[j] = current;
            }
            return result;
        }
        public void Serialize(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(MyList<T>), new[] { typeof(T) });
            locker.EnterReadLock();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                    formatter.Serialize(fs, this);
            }
            finally
            {
                locker.ExitReadLock();
            }
        }
        public T Deserialize(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(MyList<T>), new[] { typeof(T) });
            locker.EnterWriteLock();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                    return (T)formatter.Deserialize(fs);
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
        public override string ToString()
        {
            locker.EnterWriteLock();
            string s = Count > 0 ? arr.Take(Count).Select(p => p.ToString() + " ").Aggregate(string.Concat).Trim() : string.Empty;
            locker.ExitWriteLock();
            return s;
        }
        private void DoSomethingOnError()
        {
            Console.WriteLine("Под данным индексом нет значения");
        }
        private void Resize(int insertableCount = 1)
        {
            locker.EnterReadLock();
            int mult = (int)Math.Ceiling(((double)(Count + insertableCount) / arr.Length));
            locker.ExitReadLock();
            if (mult > 1)
            {
                locker.EnterWriteLock();
                var tmpArr = new T[arr.Length * mult];
                arr.CopyTo(tmpArr, 0);
                arr = tmpArr;
                locker.ExitWriteLock();
            }
        }
        private bool IsValueExists(int index)
        {
            locker.EnterReadLock();
            bool exists = index < Count && index >= 0;
            locker.ExitReadLock();
            return exists;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => arr.Take(Count).AsEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => arr.Take(Count).GetEnumerator();

        public void ReadXml(string path)
        {
            XmlSerializer valueSerializer = new XmlSerializer(typeof(T));
            XmlSerializer countSerializer = new XmlSerializer(typeof(int));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            using (XmlReader reader = XmlReader.Create(fs))
            {
                reader.ReadStartElement("Array");
                Count = (int)countSerializer.Deserialize(reader);
                reader.ReadStartElement("Count");
                int i = 0;
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.ReadStartElement("value");
                    arr[i] = (T)valueSerializer.Deserialize(reader);
                    reader.ReadEndElement();

                    reader.MoveToContent();
                }
                reader.ReadEndElement();
            }
        }
        public void WriteXml(string path)
        {
            XmlSerializer valueSerializer = new XmlSerializer(typeof(T));
            XmlSerializer countSerializer = new XmlSerializer(typeof(int));

            using (FileStream sw = new FileStream(path, FileMode.Create))
            using (XmlWriter writer = XmlWriter.Create(sw))
            {
                writer.WriteStartElement("Array");

                writer.WriteStartElement("Count");
                countSerializer.Serialize(writer, Count);
                writer.WriteEndElement();

                foreach (T v in arr)
                {
                    writer.WriteStartElement("Value");
                    valueSerializer.Serialize(writer, v);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }
    }
}
