using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace List
{
    public class MyLinkedList<T> :IEnumerable<T>
    {
        public T First { get { return _first.Value; }  }
        public T Last { get { return _last.Value; }  }
        public int Count { get { return GetCount(); } }

        private Node<T> _first;
        private Node<T> _last;


        public MyLinkedList()
        {

        }

        public MyLinkedList(IEnumerable<T> iEnumerable)
        {
            _first = new Node<T>(iEnumerable.First());
            var currentNode = _first;
            for(var i = 1; i < iEnumerable.Count(); i++)
            {
                currentNode.NextNode = new Node<T>(iEnumerable.ElementAt(i));
                currentNode = currentNode.NextNode;
            }
            _last = currentNode;
        }


        public void Add(T Value)
        {
            if(_first == null)
            {
                _first = new Node<T>(Value);
                _last = _first;
            }
            else
            {
                var newNode = new Node<T>(Value);
                _last.NextNode = newNode;
                _last = newNode;
            }
        }

        public void AddAt(int position, T value)
        {
            if (position < 0 || position > Count)
                throw new ArgumentOutOfRangeException($"Invalid position: {position}");
            var newNode = new Node<T>(value);
            if (position == 0)
            {
                var tempNode = _first;
                _first = newNode;
                _first.NextNode = tempNode;
                return;
            }   
            if (position == Count)
            {
                _last.NextNode = newNode;
                _last = _last.NextNode;
                return;
            }
            var previousNode = GetElementAt(position-1);
            var nextNode = GetElementAt(position);
            newNode.NextNode = nextNode;
            previousNode.NextNode = newNode;
            _last = GetElementAt(Count-1);
        }
        public void RemoveAt(int position)
        {
            if (position < 0 || position > Count)
                throw new ArgumentOutOfRangeException($"Invalid position: {position}");
            if (position == 0)
            {
                _first = _first.NextNode;
                return;
            }
            var previousNode = GetElementAt(position - 1);
            if(position == Count)
            {
                previousNode.NextNode = null;
                _last = previousNode;
            }
            var nextNode = GetElementAt(position+1);
            previousNode.NextNode=nextNode;
        }
        public T PopLast()
        {
            var popped = _last.Value;
            RemoveAt(Count - 1);
            return popped;
        }
        public T PopFirst()
        {
            var popped = _first.Value;
            RemoveAt(0);
            return popped;
        }
        public T PopAt(int position)
        {
            var popped = GetElementAt(position).Value;
            RemoveAt(position);
            return popped;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = _first;
            while (currentNode.NextNode != null)
            {
                yield return currentNode.Value;
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
                return _first;
            var counter = 0;
            var currentNode = _first;
            while (counter != position)
            {
                currentNode = currentNode.NextNode;
                counter++;
            }
            return currentNode;
        }
        int GetCount()
        {
            if(_first == null)
                return 0;
            var currentNode = _first;
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
