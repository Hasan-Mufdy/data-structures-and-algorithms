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

        Console.WriteLine("Elments in the linked list after insertion");

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
        ////////////////////////////////////////////////////////////////////
        Console.WriteLine("after insert before:");
        myList.InsertBefore(5, 10);
        Console.WriteLine(myList.ToString());
        Console.WriteLine("after insert after:");
        myList.InsertAfter(5, 20);
        Console.WriteLine(myList.ToString());

        Console.WriteLine("After appending 8: ");
        myList.Append(8);
        Console.WriteLine(myList.ToString());

        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        Console.WriteLine("kth method test with input 2:");
        Console.WriteLine(myList.kthFromTheEnd(2));
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        
        Console.WriteLine("merging 2 lists:");
        // 1. the first list: myList which was already created
        // 2. we need another list(myList2)
        LinkedList myList2 = new LinkedList();
        myList2.AddToTheLast(1000);
        myList2.AddToTheLast(2000);
        myList2.AddToTheLast(3000);

        Console.WriteLine();
        Console.WriteLine("the second list:  " + myList2.ToString());

        LinkedList mergedList = myList.ZipLists(myList2);
        Console.WriteLine("Merged list: " + mergedList.ToString());
        ////////////////////////////////////////////////////////////////////
        ///
        ////////////////////////////////////////////////////////////////////
        Stack stack = new Stack();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);


        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Peek());
        Console.WriteLine(stack.IsEmpty());  // false

        ////////////////////////////////////
        Queue queue = new Queue();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);


        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Peek());
        Console.WriteLine(queue.IsEmpty()); // false
        ////////////////////////////////////////////////////////////////////
        Console.ReadLine();
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

    /////////////////////////////// append method:
    public void Append(int data)
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

    /////////////////////////////// insert after and insert before methods:
    public void InsertAfter(int value, int newValue)
    {
        Node newNode = new Node(newValue);

        if (head == null)
        {
            return;
        }
        Node current = head;
        while (current != null)
        {
            if (current.Data == value)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                if (current == tail)
                {
                    tail = newNode; // in case of inserting at the last node
                }
                return;
            }
            current = current.Next;
        }
    }

    public void InsertBefore(int value, int newValue)
    {
        Node newNode = new Node(newValue);

        if (head == null)
        {
            return;
        }

        if (head.Data == value)
        {
            newNode.Next = head;
            head = newNode;
            return;
        }
        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Data == value)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                return;
            }
            current = current.Next;
        }
    }

    //////////////////////////////////////////////// kth:
    public int kthFromTheEnd(int k)
    {
        // no need to use it because it is not empty now.
        //if (head == null)
        //{
        //    throw new InvalidOperationException("the list is empty, add elements to the list...");
        //}

        Node slow = head;
        Node fast = head;

        for (int i = 0; i < k; i++)
        {
            if (fast == null)
            {
                throw new ArgumentOutOfRangeException("k");
            }
            fast = fast.Next;
        }

        while (fast != null)
        {
            slow = slow.Next;
            fast = fast.Next;
        }
        return slow.Data;
    }
    //////////////////////////////////////////////////////////////////  merging method

    public LinkedList ZipLists(LinkedList list2)
    {
        LinkedList mergedList = new LinkedList();
        Node current1 = head;
        Node current2 = list2.head;

        while (current1 != null || current2 != null)
        {
            if (current1 != null)
            {
                mergedList.Append(current1.Data);
                current1 = current1.Next;
            }
            if (current2 != null)
            {
                mergedList.Append(current2.Data);
                current2 = current2.Next;
            }
        }
        return mergedList;
    }
}
    /////////////////////////////////////////////////////////////////

/// ////////////////////////////////////////////////////  stack and queue:
public class Stack
{
    private Node top;

    public Stack()
    {
        top = null;
    }

    public void Push(int value)
    {
        Node newNode = new Node(value);
        newNode.Next = top;
        top = newNode;
    }

    public int Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("the stack is empty...");

        int value = top.Data;
        top = top.Next;
        return value;
    }

    public int Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("the stack is empty...");

        return top.Data;
    }

    public bool IsEmpty()
    {
        return top == null;
    }
}

public class Queue
{
    private Node front;
    private Node rear;

    public Queue()
    {
        front = null;
        rear = null;
    }

    public void Enqueue(int value)
    {
        Node newNode = new Node(value);

        if (IsEmpty())
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
    }

    public int Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("the queue is empty...");

        int value = front.Data;
        front = front.Next;

        if (front == null)
            rear = null;

        return value;
    }

    public int Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("the queue is empty...");

        return front.Data;
    }

    public bool IsEmpty()
    {
        return front == null;
    }
}

    /////////////////////////////////////////////////////////////////