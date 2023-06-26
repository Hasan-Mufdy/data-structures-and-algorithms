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