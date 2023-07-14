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
    }
}