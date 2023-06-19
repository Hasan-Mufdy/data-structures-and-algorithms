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
- adding a while loop in the method

### big O

the big O notation for this problem is O(log n), n is array size. Each iteration the search space is halved

### code

```
public static int BinarySearch(int[] arr, int key){

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


```
