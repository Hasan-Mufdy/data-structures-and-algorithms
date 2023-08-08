# tree-fizz-buzz
Conduct “FizzBuzz” on a k-ary tree while traversing through it to create a new tree.

Set the values of each of the new nodes depending on the corresponding node value in the source tree

## Whiteboard Process
![whiteboard](/assets/fizz-buzz-tree.jpg)

## Approach & Efficiency
time complexity of this implementation is O(n), where n is the number of nodes, and the performance will be depending on the number of total nodes.

## Solution
#### Code:
```
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
```

