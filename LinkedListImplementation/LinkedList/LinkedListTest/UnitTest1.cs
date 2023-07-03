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
        ///////////////////////////////////////////
        [Fact]
        public void AddMultipleNodesToTheEnd()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTheLast(1);
            linkedList.AddToTheLast(2);
            linkedList.AddToTheLast(3);
            string expected = "{1}{2}{3}";
            string result = linkedList.ToString();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void InsertNodeBeforeTheMiddleNode()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(1);
            myList.AddToTheLast(2);
            myList.AddToTheLast(3);

            myList.InsertBefore(2, 10); ///////

            Assert.Equal("{1}{10}{2}{3}", myList.ToString());
        }
        [Fact]



        public void InsertNodeBeforeTheFirstNode()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(1);
            myList.AddToTheLast(2);
            myList.AddToTheLast(3);

            myList.InsertBefore(1, 10);

            Assert.Equal("{10}{1}{2}{3}", myList.ToString());
        }
        [Fact]
        public void InsertNodeAfterTheMiddleNode()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(1);
            myList.AddToTheLast(2);
            myList.AddToTheLast(3);

            myList.InsertAfter(2, 10);

            Assert.Equal("{1}{2}{10}{3}", myList.ToString());
        }

        [Fact]
        public void InsertNodeAfterTheLastNode()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(1);
            myList.AddToTheLast(2);
            myList.AddToTheLast(3);

            myList.InsertAfter(3, 10);

            Assert.Equal("{1}{2}{3}{10}", myList.ToString());
        }
        //////////////////////////////////////////////////////////////////////////////////////

        [Fact]
        public void kthFromTheEnd_KGreaterThanLength_ThrowsException()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(5);
            myList.AddToTheLast(10);
            myList.AddToTheLast(15);

            // assert with the exception:
            Assert.Throws<ArgumentOutOfRangeException>(() => myList.kthFromTheEnd(4));
        }

        [Fact]
        public void kthFromTheEnd_KEquals_Length_ReturnsLastValue()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(5);
            myList.AddToTheLast(10);
            myList.AddToTheLast(15);

            int result = myList.kthFromTheEnd(3);

            Assert.Equal(5, result);
        }

        [Fact]
        public void kthFromTheEnd_KNegative_ThrowsException()
        {
            LinkedList myList = new LinkedList();
            myList.AddToTheLast(5);
            myList.AddToTheLast(10);
            myList.AddToTheLast(15);

            Assert.Throws<NullReferenceException>(() => myList.kthFromTheEnd(-1));
        }

        [Fact]
        public void kthFromTheEnd_OneNodeList_ReturnsValue()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(5);

            int result = myList.kthFromTheEnd(1);

            Assert.Equal(5, result);
        }
        [Fact]
        public void kthFromTheEnd_KInTheMiddle_ReturnsValue()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(5);
            myList.AddToTheLast(10);
            myList.AddToTheLast(15);
            myList.AddToTheLast(20);

            int result = myList.kthFromTheEnd(3);

            Assert.Equal(10, result);
        }


    }
}