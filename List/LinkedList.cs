using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace List
{
    public class MyLinkedList<T> : IEnumerable<Node<T>>
    {
        public Node<T> First { get; private set; }
        public Node<T> Last { get; private set; }
        public int Count { get { return GetCount(); } }

        public MyLinkedList()
        {

        }

        public MyLinkedList(IEnumerable<T> iEnumerable)
        {
            First = new Node<T>(iEnumerable.First());
            var currentNode = First;
            for(var i = 1; i < iEnumerable.Count(); i++)
            {
                currentNode.NextNode = new Node<T>(iEnumerable.ElementAt(i));
                currentNode = currentNode.NextNode;
            }
            Last = currentNode;
        }
        public MyLinkedList(IEnumerable<Node<T>> iEnumerable)
        {
            First = iEnumerable.First();
            var currentNode = First;
            for (var i = 1; i < iEnumerable.Count(); i++)
            {
                currentNode.NextNode = iEnumerable.ElementAt(i);
                currentNode = currentNode.NextNode;
            }
            Last = currentNode;
        }


        public void Add(T Value)
        {
            if(First == null)
            {
                First = new Node<T>(Value);
                Last = First;
            }
            else
            {
                var newNode = new Node<T>(Value);
                Last.NextNode = newNode;
                Last = newNode;
            }
        }

        public void AddAt(int position, T value)
        {
            if (position < 0 || position > Count)
                throw new ArgumentOutOfRangeException($"Invalid position: {position}");
            var newNode = new Node<T>(value);
            if (position == 0)
            {
                var tempNode = First;
                First = newNode;
                First.NextNode = tempNode;
                return;
            }   
            if (position == Count)
            {
                Last.NextNode = newNode;
                Last = Last.NextNode;
                return;
            }
            var previousNode = GetElementAt(position-1);
            var nextNode = GetElementAt(position);
            newNode.NextNode = nextNode;
            previousNode.NextNode = newNode;
            Last = GetElementAt(Count-1);
        }
        public void RemoveAt(int position)
        {
            if (position < 0 || position > Count)
                throw new ArgumentOutOfRangeException($"Invalid position: {position}");
            if (position == 0)
            {
                First = First.NextNode;
                return;
            }
            var previousNode = GetElementAt(position - 1);
            if(position == Count)
            {
                previousNode.NextNode = null;
                Last = previousNode;
            }
            var nextNode = GetElementAt(position+1);
            previousNode.NextNode=nextNode;
        }
        public Node<T> PopLast()
        {
            var popped = Last;
            RemoveAt(Count - 1);
            return popped;
        }
        public Node<T> PopFirst()
        {
            var popped = First;
            RemoveAt(0);
            return popped;
        }
        public Node<T> PopAt(int position)
        {
            var popped = GetElementAt(position);
            RemoveAt(position);
            return popped;
        }
        public IEnumerator<Node<T>> GetEnumerator()
        {
            var currentNode = First;
            while (currentNode.NextNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        Node<T> GetElementAt(int position)
        {
            if (position < 0 || position > Count)
                throw new ArgumentOutOfRangeException($"Invalid position: {position}");
            if(position == 0)
                return First;
            var counter = 0;
            var currentNode = First;
            while (counter != position)
            {
                currentNode = currentNode.NextNode;
                counter++;
            }
            return currentNode;
        }
        int GetCount()
        {
            if(First == null)
                return 0;
            var currentNode = First;
            var counter = 1;
            while(currentNode.NextNode != null)
            {
                counter++;
                currentNode = currentNode.NextNode;
            }
            return counter;
        }
    }
}
