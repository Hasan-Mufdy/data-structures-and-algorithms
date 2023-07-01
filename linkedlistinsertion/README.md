### problem domain
adding new features to the existing linked list implementation.
features:
- append
arguments: new value
adds a new node with the given value to the end of the list
- insert before
arguments: value, new value
adds a new node with the given new value immediately before the first node that has the value specified
- insert after
arguments: value, new value
adds a new node with the given new value immediately after the first node that has the value specified

### test cases
Can successfully add a node to the end of the linked list
Can successfully add multiple nodes to the end of a linked list
Can successfully insert a node before a node located i the middle of a linked list
Can successfully insert a node before the first node of a linked list
Can successfully insert after a node in the middle of the linked list
Can successfully insert a node after the last node of the linked list

### algorithm
- Create a new instance of the LinkedList.
- we have 2 new features:
1. insert after:
- define a newNode variable
- check if the linked list has values
- check the value index
- append the newValue after the inputted value
- if the new value is added after the last node, assign it to the tail.
- 1. insert before:
- define a newNode variable
- check if the linked list has values
- check the value index
- append the newValue before the inputted value
- if the new value is added before the last node, assign it to the head.

### big O
time complexity for both of the methods InsertAfter and InsertBefore is O(n), and adding a value to the linked list is O(1) because it does not depend on the size of the array and it will execute instantly.

### code
```
public void InsertAfter(int value, int newValue)
    {
        Node newNode = new Node(newValue);

        if (head == null)
        {
            return;
        }
        Node current = head;
        while (current != null)
        {
            if (current.Data == value)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                if (current == tail)
                {
                    tail = newNode; // in case of inserting at the last node
                }
                return;
            }
            current = current.Next;
        }
    }

    public void InsertBefore(int value, int newValue)
    {
        Node newNode = new Node(newValue);

        if (head == null)
        {
            return;
        }

        if (head.Data == value)
        {
            newNode.Next = head;
            head = newNode;
            return;
        }
        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Data == value)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                return;
            }
            current = current.Next;
        }
    }
public void AddToTheLast(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {

            tail.Next = newNode;

            tail = newNode;
        }
    }
```

### unit tests
```
        [Fact]
        public void Return_AllValuesInLinkedList()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTheLast(5);
            linkedList.AddToTheLast(10);
            linkedList.AddToTheLast(15);
            string expected = "{5}{10}{15}";
            string result = linkedList.ToString();
            Assert.Equal(expected, result);
        }
        [Fact]
        public void AddMultipleNodesToTheEnd()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTheLast(1);
            linkedList.AddToTheLast(2);
            linkedList.AddToTheLast(3);
            string expected = "{1}{2}{3}";
            string result = linkedList.ToString();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void InsertNodeBeforeTheMiddleNode()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(1);
            myList.AddToTheLast(2);
            myList.AddToTheLast(3);

            myList.InsertBefore(2, 10); ///////

            Assert.Equal("{1}{10}{2}{3}", myList.ToString());
        }
        [Fact]



        public void InsertNodeBeforeTheFirstNode()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(1);
            myList.AddToTheLast(2);
            myList.AddToTheLast(3);

            myList.InsertBefore(1, 10);

            Assert.Equal("{10}{1}{2}{3}", myList.ToString());
        }
        [Fact]
        public void InsertNodeAfterTheMiddleNode()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(1);
            myList.AddToTheLast(2);
            myList.AddToTheLast(3);

            myList.InsertAfter(2, 10);

            Assert.Equal("{1}{2}{10}{3}", myList.ToString());
        }

        [Fact]
        public void InsertNodeAfterTheLastNode()
        {
            LinkedList myList = new LinkedList();

            myList.AddToTheLast(1);
            myList.AddToTheLast(2);
            myList.AddToTheLast(3);

            myList.InsertAfter(3, 10);

            Assert.Equal("{1}{2}{3}{10}", myList.ToString());
        }
```


### white board screenshot

![white board image](/assets/linkedlistinsertionWB.jpg)