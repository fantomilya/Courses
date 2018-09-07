using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Extensions;

namespace LinkList
{
    public class LinkList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>
        where T : IEquatable<T>
    {
        public LinkList()
        {
        }
        public LinkList(IEnumerable<T> collection)
        {
            foreach (var v in collection)
                AddLast(v);
        }

        public LinkListNode<T> Last { get; private set; }
        public LinkListNode<T> First { get; private set; }
        public int Count { get; private set; }
        bool ICollection<T>.IsReadOnly => false;
        object ICollection.SyncRoot => null;
        bool ICollection.IsSynchronized => false;

        public void AddAfter(LinkListNode<T> node, LinkListNode<T> newNode)
        {
            if (newNode.List != null || (node?.List ?? this) != this)
                return;

            if (First == null || Last == null)
                First = Last = newNode;
            else if (node == null)
            {
                newNode.Next = First;
                First.Previous = newNode;
                First = newNode;
            }
            else
            {
                if (node.Next is LinkListNode<T> nextNode)
                {
                    nextNode.Previous = newNode;
                    newNode.Next = nextNode;
                }
                else
                    Last = newNode;

                newNode.Previous = node;
                node.Next = newNode;
            }

            newNode.List = this;
            Count++;
        }
        public LinkListNode<T> AddAfter(LinkListNode<T> node, T value)
        {
            var newNode = new LinkListNode<T>(value);
            AddAfter(node, newNode);
            return newNode;
        }
        public LinkListNode<T> AddBefore(LinkListNode<T> node, T value)
        {
            var newNode = new LinkListNode<T>(value);
            AddBefore(node, newNode);
            return newNode;
        }
        public void AddBefore(LinkListNode<T> node, LinkListNode<T> newNode) => AddAfter(node?.Previous, newNode);
        public LinkListNode<T> AddFirst(T value) => AddBefore(First, value);
        public void AddFirst(LinkListNode<T> node) => AddBefore(First, node);
        public LinkListNode<T> AddLast(T value) => AddAfter(Last, value);
        public void AddLast(LinkListNode<T> node) => AddAfter(Last, node);
        void ICollection<T>.Add(T item) => AddLast(item);

        public void Clear()
        {
            var currentNode = First;
            while (currentNode != null)
            {
                var tmp = currentNode.Next;
                ClearNode(currentNode);
                currentNode = tmp;
            }
            Last = First = null;
            Count = 0;
        }

        private void ClearNode(LinkListNode<T> node)
        {
            node.Previous = node.Next = null;
            node.List = null;
        }
        public bool Remove(T value)
        {
            if (Find(value) is LinkListNode<T> node)
            {
                Remove(node);
                return true;
            }
            return false;
        }
        public void Remove(LinkListNode<T> node)
        {
            if (node == null || node.List != this)
                return;

            if (node == First && node == Last)
            {
                Clear();
                return;
            }

            if (node.Previous is LinkListNode<T> prevNode)
                prevNode.Next = node.Next;
            else
            {
                node.Next.Previous = null;
                First = node.Next;
            }

            if (node.Next is LinkListNode<T> nextNode)
                nextNode.Previous = node.Previous;
            else
            {
                node.Previous.Next = null;
                Last = node.Previous;
            }
            ClearNode(node);
            Count--;
        }
        public void RemoveFirst() => Remove(First);
        public void RemoveLast() => Remove(Last);
        public bool Contains(T value) => Find(value) != null;
        public void CopyTo(T[] array, int index)
        {
            if (index + Count > array.Length)
                return;

            foreach (var v in this)
                array[index++] = v;
        }
        void ICollection.CopyTo(Array array, int index) => CopyTo(array as T[], index);
        public LinkListNode<T> Find(T value) => ToEnumerable().FirstOrDefault(p=> value == null ? p.Value == null : p.Value.Equals(value));
        public LinkListNode<T> FindLast(T value)
        {
            var currentNode = Last;

            while (!(currentNode == null || (value == null ? currentNode.Value == null : currentNode.Value.Equals(value))))
                currentNode = currentNode.Previous;

            return currentNode;
        }

        private IEnumerable<LinkListNode<T>> ToEnumerable()
        {
            var currentNode = First;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => ToEnumerable().Select(p => p.Value).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => (this as IEnumerable<T>).GetEnumerator();

        public override string ToString() => ToEnumerable().GetString(", ", "\"", "\"");
    }

    public class LinkListNode<T>
        where T : IEquatable<T>
    {
        public LinkListNode(T value) : this(value, null) { }
        public LinkListNode(T value, LinkList<T> list)
        {
            Value = value;
            List = list;
        }
        public LinkList<T> List { get; internal set; }
        public LinkListNode<T> Next { get; internal set; }
        public LinkListNode<T> Previous { get; internal set; }
        public T Value { get; set; }
        public override string ToString() => Value.ToString();
    }
}
