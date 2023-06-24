### problem domain

Create a Node class that has properties for the value stored in the Node, and a pointer to the next Node. And Create a Linked List class that includes these methods:

- insert
- includes
- to string

### test cases

1. Can successfully instantiate an empty linked list
2. Can properly insert into the linked list
3. The head property will properly point to the first node in the linked list
4. Can properly insert multiple nodes into the linked list
5. Will return true when finding a value within the linked list that exists
6. Will return false when searching for a value in the linked list that does not exist
7. Can properly return a collection of all the values that exist in the linked list

### algorithm

- Create a new instance of the LinkedList.
- add the node to the linked list.
- initialize the current node with the head.
- call the includes method to check if some values exist.
- call the ToString method to print the values as a string.
- create a Node class that has properties for the value stored in the Node.
- create a Linked List class.
- add the includes and ToString and AddToTheLast methods
- AddToTheLast(): adds a new node with the data value to the end of the linked list.
- includes(): Checks if the linked list contains a node with the specified value and returns true if found, or false if not.
- ToString(): Generates a string representation of the linked list by concatenating the data values of each node enclosed in braces ({}).

### big O

time complexity for all the methods in this app is O(n), except for the AddToLast method which will be O(1) because it does not depend on the size of the array and it will execute instantly.

### code

```
using System.Collections.Generic;
using System.Xml.Linq;
internal class Program
{
    static void Main(string[] args)
    {
        LinkedList myList = new LinkedList();

        myList.AddToTheLast(5);
        myList.AddToTheLast(5);
        myList.AddToTheLast(5);

        // Console.WriteLine("Elements in the list");

        Node currentNode = myList.head;

        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Data);
            currentNode = currentNode.Next;
        }

        Console.WriteLine("Elments in the linked list after insetion");

        Node currentNode2 = myList.head;

        while (currentNode2 != null)
        {
            Console.WriteLine(currentNode2.Data);
            currentNode2 = currentNode2.Next;
        }
        ////////////////////////////////////////////////////////////////////
        // to check if values exist
        Console.WriteLine(myList.Includes(4));
        Console.WriteLine(myList.Includes(5));
        ////////////////////////////////////////////////////////////////////
        // to print values
        Console.WriteLine(myList.ToString());
        ////////////////////////////////////////////////////////////////////
    }
}

public class Node
{
    public int Data { get; set; }

    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    public Node head { get; set; }
    public Node tail { get; set; }

    public LinkedList()
    {
        head = null;
        tail = null;
    }

    public void AddToTheLast(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {

            tail.Next = newNode;

            tail = newNode;
        }
    }
    public bool Includes(int value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data == value)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public string ToString()
    {
        string res = string.Empty;
        Node current = head;
        while (current != null)
        {
            res += "{" + current.Data + "}";
            current = current.Next;
        }
        // res += "}";
        return res;
    }
}
```

### unit tests

```
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
            string expected = "{5} {10} {15} ";
            string result = linkedList.ToString();
            Assert.Equal(expected, result);
        }
    }
}
```

### white board screenshot

![white board image](/assets/linkedlist.jpg)
