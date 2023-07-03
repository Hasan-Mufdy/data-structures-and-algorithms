# Linked List KTH

### problem domain

Write a method in the LinkedList class that was created previously, that finds the k-th value from the end of a linked list.

### test cases

1. k is greater than the length of the linked list
2. k and the length of the list are the same
3. k is not a positive integer
4. the linked list is of a size 1
5. “Happy Path” where k is not at the end, but somewhere in the middle of the linked list
 

### algorithm

check if the list is empty, then create two new pointers (fast and slow), both pointing to the head.
then move "fast" k points ahead, note: if it reaches an empty node (null), then then an exception will be thrown.
after that, both slow and fast poiters will be moved together until fast reaches the end.
now the slow will point at the value that is k steps from the end, and the value will be returned.

### big O

time complexity for this kth method in this app is O(n), because there is a loop, and it depends on the size of the linked list.

### code
```
public int kthFromTheEnd(int k)
    {
        // no need to use it because it is not empty now.
        //if (head == null)
        //{
        //    throw new InvalidOperationException("the list is empty, add elements to the list...");
        //}

        Node slow = head;
        Node fast = head;

        for (int i = 0; i < k; i++)
        {
            if (fast == null)
            {
                throw new ArgumentOutOfRangeException("k");
            }
            fast = fast.Next;
        }

        while (fast != null)
        {
            slow = slow.Next;
            fast = fast.Next;
        }
        return slow.Data;
    }
```

### unit tests
```
[Fact]
        public void kthFromTheEnd_KGreaterThanLength_ThrowsException()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(5);
            myList.AddToTheLast(10);
            myList.AddToTheLast(15);

            // assert with the exception:
            Assert.Throws<ArgumentOutOfRangeException>(() => myList.kthFromTheEnd(4));
        }

        [Fact]
        public void kthFromTheEnd_KEquals_Length_ReturnsLastValue()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(5);
            myList.AddToTheLast(10);
            myList.AddToTheLast(15);

            int result = myList.kthFromTheEnd(3);

            Assert.Equal(5, result);
        }

        [Fact]
        public void kthFromTheEnd_KNegative_ThrowsException()
        {
            LinkedList myList = new LinkedList();
            myList.AddToTheLast(5);
            myList.AddToTheLast(10);
            myList.AddToTheLast(15);

            Assert.Throws<NullReferenceException>(() => myList.kthFromTheEnd(-1));
        }

        [Fact]
        public void kthFromTheEnd_OneNodeList_ReturnsValue()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(5);

            int result = myList.kthFromTheEnd(1);

            Assert.Equal(5, result);
        }
        [Fact]
        public void kthFromTheEnd_KInTheMiddle_ReturnsValue()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(5);
            myList.AddToTheLast(10);
            myList.AddToTheLast(15);
            myList.AddToTheLast(20);

            int result = myList.kthFromTheEnd(3);

            Assert.Equal(10, result);
        }
```


### white board screenshot

![white board image](/assets/linkedlist.jpg)
