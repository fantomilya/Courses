using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dz4
{
    internal class MyLinkedList<T> : IList<T> where T : IComparable<T>
    {
        private Node<T> First { get; set; }
        private Node<T> Last { get; set; }

        public MyLinkedList() { }
        public MyLinkedList(T n) => First = Last = new Node<T>(n);

        public T this[int index]
        {
            get => GetNodeByIndex(index) is Node<T> node ? node.Value : default(T);
            set
            {
                if (GetNodeByIndex(index) is Node<T> node && node.Value.CompareTo(value) != 0)
                {
                    Node<T> newNode = new Node<T>(value)
                    {
                        Prev = node.Prev,
                        Next = node.Next
                    };
                    if (node.Prev is Node<T> preNode)
                        preNode.Next = newNode;
                    else
                        First = newNode;

                    if (node.Next is Node<T> postNode)
                        postNode.Prev = newNode;
                    else
                        Last = newNode;
                }
            }
        }
        private Node<T> this[T target] => GetNodes().FirstOrDefault(p => p.Value.CompareTo(target) == 0);

        public int Count => GetEnum().Count();
        public bool IsReadOnly => false;

        public void Clear() => First = Last = null;
        public bool Contains(T item) => this[item] != null;
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex + Count > array.Length)
                return;

            int i = 0;
            foreach (T v in this)
            {
                array[arrayIndex + i] = v is ICloneable cl ? (T)cl.Clone() : v;
                i++;
            }
        }
        private IEnumerable<T> GetEnum() => GetNodes().Select(p => p.Value);
        private IEnumerable<Node<T>> GetNodes()
        {
            Node<T> currentNode = First;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }
        public IEnumerator<T> GetEnumerator() => GetEnum().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int IndexOf(T item) => this.Select((p, index) => new { node = p, index }).FirstOrDefault(p => p.node.CompareTo(item) == 0)?.index ?? -1;
        public void Add(T item) => Insert(Count, item);
        public void AddAfter(T target, T item) => Insert(IndexOf(target) + 1, item);
        public void Insert(int index, T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (index == 0 && First == null)
                First = Last = newNode;
            else if (GetNodeByIndex(index) is Node<T> postNode)
            {
                newNode.Next = postNode;
                newNode.Prev = postNode.Prev;

                if (postNode.Prev is Node<T> preNode)
                    preNode.Next = newNode;
                else
                    First = newNode;

                postNode.Prev = newNode;
            }
            else if (index == Count)
            {
                Last.Next = newNode;
                newNode.Prev = Last;
                Last = newNode;
            }
        }
        public bool Remove(T item)
        {
            if (IndexOf(item) is int index && index >= 0 && index < Count)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            if (GetNodeByIndex(index) is Node<T> currentNode)
            {
                if (currentNode.Prev is Node<T> preNode)
                    preNode.Next = currentNode.Next;
                else
                    First = currentNode.Next;

                if (currentNode.Next is Node<T> postNode)
                    postNode.Prev = currentNode.Prev;
                else
                    Last = currentNode.Prev;
            }
        }

        private Node<T> GetNodeByIndex(int index)
        {
            int currentCount = Count;
            if (index < 0 || index >= currentCount)
                return null;

            bool fromStart = index < Count / 2;
            index = fromStart ? index : currentCount - index - 1;
            Node<T> searchingNode = fromStart ? First : Last;
            for (int i = 0; i < index && searchingNode != null; i++, searchingNode = fromStart ? searchingNode.Next : searchingNode.Prev) ;

            return searchingNode;
        }
        public override string ToString() => this.GetString(", ", "\"", "\"");
    }
    public class Node<T> where T : IComparable<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
        public T Value { get; }
        public Node(T value) => Value = value;
        public override string ToString() => Value.ToString();
    }
}
