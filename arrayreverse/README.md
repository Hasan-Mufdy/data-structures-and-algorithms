### problem domain
write a function called reverseArray to take an array and reverse it

### test cases
1. given 1,2,3,4,5,6 return 6,5,4,3,2,1
2. given an empty array return null
3. given an array with length of 1 return the same array

### visualization
![array and reversed array](/assets/array-display-reverse.png)

### algorithm
- create a reverseArray function
- check if the array is empty
- if the array is empty return null
- check if the array has one value
- if the array has one value return the same array
- loop through the array and store the values from finish to start
- return the new array

### big O
time complexity is O(n), because there is a loop in the code
and space complexity is also O(n), because that there is a one array

### code
```
public static int[] reverseArray(int[] arr){
    if(arr.Length == 0){
        return null;
    }
    else if(arr.Length == 1){
        return arr;
    }
    else{
        int[] reversedArr = new int[arr.Length];
        int index = 0;
        for(int i = arr.Length; i>=0 ;i--){
            reversedArr[index] = arr[i];
            index++;
        }
        return reversedArr;
    }

}

```

### unit testing
```
[fact]
public void reverseArray_ReturnReversed(){
    int[] arr = { 1, 2, 3, 4, 5 };
    int[] expected = { 5, 4, 3, 2, 1 };\

    int[] result = Program.reverseArray(arr);

    Assert.Equal(expected, result);
}

[fact]
public void reverseArray_ReturnNull(){
    int[] arr = { };

    int[] result = Program.reverseArray(arr);

    Assert.Null(result);
}
```

### white board screenshot
![white board image](/assets/code%20challenge%201%20WB.png)