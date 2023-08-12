namespace TestProject1
{
    public class UnitTest1
    {

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


        [Fact]
        public void SumOddNodes_ShouldReturn_CorrectSum()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Add(5);
            bst.Add(3);
            bst.Add(2);
            bst.Add(4);
            bst.Add(9);

            int oddSum = bst.SumOddNodes();

            int expectedSum = 5 + 3 + 9;
            Assert.Equal(expectedSum, oddSum);
        }



        //[Fact]
        //public void CanInstantiateEmptyTree()
        //{
        //    BinaryTree<int> binaryTree = new BinaryTree<int>();
        //    Assert.Null(binaryTree.Root);
        //}

        //[Fact]
        //public void CanInstantiateTreeWithSingleRootNode()
        //{
        //    BinaryTree<int> binaryTree = new BinaryTree<int>();
        //    binaryTree.Root = new Node<int>(10);
        //    Assert.NotNull(binaryTree.Root);
        //    Assert.Equal(10, binaryTree.Root.Value);
        //}

        //[Fact]
        //public void CanAddLeftAndRightChildToBinarySearchTree()
        //{
        //    BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
        //    binarySearchTree.Add(5);
        //    binarySearchTree.Add(3);
        //    binarySearchTree.Add(7);

        //    Assert.NotNull(binarySearchTree.Root);
        //    Assert.Equal(5, binarySearchTree.Root.Value);

        //    Assert.NotNull(binarySearchTree.Root.Left);
        //    Assert.Equal(3, binarySearchTree.Root.Left.Value);

        //    Assert.NotNull(binarySearchTree.Root.Right);
        //    Assert.Equal(7, binarySearchTree.Root.Right.Value);
        //}

        //[Fact]
        //public void CanReturnInOrderTraversalCollection()
        //{
        //    BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
        //    binarySearchTree.Add(5);
        //    binarySearchTree.Add(3);
        //    binarySearchTree.Add(7);
        //    binarySearchTree.Add(2);
        //    binarySearchTree.Add(4);
        //    binarySearchTree.Add(6);
        //    binarySearchTree.Add(8);

        //    List<int> expectedInOrder = new List<int> { 2, 3, 4, 5, 6, 7, 8 };
        //    List<int> actualInOrder = binarySearchTree.InOrderTraversal();

        //    Assert.Equal(expectedInOrder, actualInOrder);
        //}

        //[Fact]
        //public void CanReturnPostOrderTraversalCollection()
        //{
        //    BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
        //    binarySearchTree.Add(50);
        //    binarySearchTree.Add(30);
        //    binarySearchTree.Add(70);
        //    binarySearchTree.Add(20);
        //    binarySearchTree.Add(40);
        //    binarySearchTree.Add(60);
        //    binarySearchTree.Add(80);

        //    List<int> expectedPostOrder = new List<int> { 20, 40, 30, 60, 80, 70, 50 };
        //    List<int> actualPostOrder = binarySearchTree.PostOrderTraversal();

        //    Assert.Equal(expectedPostOrder, actualPostOrder);
        //}

        //[Fact]
        //public void CanCheckIfValueExistsInBinarySearchTree()
        //{
        //    BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
        //    binarySearchTree.Add(5);
        //    binarySearchTree.Add(3);
        //    binarySearchTree.Add(7);
        //    binarySearchTree.Add(2);
        //    binarySearchTree.Add(4);
        //    binarySearchTree.Add(6);
        //    binarySearchTree.Add(8);

        //    Assert.True(binarySearchTree.Contains(5));
        //    Assert.True(binarySearchTree.Contains(2));
        //    Assert.True(binarySearchTree.Contains(8));
        //    Assert.False(binarySearchTree.Contains(1));
        //    Assert.False(binarySearchTree.Contains(10));
        //}

        ///////////////////////////////////////////////////

        //[Fact]
        //public void MaximumValue_OneNodeTree_ShouldReturnSingleNodeValue()
        //{
        //    BinaryTree<int> tree = new BinaryTree<int>();
        //    tree.Root = new Node<int>(42);

        //    int max = tree.MaximumValue();

        //    Assert.Equal(42, max);
        //}

        //[Fact]
        //public void MaximumValue_MultipleNodes_ShouldReturnMaximumValue()
        //{
        //    BinaryTree<int> tree = new BinaryTree<int>();
        //    tree.Root = new Node<int>(10);
        //    tree.Root.Left = new Node<int>(5);
        //    tree.Root.Right = new Node<int>(15);
        //    tree.Root.Left.Left = new Node<int>(3);
        //    tree.Root.Left.Right = new Node<int>(8);
        //    tree.Root.Right.Right = new Node<int>(20);

        //    int max = tree.MaximumValue();

        //    Assert.Equal(20, max);
        //}


    }
}