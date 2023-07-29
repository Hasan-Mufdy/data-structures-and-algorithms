namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CanInstantiateEmptyTree()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            Assert.Null(binaryTree.Root);
        }

        [Fact]
        public void CanInstantiateTreeWithSingleRootNode()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Root = new Node<int>(10);
            Assert.NotNull(binaryTree.Root);
            Assert.Equal(10, binaryTree.Root.Value);
        }

        [Fact]
        public void CanAddLeftAndRightChildToBinarySearchTree()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(5);
            binarySearchTree.Add(3);
            binarySearchTree.Add(7);

            Assert.NotNull(binarySearchTree.Root);
            Assert.Equal(5, binarySearchTree.Root.Value);

            Assert.NotNull(binarySearchTree.Root.Left);
            Assert.Equal(3, binarySearchTree.Root.Left.Value);

            Assert.NotNull(binarySearchTree.Root.Right);
            Assert.Equal(7, binarySearchTree.Root.Right.Value);
        }

        [Fact]
        public void CanReturnInOrderTraversalCollection()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(5);
            binarySearchTree.Add(3);
            binarySearchTree.Add(7);
            binarySearchTree.Add(2);
            binarySearchTree.Add(4);
            binarySearchTree.Add(6);
            binarySearchTree.Add(8);

            List<int> expectedInOrder = new List<int> { 2, 3, 4, 5, 6, 7, 8 };
            List<int> actualInOrder = binarySearchTree.InOrderTraversal();

            Assert.Equal(expectedInOrder, actualInOrder);
        }

        [Fact]
        public void CanReturnPostOrderTraversalCollection()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(50);
            binarySearchTree.Add(30);
            binarySearchTree.Add(70);
            binarySearchTree.Add(20);
            binarySearchTree.Add(40);
            binarySearchTree.Add(60);
            binarySearchTree.Add(80);

            List<int> expectedPostOrder = new List<int> { 20, 40, 30, 60, 80, 70, 50 };
            List<int> actualPostOrder = binarySearchTree.PostOrderTraversal();

            Assert.Equal(expectedPostOrder, actualPostOrder);
        }

        [Fact]
        public void CanCheckIfValueExistsInBinarySearchTree()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(5);
            binarySearchTree.Add(3);
            binarySearchTree.Add(7);
            binarySearchTree.Add(2);
            binarySearchTree.Add(4);
            binarySearchTree.Add(6);
            binarySearchTree.Add(8);

            Assert.True(binarySearchTree.Contains(5));
            Assert.True(binarySearchTree.Contains(2));
            Assert.True(binarySearchTree.Contains(8));
            Assert.False(binarySearchTree.Contains(1));
            Assert.False(binarySearchTree.Contains(10));
        }
    }
}