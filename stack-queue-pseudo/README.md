# two Stacks queue

## problem domain

Implement a Queue using two Stacks.

## big O

the time complexity for dequeue method is O(n) in case of stack2 is empty.
other methods and dequeue if not empty have of o(1).

## algorithm

- enqueue: Move all elements from stack2 to stack1 until stack2 is empty. While stack2 is not empty, pop an element from stack2. else, push the popped element into stack1.then push the new value to be enqueued into stack1.
finally, push the value into stack1.

- dequeue: move all elements from stack1 to stack2 until stack1 is empty. While stack1 is not empty, pop an element from stack1.then push the popped element into stack2.
finally, pop the top element from stack2, and pop an element from stack2.

## code:
```
class PseudoQueue
{
    private Stack stack1;
    private Stack stack2;

    public PseudoQueue()
    {
        stack1 = new Stack();
        stack2 = new Stack();
    }

    public void Enqueue(int value)
    {
        while (!stack2.IsEmpty())
        {
            stack1.Push(stack2.Pop());
        }
        stack1.Push(value);
    }

    public int Dequeue()
    {
        while (!stack1.IsEmpty())
        {
            stack2.Push(stack1.Pop());
        }
        return stack2.Pop();
    }
}
```
