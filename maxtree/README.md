# Tree-Max

Find the Maximum Value in a Binary Tree

- note: the implementation is inside TreeImplementation folder

## Whiteboard Process

## Approach & Efficiency
time complexity for the method is O(n), because In the worst-case scenario, the method needs to visit all the nodes in the binary tree to find the maximum value.

## Solution
code:
```
public T MaximumValue()
    {
        T max = default(T);

        Action<Node<T>> inOrderTraversal = null;
        inOrderTraversal = (node) =>
        {
            if (node != null)
            {
                inOrderTraversal(node.Left);
                if (Comparer<T>.Default.Compare(node.Value, max) > 0)
                {
                    max = node.Value;
                }
                inOrderTraversal(node.Right);
            }
        };
        inOrderTraversal(Root);
        return max;
    }
```

unit tests:
```
[Fact]
        public void MaximumValue_OneNodeTree_ShouldReturnSingleNodeValue()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new Node<int>(42);

            int max = tree.MaximumValue();

            Assert.Equal(42, max);
        }

        [Fact]
        public void MaximumValue_MultipleNodes_ShouldReturnMaximumValue()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new Node<int>(10);
            tree.Root.Left = new Node<int>(5);
            tree.Root.Right = new Node<int>(15);
            tree.Root.Left.Left = new Node<int>(3);
            tree.Root.Left.Right = new Node<int>(8);
            tree.Root.Right.Right = new Node<int>(20);

            int max = tree.MaximumValue();

            Assert.Equal(20, max);
        }
```
