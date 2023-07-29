using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();

        binarySearchTree.Add(5);
        binarySearchTree.Add(3);
        binarySearchTree.Add(7);
        binarySearchTree.Add(2);
        binarySearchTree.Add(4);
        binarySearchTree.Add(6);
        binarySearchTree.Add(8);

        Console.WriteLine("Pre-Order Traversal");
        string resultString = string.Join(",", binarySearchTree.PreOrderTraversal());
        Console.WriteLine(resultString);

        Console.WriteLine("In-order Traversal");
        Console.WriteLine(string.Join(", ", binarySearchTree.InOrderTraversal()));

        Console.WriteLine("Post-order Traversal");
        Console.WriteLine(string.Join(", ", binarySearchTree.PostOrderTraversal()));
    }
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }

    public Node(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinaryTree<T>
{
    public Node<T> Root;

    public BinaryTree()
    {
        Root = null;
    }

    public List<T> PreOrderTraversal()
    {
        List<T> result = new List<T>();
        PreOrderTraversal(Root, result);
        return result;
    }

    private void PreOrderTraversal(Node<T> node, List<T> result)
    {
        if (node != null)
        {
            result.Add(node.Value);
            PreOrderTraversal(node.Left, result);
            PreOrderTraversal(node.Right, result);
        }
    }
    public List<T> InOrderTraversal()
    {
        List<T> result = new List<T>();
        InOrderTraversal(Root, result);
        return result;
    }

    private void InOrderTraversal(Node<T> node, List<T> result)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, result);
            result.Add(node.Value);
            InOrderTraversal(node.Right, result);
        }
    }
    public List<T> PostOrderTraversal()
    {
        List<T> result = new List<T>();
        PostOrderTraversal(Root, result);
        return result;
    }

    private void PostOrderTraversal(Node<T> node, List<T> result)
    {
        if (node != null)
        {
            PostOrderTraversal(node.Left, result);
            PostOrderTraversal(node.Right, result);
            result.Add(node.Value);
        }
    }
}

public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
{
    public void Add(T value)
    {
        Root = AddNode(Root, value);
    }

    private Node<T> AddNode(Node<T> node, T value)
    {
        if (node == null)
            return new Node<T>(value);

        if (value.CompareTo(node.Value) < 0)
            node.Left = AddNode(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = AddNode(node.Right, value);

        return node;
    }

    public bool Contains(T value)
    {
        return SearchNode(Root, value) != null;
    }

    private Node<T> SearchNode(Node<T> node, T value)
    {
        if (node == null || value.CompareTo(node.Value) == 0)
            return node;

        if (value.CompareTo(node.Value) < 0)
            return SearchNode(node.Left, value);
        else
            return SearchNode(node.Right, value);
    }
}