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

        /////////////////////////////////////

        Console.WriteLine();

        PseudoQueue pseudoQueue = new PseudoQueue();

        pseudoQueue.Enqueue(1);
        pseudoQueue.Enqueue(2);
        pseudoQueue.Enqueue(3);
        pseudoQueue.Enqueue(4);
        pseudoQueue.Enqueue(5);

        Console.WriteLine(pseudoQueue.Dequeue());

        Console.WriteLine(pseudoQueue.Dequeue());

        Console.WriteLine(pseudoQueue.Dequeue());

        ///////////////////////////////////////////////
        
        Console.WriteLine();
        Console.WriteLine();

        Shelter Shelter = new Shelter();
        Shelter.Enqueue(new Animal("cat", "cat1"));
        Shelter.Enqueue(new Animal("dog", "dog1"));
        Shelter.Enqueue(new Animal("dog", "dog2"));

        Console.WriteLine(Shelter.Dequeue("dog").Name);
        Console.WriteLine(Shelter.Dequeue("dog").Name);
        // Console.WriteLine(Shelter.Dequeue("cat").Name);
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

class PseudoQueue
{
    private Stack stack1;
    private Stack stack2;

    public PseudoQueue()
    {
        stack1 = new Stack();
        stack2 = new Stack();
    }

    public void Enqueue(int value)
    {
        while (!stack2.IsEmpty())
        {
            stack1.Push(stack2.Pop());
        }
        stack1.Push(value);
    }

    public int Dequeue()
    {
        while (!stack1.IsEmpty())
        {
            stack2.Push(stack1.Pop());
        }
        return stack2.Pop();
    }


    //public void Enqueue(int value)
    //{
    //    stack1.Push(value);
    //}

    //public int Dequeue()
    //{
    //    if (IsEmpty())
    //    {
    //        throw new InvalidOperationException("The queue is empty...");
    //    }

    //    if (stack2.IsEmpty())
    //    {
    //        while (!stack1.IsEmpty())
    //        {
    //            stack2.Push(stack1.Pop());
    //        }
    //    }

    //    return stack2.Pop();
    //}

    //public int Peek()
    //{
    //    if (IsEmpty())
    //    {
    //        throw new InvalidOperationException("The queue is empty...");
    //    }

    //    if (stack2.IsEmpty())
    //    {
    //        while (!stack1.IsEmpty())
    //        {
    //            stack2.Push(stack1.Pop());
    //        }
    //    }

    //    return stack2.Peek();
    //}

    //public bool IsEmpty()
    //{
    //    return stack1.IsEmpty() && stack2.IsEmpty();
    //}
}


////////////////////////////////////////////////////////////////// animal shelter
///

public class Animal
{
    public string Species { get; set; }
    public string Name { get; set; }

    public Animal(string species, string name)
    {
        Species = species;
        Name = name;
    }
}

public class Shelter
{
    private List<Animal> animals;

    public Shelter()
    {
        animals = new List<Animal>();
    }

    public void Enqueue(Animal animal)
    {
        animals.Add(animal);
    }

    public Animal Dequeue(string pref) // this pref argument can be either cat or dog
    {
        foreach (Animal animal in animals)
        {
            if (animal.Species == pref)
            {
                animals.Remove(animal);
                return animal;
            }
        }
        return null;
    }
}
