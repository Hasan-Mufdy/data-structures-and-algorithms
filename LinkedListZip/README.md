# Linked List Zip Merge

### problem domain

Write a function called zip lists
Arguments: 2 linked lists
Return: New Linked List, zipped as noted below
Zip the two linked lists together into one so that the nodes alternate between the two lists and return a reference to the the zipped list.
Try and keep additional space down to O(1)
You have access to the Node class and all the properties on the Linked List class as well as the methods created in previous challenges.

### test cases

1. both of the lists are empty
2. one list is bigger than the other
3. both of the lists are the same size (normal case)


### algorithm
- implement ziplists method
- it takes a ziplist as an argument
- creates a new empty linked list, which will be the merged list
- define 2 nodes that act as a pointer in the lists
- the data from the first and the second list will be merged
- append the first element in the first list, then the first element from the second list and so on
- the new list will be returned

### big O

time complexity of ziplists method will be O(n), however, space complexity will be O(1).

### code
```
public LinkedList ZipLists(LinkedList list2)
    {
        LinkedList mergedList = new LinkedList();
        Node current1 = head;
        Node current2 = list2.head;

        while (current1 != null || current2 != null)
        {
            if (current1 != null)
            {
                mergedList.Append(current1.Data);
                current1 = current1.Next;
            }
            if (current2 != null)
            {
                mergedList.Append(current2.Data);
                current2 = current2.Next;
            }
        }
        return mergedList;
    }
```


### unit tests
```

        [Fact]
        public void If_Both_Lists_Are_Empty()
        {
            LinkedList myList1 = new LinkedList();
            LinkedList myList2 = new LinkedList();

            LinkedList mergedList = myList1.ZipLists(myList2);

            Assert.Null(mergedList.head);
            Assert.Null(mergedList.tail);
            Assert.Equal(string.Empty, mergedList.ToString());
        }

        [Fact]
        public void check_If_The_2_Lists_Are_Merged()
        {
            LinkedList list1 = new LinkedList();
            list1.AddToTheLast(1);
            list1.AddToTheLast(2);
            LinkedList list2 = new LinkedList();
            list2.AddToTheLast(3);
            list2.AddToTheLast(4);

            LinkedList mergedList = list1.ZipLists(list2);

            Assert.Equal("{1}{3}{2}{4}", mergedList.ToString());
        }
```
### white board screenshot

![white board image](/assets/ziplistswb.jpg)
