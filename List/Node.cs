
using System.Collections.Generic;

namespace List
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> NextNode { get; set; }
        public Node(T value)
        {
            Value = value;
        }
        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 31 + (Value == null ? 0 : Value.GetHashCode());
            return hash;
        }

        public override bool Equals(object other)
        {
            return Equals(other as Node<T>);
        }

        public bool Equals(Node<T> other)
        {
            if(EqualityComparer<T>.Default.Equals(other.Value, Value))
                return true;
            return false;
        }


    }
}
