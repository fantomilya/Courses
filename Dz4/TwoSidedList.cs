using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    class TwoSidedList<T> : ICollection<T> where T : IComparable<T>
    {
        Node<T> _first;
        Node<T> _last;

        public TwoSidedList()
        {

        }
        public TwoSidedList(T n) => _first = _last = new Node<T>(n);

        public T this[int index]
        {
            get
            {
                var currentCount = Count;
                if (index >= 0 && index < currentCount)
                {
                    bool fromStart = index < Count / 2;
                    index = fromStart ? index : currentCount - index - 1;
                    Node<T> searchingNode = fromStart ? _first : _last;
                    for (int i = 0; i < index && searchingNode != null; i++, searchingNode = fromStart ? searchingNode.next : searchingNode.prev) ;
                    return searchingNode == null ? default(T) : searchingNode.value;
                }
                return default(T);
            }
        }
        Node<T> this[T target]
        {
            get
            {
                Node<T> node = null;
                foreach (Node<T> v in this as IEnumerable)
                    if (v.value.CompareTo(target) == 0)
                        node = v;

                return node;
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var v in this)
                    count++;

                return count;
            }
        }
        public bool IsReadOnly => false;
        public void Add(T item)
        {
            var newNode = new Node<T>(item);
            if (_first != null)
            {
                newNode.prev = _last;
                _last.next = newNode;
                _last = newNode;
            }
            else
                _first = _last = newNode;
        }
        public void Clear()
        {
            _first = _last = null;
        }
        public bool Contains(T item) => this[item] != null;
        public void CopyTo(T[] array, int arrayIndex)
        {
            int count = Count;
            for (int i = 0; i < count; i++)
                array[arrayIndex + i] = this[i];
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = _first;
            while (currentNode != null)
            {
                yield return currentNode.value;
                currentNode = currentNode.next;
            }
        }
        public bool Remove(T item)
        {
            if (this[item] is Node<T> currentNode)
            {

                if (currentNode?.prev is Node<T> preNode)
                    preNode.next = currentNode.next;
                else
                    _first = currentNode.next;

                if (currentNode.next is Node<T> postNode)
                    postNode.prev = currentNode.prev;
                else
                    _last = currentNode.prev;

                return true;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            Node<T> currentNode = _first;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.next;
            }
        }
        public void AddLast(T item) => Add(item);
        public bool AddAfter(T target, T item)
        {
            if (this[target] is Node<T> node)
            {
                var insertingNode = new Node<T>(item);
                node.next.prev = insertingNode;
                insertingNode.next = node.next;
                node.next = insertingNode;
                insertingNode.prev = node;

                if (node == _last)
                    _last = insertingNode;

                return true;
            }
            else
                return false;
        }
        public override string ToString() => (this as IEnumerable).Cast<Node<T>>().Select((p, i) => i.ToString() + ". " + p.ToString() + "\n").DefaultIfEmpty(" ").Aggregate(string.Concat);
    }
}
