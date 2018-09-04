using System;

namespace Dz4
{
    public class Node<T> where T : IComparable<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
        public T Value { get; }
        public Node(T value) => Value = value;
        public override string ToString() => Value.ToString();
    }
}
