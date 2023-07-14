# Stacks And Queues

this is an implementation for Stack and a Queue using a Linked List as the underlying data storage mechanism.

- note: this repo contains 2 visual studio projects for the implementation:
1. in the LinkedListImplementation directory.
2. and in the stack-queue-implementation directory.

### This implementation has three classes:
- Node
- Stack
- Queue

stack class represents LIFO (last in first out) approach.
stack methods:


and the queue represents FIFO (first in first out).

## Whiteboard Process:

![stack and queue whiteboard](/assets/stackqueue.jpg)

## big O:
all the methods in this app have a time complexity of o(1), they all take constant time to execute.

### Code:
```
using System;

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
```

### Unit tests:
```
namespace StackQueueTest
{
    public class UnitTest1
    {
        [Fact]
        public void Check_PushingOntoStack()
        {
            Stack stack = new Stack();
            stack.Push(1);

            Assert.False(stack.IsEmpty());
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void Check_PushingMultipleValuesOntoStack()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.False(stack.IsEmpty());
            Assert.Equal(3, stack.Peek());
        }

        [Fact]
        public void Check_PopingOffStack()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);

            int result = stack.Pop();

            Assert.Equal(2, result);
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void Check_EmptyingStackAfterMultiplePops()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Check_PeekingNextItemOnTheStack()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);

            int result = stack.Peek();

            Assert.Equal(2, result);
            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void Check_InstantiatingEmptyStack()
        {
            Stack stack = new Stack();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Check_When_Empty_Exception()
        {
            Stack stack = new Stack();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Check_EnqueuingIntoQueue()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);

            Assert.False(queue.IsEmpty());
            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void Check_EnqueuingMultipleValuesIntoQueue()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.False(queue.IsEmpty());
            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void Check_DequeuingOutOfQueueTheExpectedValue()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);

            int result = queue.Dequeue();

            Assert.Equal(1, result);
            Assert.Equal(2, queue.Peek());
        }

        [Fact]
        public void Check_PeekingIntoQueueSeeingTheExpectedValue()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);

            int result = queue.Peek();

            Assert.Equal(1, result);
            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void Check_EmptyingQueueAfterMultipleDequeues()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Dequeue();

            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Check_InstantiatingEmptyQueue()
        {
            Queue queue = new Queue();

            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Check_If_Queue_Is_Empty_Exception()
        {
            Queue queue = new Queue();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
    }
}
```
