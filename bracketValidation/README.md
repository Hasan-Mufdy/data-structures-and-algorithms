# Multi-bracket Validation.

#### Feature Tasks

- Write a function called validate brackets
Arguments: string
- Return: boolean
- representing whether or not the brackets in the string are balanced
There are 3 types of brackets:

1. Round Brackets : ()
2. Square Brackets : []
3. Curly Brackets : {}

## Whiteboard Process

![wb](/assets/bracketwb.jpg)


## Approach & Efficiency
the big O notation for this implementation is O(n), as we need to loop through the brackets, depending on its size.


## Solution

#### code:
```
public class BracketValidator
{
    public static bool ValidateBrackets(string input)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in input)
        {
            
            //// 1
            if (ch == '{' || ch == '[' || ch == '(')
            {
                stack.Push(ch);
            }

            //// 2
            else if (ch == '}' || ch == ']' || ch == ')')
            {
                if (stack.Count == 0)
                    return false;
                char top = stack.Pop();
                if ((ch == '}' && top != '{') || (ch == ']' && top != '[') || (ch == ')' && top != '('))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
```

#### unit tests:
```
[Fact]
        public void ChecK_If_Balanced()
        {
            // Arrange
            string input1 = "{([[[]]])}";
            string input2 = "{[]}";

            // Act
            bool result1 = BracketValidator.ValidateBrackets(input1);
            bool result2 = BracketValidator.ValidateBrackets(input2);

            // Assert
            Assert.True(result1);
            Assert.True(result2);

        }

        [Fact]
        public void ChecK_If_Not_Balanced()
        {
            // Arrange
            string input1 = "{((}}";
            string input2 = "{}}";


            // Act
            bool result1 = BracketValidator.ValidateBrackets(input1);
            bool result2 = BracketValidator.ValidateBrackets(input2);


            // Assert
            Assert.False(result1);
            Assert.False(result2);

        }
```

