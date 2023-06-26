//namespace LinkedListTest
using System.Collections.Generic;
using System.Numerics;

namespace LinkedListTest
{
    public class UnitTest1
    {
        [Fact]
        public void Instantiate_EmptyLinkedList()
        {
            LinkedList linkedList = new LinkedList();
            Assert.Null(linkedList.head);
        }

        [Fact]
        public void Insert_IntoLinkedList()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTheLast(5);
            Assert.NotNull(linkedList.tail);
            Assert.Equal(5, linkedList.head.Data);
        }

        [Fact]
        public void HeadPointsToTheFirstNode()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTheLast(5);
            linkedList.AddToTheLast(10);
            Assert.NotNull(linkedList.head);
            Assert.Equal(5, linkedList.head.Data);
        }

        [Fact]
        public void InsertMultipleNodes()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTheLast(5);
            linkedList.AddToTheLast(10);
            linkedList.AddToTheLast(15);
            Assert.NotNull(linkedList.tail);
            Assert.Equal(15, linkedList.tail.Data);
        }

        [Fact]
        public void Returns_TrueWhenValueExists()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTheLast(5);
            linkedList.AddToTheLast(10);
            linkedList.AddToTheLast(15);
            bool exists = linkedList.Includes(10);
            Assert.True(exists);
        }

        [Fact]
        public void Returns_FalseWhenValueDoesNotExist()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTheLast(5);
            linkedList.AddToTheLast(10);
            linkedList.AddToTheLast(15);
            bool exists = linkedList.Includes(20);
            Assert.False(exists);
        }

        [Fact]
        public void Return_AllValuesInLinkedList()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTheLast(5);
            linkedList.AddToTheLast(10);
            linkedList.AddToTheLast(15);
            string expected = "{5}{10}{15}";
            string result = linkedList.ToString();
            Assert.Equal(expected, result);
        }
    }
}