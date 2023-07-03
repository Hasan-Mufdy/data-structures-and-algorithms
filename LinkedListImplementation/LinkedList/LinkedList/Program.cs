﻿using System.Collections.Generic;
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

}