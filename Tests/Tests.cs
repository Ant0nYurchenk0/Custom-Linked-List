using List;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{

    [TestFixture]
    public class Tests
    {
        private MyLinkedList<int> _controlLinkedList;
        private IEnumerable<int> _controlCollection;
        [SetUp]
        public void Setup()
        {
            _controlCollection = new List<int> { 1, 2, 3};
            _controlLinkedList = new MyLinkedList<int>();
            _controlLinkedList.Add(1);
            _controlLinkedList.Add(2);
            _controlLinkedList.Add(3);                     
        }
        [Test]
        public void Count()
        {
            var newList = new MyLinkedList<int>();
            newList.Add(1);

            Assert.AreEqual(newList.Count, 1);

            newList.Add(1);

            Assert.AreEqual(newList.Count, 2);
        }
        [Test]
        public void IEnumerableCtor()
        {
            var newList = new MyLinkedList<int>(_controlCollection);

            Assert.AreEqual(_controlLinkedList, newList);
        }
        [Test]       
        [TestCase(-1)]
        [TestCase(4)]
        public void AddAt_OutOfRange_ThrowsException(int position)
        {
            
            Assert.That(() => _controlLinkedList.AddAt(position, 1), 
                Throws.Exception
                .TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        [TestCase( 0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void AddAt_CorrectPosition_NewLinkedList( int position, int value)
        {
            List<int> initialList;
            if (position == 0)
                initialList = new List<int> { 2, 3 };
            else if (position == 1)
                initialList = new List<int> {1, 3 };
            else
                initialList = new List<int> {1, 2 };

            var newLinkedList = new MyLinkedList<int>(initialList);
            
            newLinkedList.AddAt(position, value);

            Assert.AreEqual(newLinkedList, _controlLinkedList);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(4)]
        public void RemoveAt_OutOfRange_ThrowsException(int position)
        {

            Assert.That(() => _controlLinkedList.RemoveAt(position),
                Throws.Exception
                .TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void RemoveAt_CorrectPosition_NewLinkedList(int position)
        {
            MyLinkedList<int> finalList;
            if (position == 0)
                finalList = new MyLinkedList<int>(new int[] {2, 3});
            else if (position == 1)
                finalList = new MyLinkedList<int>(new int[] {1, 3});
            else
                finalList = new MyLinkedList<int>(new int[] {1, 2});

            var newLinkedList = new MyLinkedList<int>(_controlCollection);

            newLinkedList.RemoveAt(position);

            Assert.AreEqual(newLinkedList, finalList);
        }
        [Test]
        public void PopFirst()
        {
            var newList = new MyLinkedList<int>(_controlCollection);

            var popped = newList.PopFirst();

            Assert.AreEqual(popped, 1);
            Assert.AreEqual(newList, new MyLinkedList<int>(new int[] { 2, 3}));
        }
        [Test]
        public void PopLast()
        {
            var newList = new MyLinkedList<int>(_controlCollection);

            var popped = newList.PopLast();

            Assert.AreEqual(popped, 3);
            Assert.AreEqual(newList, new MyLinkedList<int>(new int[] { 1, 2}));
        }
        [Test]
        [TestCase(-1)]
        [TestCase(4)]
        public void PopAt_OutOfRange_ThrowsException(int position)
        {
            Assert.That(() => _controlLinkedList.PopAt(position),
                Throws.Exception
                .TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void PopAt_CorrectPosition_NewLinkedList(int position, int result)
        {
            MyLinkedList<int> finalList;
            if (position == 0)
                finalList = new MyLinkedList<int>(new int[] { 2, 3 });
            else if (position == 1)
                finalList = new MyLinkedList<int>(new int[] { 1, 3 });
            else
                finalList = new MyLinkedList<int>(new int[] { 1, 2 });

            var newLinkedList = new MyLinkedList<int>(_controlCollection);

            var popped = newLinkedList.PopAt(position);

            Assert.AreEqual(newLinkedList, finalList);
            Assert.AreEqual(popped, result);
        }
    }
}