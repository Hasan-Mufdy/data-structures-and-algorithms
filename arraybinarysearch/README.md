### problem domain

Write a function called BinarySearch which takes in 2 parameters: a sorted array and the search key. Without utilizing any of the built-in methods available to your language, return the index of the array’s element that is equal to the value of the search key, or -1 if the element is not in the array.

### test cases

1. given [4, 8, 15, 16, 23, 42], 15 returns 2
2. given [-131, -82, 0, 27, 42, 68, 179], 42 returns 4
3. given [11, 22, 33, 44, 55, 66, 77], 90 returns -1
4. given [1, 2, 3, 5, 6, 7], 4 returns -1

### algorithm

- create a BinarySearch function that takes an array and an integer as a parameters
- check if the input array is not empty
- check if the 2 parameters are correct, first one: sorted array, and the second one: integer
- create 2 new variables, low and high.
- adding a while loop in the method, and adding a new variable inside the while loop named mid, it will continue as long as low is less than high.
- assign mid variable to (low + high) / 2
- we have 3 options until we find the index, if nothing is found, then we will return -1
- the 3 options that we will check are:
- we either return mid, or assign low to mid + 1, or assign high to mid -1
- this will seperate the array to minimize the options

### big O

the big O notation for this problem is O(log n), n is array size. Each iteration the search space is halved

### code

```
public static int BinarySearch(int[] arr, int key)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == key)
            {
                return mid;
            }
            else if (arr[mid] < key)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return -1;
    }

```

### unit tests

```
[Fact]
    public void  BinarySearch_ReturnCorrectOutput(){
    int[] arr = { 1, 2, 3, 5, 6, 7, 8, 9 };
    int key = 5;

    int result = BinarySearch(arr, key);

    Assert.Equal(2, result);
}

[Fact]
    public void BinarySearch_ReturnNegative()
    {
        int[] arr = { 11, 22, 33, 44, 55, 66, 77 };
        int key = 90;

        int result = BinarySearch(arr, key);

        Assert.Equal(-1, result);
    }
[Fact]
    public void BinarySearch_Return()
    {
        int[] arr = new int[-131, -82, 0, 27, 42, 68, 179];
        int key = 42;

        int result = BinarySearch(arr, key);

        Assert.Equal(4, result);
    }

[Fact]
    public void BinarySearch_ReturnIfArrayIsEmpty()
    {
        int[] arr = new int[0];
        int key = 1;

        int result = BinarySearch(arr, key);

        Assert.Equal(-1, result);
    }

```

### white board screenshot

![white board image](/assets/binarysearch.jpg)
