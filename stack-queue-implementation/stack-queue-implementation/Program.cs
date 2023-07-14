﻿using System;

public class Program
{
    public static void Main(string[] args)
    {
        Stack stack = new Stack();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);


        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Peek());
        Console.WriteLine(stack.IsEmpty());

        ////////////////////////////////////
        Queue queue = new Queue();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);


        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Peek());
        Console.WriteLine(queue.IsEmpty());


    }
}

public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int value)
    {
        Data = value;
        Next = null;
    }
}

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