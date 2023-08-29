# Array sorted insertion

## problem domain
return a sorted array if integers.

## Pseudocode
Insert(int[] sorted, int value)
  initialize i to 0
  WHILE value > sorted[i]
    set i to i + 1
  WHILE i < sorted.length
    set temp to sorted[i]
    set sorted[i] to value
    set value to temp
    set i to i + 1
  append value to sorted

InsertionSort(int[] input)
  LET sorted = New Empty Array
  sorted[0] = input[0]
  FOR i from 1 up to input.length
    Insert(sorted, input[i])
  return sorted

## Algorithm

- insert function:
While the index is within bounds and the value to insert is greater than the element at sorted[i], increment i.
While i is within bounds:
Store the current element at sorted[i] in a temporary variable temp.
Replace the element at sorted[i] with the value.
Set value to temp.
Increment i.

- InsertionSort:
Create a new integer array called sorted with the same length as the input array.
Assign the first element of the input array to sorted[0].
Iterate over the input array from index 1.
Call the Insert function to insert the current element into the sorted array.
Return the sorted array.


## big o
The time complexity of the insertion sort algorithm is O(n^2) because When the input array is in reverse order, the algorithm will perform the maximum number of comparisons and shifts.

## Code:
```
 public static void Insert(int[] sorted, int value)
        {
            int i = 0;
            while (i < sorted.Length && value > sorted[i])
            {
                i++;
            }

            while (i < sorted.Length)
            {
                int temp = sorted[i];
                sorted[i] = value;
                value = temp;
                i++;
            }
        }


        public static int[] InsertionSort(int[] input)
        {
            int[] sorted = new int[input.Length];
            sorted[0] = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                Insert(sorted, input[i]);
            }

            return sorted;
        }
```
## Unit tests:
```
public class UnitTest1
    {
        [Fact]
        public void TestInsertionSort()
        {
            int[] input = { 3,2,1 };
            int[] expected = { 1,2,3 };

            int[] sorted = Program.InsertionSort(input);

            Assert.Equal(expected, sorted);
        }
    }
```
