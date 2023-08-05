# Breadth-first Traversal.

## Whiteboard Process
![whiteboard](/assets/BFS.jpg)


## Approach & Efficiency
time complexity for this method is O(n), because each node is visited once, and the time it will take depends on the size of the tree.


## Solution
code:
```
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
```

unit tests:
```
 [Fact]
        public void BFS_Method_test()
        {


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

            List<int> result = binaryTree.BFS(binaryTree.Root);


            List<int> expected = new List<int> { 2, 7, 5, 2, 6, 9, 5, 11, 4 };
            Assert.Equal(expected, result);
        }

```
