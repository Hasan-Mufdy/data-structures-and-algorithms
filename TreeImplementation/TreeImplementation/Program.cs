using System;
using System.Collections.Generic;
using System.Xml.Linq;

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

        //////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("maximum value in the tree is: " + binarySearchTree.MaximumValue());

        //////////////////////////////////////////////////////////////////////////////// breadth-search
        ///

        BinaryTree<int> binaryTree = new BinaryTree<int>();
        binaryTree.Add(2);
        binaryTree.Add(7);
        binaryTree.Add(5);
        binaryTree.Add(2);
        binaryTree.Add(6);
        binaryTree.Add(9);
        binaryTree.Add(5);
        binaryTree.Add(11);
        binaryTree.Add(4);
        Console.WriteLine("Breadth-First Traversal: " + string.Join(" ", binaryTree.BFS(binaryTree.Root)));


        Console.WriteLine("breadth-search traversal:");



        List<int> breadthFirstResult = binaryTree.BFS(binaryTree.Root);
        Console.WriteLine("BreadthFirst Traversal, in binaryTree variable: ");
        Console.WriteLine(string.Join(" - ", breadthFirstResult));
        //////////////////////////////////////////////////////////////////////////////////  max value:

        Console.WriteLine("maximum value in the tree is: " + binaryTree.MaximumValue());

        //////////////////////////////////////////////////////////////////////////////////////////////
        ///
        Console.WriteLine("tree-fizz-buzz:");


        BinaryTree<string> fizzBuzzTree = binaryTree.FizzBuzzTree();

        Console.WriteLine("FizzBuzz Tree: " + string.Join(" - ", fizzBuzzTree.BFS(fizzBuzzTree.Root)));
        //////////////////////////////////////////////////////////////////////////////////////////////
        // sum of odd numbers:
        Console.WriteLine("the sum of odd numbers in the binarySearchTree var: ");
        int oddSum = binarySearchTree.SumOddNodes();
        Console.WriteLine("result: " + oddSum);
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


    ///////////////////////////////////////////////////////////////////////////////////////
    ///
    ///sum of odd numbers in a tree:   the first way(using binary tree)
    ///
    //public void Insert(T value)
    //{
    //    Root = InsertN(Root, value);
    //}

    //public Node<T> InsertN(Node<T> root, T value)
    //{
    //    if (root == null)
    //    {
    //        root = new Node<T>(value);
    //        return root;
    //    }

    //    int comparison = Comparer<T>.Default.Compare(value, root.Value);

    //    if (comparison < 0)
    //        root.Left = InsertN(root.Left, value);
    //    else if (comparison > 0)
    //        root.Right = InsertN(root.Right, value);

    //    return root;
    //}

    //public int SumOddNodes()
    //{
    //    return SumOddNodesRec(Root);
    //}

    //private int SumOddNodesRec(Node<T> root)
    //{
    //    if (root == null)
    //        return 0;

    //    int sum = SumOddNodesRec(root.Left);

    //    int intValue = Convert.ToInt32(root.Value);
    //    if (intValue % 2 != 0)
    //        sum += intValue;

    //    sum += SumOddNodesRec(root.Right);

    //    return sum;
    //}
    /// ///////////////////////////////////////////////////////////////////////////////////

    public BinaryTree<string> FizzBuzzTree()
    {
        BinaryTree<string> fizzBuzzTree = new BinaryTree<string>();

        if (Root == null)
        {
            return fizzBuzzTree;
        }

        Queue<Node<T>> originalNodes = new Queue<Node<T>>();
        Queue<Node<string>> fizzBuzzNodes = new Queue<Node<string>>();

        originalNodes.Enqueue(Root);
        fizzBuzzNodes.Enqueue(new Node<string>(FizzBuzzValue(Root.Value)));

        fizzBuzzTree.Root = fizzBuzzNodes.Peek();

        while (originalNodes.Count > 0)
        {
            Node<T> originalNode = originalNodes.Dequeue();
            Node<string> fizzBuzzNode = fizzBuzzNodes.Dequeue();

            if (originalNode.Left != null)
            {
                originalNodes.Enqueue(originalNode.Left);
                fizzBuzzNode.Left = new Node<string>(FizzBuzzValue(originalNode.Left.Value));
                fizzBuzzNodes.Enqueue(fizzBuzzNode.Left);
            }

            if (originalNode.Right != null)
            {
                originalNodes.Enqueue(originalNode.Right);
                fizzBuzzNode.Right = new Node<string>(FizzBuzzValue(originalNode.Right.Value));
                fizzBuzzNodes.Enqueue(fizzBuzzNode.Right);
            }
        }

        return fizzBuzzTree;
    }

    private string FizzBuzzValue(dynamic value)
    {
        if (value % 3 == 0 && value % 5 == 0)
        {
            return "FizzBuzz";
        }
        else if (value % 3 == 0)
        {
            return "Fizz";
        }
        else if (value % 5 == 0)
        {
            return "Buzz";
        }
        else
        {
            return value.ToString();
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////


    //public T MaximumValue()
    //{
    //    T max = default(T);

    //    Action<Node<T>> inOrderTraversal = null;
    //    inOrderTraversal = (node) =>
    //    {
    //        if (node != null)
    //        {
    //            inOrderTraversal(node.Left);
    //            if (Comparer<T>.Default.Compare(node.Value, max) > 0)
    //            {
    //                max = node.Value;
    //            }
    //            inOrderTraversal(node.Right);
    //        }
    //    };
    //    inOrderTraversal(Root);
    //    return max;
    //}

    //// the second solution:(not using BinarySearchTree)
    public T MaximumValue()
    {
        T max = default(T);

        Queue<Node<T>> queue = new Queue<Node<T>>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            Node<T> currentNode = queue.Dequeue();

            if (Comparer<T>.Default.Compare(currentNode.Value, max) > 0)
            {
                max = currentNode.Value;
            }

            if (currentNode.Left != null)
            {
                queue.Enqueue(currentNode.Left);
            }

            if (currentNode.Right != null)
            {
                queue.Enqueue(currentNode.Right);
            }
        }
        return max;
    }


    ////////////////////////////////////////////////////////////////////////////////////////

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
    //////////////////////////////////////////////////////////////////
    ///

   public List<T> BFS(Node<T> root)
    {
        Queue<Node<T>> queue = new Queue<Node<T>>();
        List<T> results = new List<T>();
        if (root == null) return results;
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            Node<T> newNode = queue.Dequeue();
            results.Add(newNode.Value);
            if (newNode.Left != null)
            {
                queue.Enqueue(newNode.Left);
            }
            if (newNode.Right != null)
            {
                queue.Enqueue(newNode.Right);
            }
        }
        return results;
    }

    public void Add(T value)
    {
        Root = AddRecursive(Root, value);
    }

    private Node<T> AddRecursive(Node<T> current, T value)
    {
        if (current == null)
        {
            return new Node<T>(value);
        }

        if (current.Left == null)
        {
            current.Left = new Node<T>(value);
        }
        else if (current.Right == null)
        {
            current.Right = new Node<T>(value);
        }
        else
        {
            current.Left = AddRecursive(current.Left, value);
        }

        return current;
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
    //////////////////////////////////////////////////////////
    ///
    public int SumOddNodes()
    {
        return SumOddNodesN(Root);
    }
    private int SumOddNodesN(Node<T> root)
    {
        if (root == null)
            return 0;

        int sum = SumOddNodesN(root.Left);

        // check if odd to add
        int intValue = Convert.ToInt32(root.Value);
        if (intValue % 2 != 0)
            sum += intValue;

        sum += SumOddNodesN(root.Right);

        return sum;
    }
    //////////////////////////////////////////////////////

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