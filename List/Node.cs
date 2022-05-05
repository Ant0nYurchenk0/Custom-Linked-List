
namespace List
{
    internal class Node<T>
    {
        internal T Value { get; set; }
        internal Node<T> NextNode { get; set; }
        internal Node(T value)
        {
            Value = value;
        }
    }
}
