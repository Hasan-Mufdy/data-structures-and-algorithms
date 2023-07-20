namespace StackQueueTest
{
    public class UnitTest1
    {
        [Fact]
        public void Check_PushingOntoStack()
        {
            Stack stack = new Stack();
            stack.Push(1);

            Assert.False(stack.IsEmpty());
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void Check_PushingMultipleValuesOntoStack()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.False(stack.IsEmpty());
            Assert.Equal(3, stack.Peek());
        }

        [Fact]
        public void Check_PopingOffStack()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);

            int result = stack.Pop();

            Assert.Equal(2, result);
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void Check_EmptyingStackAfterMultiplePops()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Check_PeekingNextItemOnTheStack()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);

            int result = stack.Peek();

            Assert.Equal(2, result);
            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void Check_InstantiatingEmptyStack()
        {
            Stack stack = new Stack();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Check_When_Empty_Exception()
        {
            Stack stack = new Stack();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Check_EnqueuingIntoQueue()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);

            Assert.False(queue.IsEmpty());
            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void Check_EnqueuingMultipleValuesIntoQueue()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.False(queue.IsEmpty());
            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void Check_DequeuingOutOfQueueTheExpectedValue()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);

            int result = queue.Dequeue();

            Assert.Equal(1, result);
            Assert.Equal(2, queue.Peek());
        }

        [Fact]
        public void Check_PeekingIntoQueueSeeingTheExpectedValue()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);

            int result = queue.Peek();

            Assert.Equal(1, result);
            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void Check_EmptyingQueueAfterMultipleDequeues()
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Dequeue();

            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Check_InstantiatingEmptyQueue()
        {
            Queue queue = new Queue();

            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void Check_If_Queue_Is_Empty_Exception()
        {
            Queue queue = new Queue();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        //////// animal shelter methods test:
        ///
        [Fact]
        public void Check_If_Dequeue_ReturnAnimal()
        {
            Shelter shelter = new Shelter();
            Animal dog = new Animal("dog", "dog1");
            Animal cat = new Animal("cat", "cat1");

            shelter.Enqueue(dog);
            shelter.Enqueue(cat);

            Animal dequeuedDog = shelter.Dequeue("dog");
            Animal dequeuedCat = shelter.Dequeue("cat");

            Assert.Equal(dog, dequeuedDog);
            Assert.Equal(cat, dequeuedCat);
            
        }

        [Fact]
        public void check_If_Dequeue_ReturnNull_When_there_Is_No_Match()
        {
            Shelter shelter = new Shelter();
            Animal cat = new Animal("cat", "cat1");
            shelter.Enqueue(cat);

            Animal dequeuedDog = shelter.Dequeue("dog");

            Assert.Null(dequeuedDog);
        }
        //////////////////////////////////////////////////////////// tests for PseudoQueue methods:

        [Fact]
        public void Enqueue_Add_Items_To_Queue()
        {
            PseudoQueue pseudoQueue = new PseudoQueue();

            pseudoQueue.Enqueue(1);
            pseudoQueue.Enqueue(2);
            pseudoQueue.Enqueue(3);

            Assert.Equal(1, pseudoQueue.Dequeue());
            Assert.Equal(2, pseudoQueue.Dequeue());
            Assert.Equal(3, pseudoQueue.Dequeue());
        }

        [Fact]
        public void Throw_Exception_If_Empty()
        {
            PseudoQueue pseudoQueue = new PseudoQueue();

            // (pseudoQueue is empty)

            Assert.Throws<InvalidOperationException>(() => pseudoQueue.Dequeue());
        }
    }
}