using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using Array_Sorted_Insertion;

namespace Array_Sorted_Insertion_Test
{
    public class UnitTest1
    {
        [Fact]
        public void InsertionSort_SortsUnsortedArray()
        {
            // Arrange
            int[] input = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Act
            int[] sorted = Array_Sorted_Insertion.Program.InsertionSort(input);

            // Assert
            Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, sorted);
        }

        //////////////////////////////////////////////////////////////////////////
        /////
        [Fact]
        public void MergeSort_SortsUnsortedArray()
        {
            // Arrange
            int[] input = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Act
            Array_Sorted_Insertion.Program.MergeSort(input);

            // Assert
            Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, input);
        }
    }
}