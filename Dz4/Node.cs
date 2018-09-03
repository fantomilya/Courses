using System;

namespace Dz4
{
    public class Node<T> where T : IComparable<T>
    {
        public Node<T> next;
        public Node<T> prev;
        public T value;
        public Node(T value) => this.value = value;
        public override string ToString() => value.ToString();
    }
}
