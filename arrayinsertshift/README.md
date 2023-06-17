### problem domain
write a function that takes in an array and a value to be added. Without utilizing any of the built-in methods available to your language, return an array with the new value added at the middle index.

### test cases
1. given [2,4,6,-8], 5 returns [2,4,5,6,-8]
2. given [42,8,15,23,42], 16 returns [42,8,15,16,23,42]
3. given an empty array, or an array with length of 1 returns the array with added number

### algorithm
- create an insertShiftArray function
- check if array empty or have one item
- if yes, then return the array with added number
- store length/2 in a pre defined variable
- create a for loop to fill the array to the middle
- assign the input int to the middle element of the array
- create another for loop to fill the rest of the array

### big O
time complexity is O(2n), because there is 2 loops in the code
and space complexity is also O(2n), because that there is a two arrays that will be filled

### code
```
public static int[] insertShiftArray(int[] arr, int n){
    int mid = arr.length/2;
    int[] newArr = new int[arr.Length + 1];
    // first loop:
    for(int i = 0; i < mid; i++ ){
        newArr[i] = arr[i];
    }

    newArr[mid] = n;

    // second for:
    for(int i = mid + 1; i < newArr.Length; i++){
        newArr[i] = arr[i-1];

    }
    return newArr;
}
```

### unit testing
```
[fact]
public void insertShiftArray_ReturnNewArray(){
    int[] arr = { 1, 2, 3, 4 };
    int num = 55;
    int[] expected = { 1, 2, 55, 3, 4 };

    int[] result = Program.insertShiftArray(arr, num);

    Assert.Equal(expected, result);
}
```

### white board screenshot
![white board image](/assets/code%20challenge%202.png)