using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    class TwoSidedList<T> : ICollection<T> where T : IComparable<T>
    {
        Node<T> First { get; set; }
        Node<T> Last { get; set; }

        public TwoSidedList() { }
        public TwoSidedList(T n) => First = Last = new Node<T>(n);

        public T this[int index]
        {
            get
            {
                var currentCount = Count;
                if (index >= 0 && index < currentCount)
                {
                    bool fromStart = index < Count / 2;
                    index = fromStart ? index : currentCount - index - 1;
                    Node<T> searchingNode = fromStart ? First : Last;
                    for (int i = 0; i < index && searchingNode != null; i++, searchingNode = fromStart ? searchingNode.Next : searchingNode.Prev) ;
                    return searchingNode == null ? default(T) : searchingNode.Value;
                }
                return default(T);
            }
        }
        Node<T> this[T target] => (this as IEnumerable).Cast<Node<T>>().FirstOrDefault(p => p.Value.CompareTo(target) == 0);

        public int Count => (this as IEnumerable).Cast<Node<T>>().Count();
        public bool IsReadOnly => false;
        public void Add(T item)
        {
            var newNode = new Node<T>(item);
            if (First != null)
            {
                newNode.Prev = Last;
                Last.Next = newNode;
                Last = newNode;
            }
            else
                First = Last = newNode;
        }
        public void Clear() => First = Last = null;
        public bool Contains(T item) => this[item] != null;
        public void CopyTo(T[] array, int arrayIndex)
        {
            int i = 0;
            foreach (var v in this)
            {
                array[arrayIndex + i] = v is ICloneable cl ? (T)cl.Clone() : v;
                i++;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = First;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }
        public bool Remove(T item)
        {
            if (this[item] is Node<T> currentNode)
            {
                if (currentNode?.Prev is Node<T> preNode)
                    preNode.Next = currentNode.Next;
                else
                    First = currentNode.Next;

                if (currentNode.Next is Node<T> postNode)
                    postNode.Prev = currentNode.Prev;
                else
                    Last = currentNode.Prev;

                return true;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            Node<T> currentNode = First;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }
        public void AddLast(T item) => Add(item);
        public bool AddAfter(T target, T item)
        {
            if (this[target] is Node<T> node)
            {
                var insertingNode = new Node<T>(item);
                node.Next.Prev = insertingNode;
                insertingNode.Next = node.Next;
                node.Next = insertingNode;
                insertingNode.Prev = node;

                if (node == Last)
                    Last = insertingNode;

                return true;
            }
            else
                return false;
        }
        public override string ToString() => this.GetString(", ", "\"", "\"");
    }
}
