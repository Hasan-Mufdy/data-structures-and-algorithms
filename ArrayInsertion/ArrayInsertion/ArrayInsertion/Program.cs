using System;
namespace Array_Sorted_Insertion
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            int[] insertionSortInput = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] mergeSortInput = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            Console.WriteLine("Insertion Sort:");
            Console.WriteLine("Unsorted array:");
            PrintArray(insertionSortInput);

            int[] insertionSorted = InsertionSort(insertionSortInput);

            Console.WriteLine("Sorted array:");
            PrintArray(insertionSorted);

            Console.WriteLine("\nMerge Sort:");
            Console.WriteLine("Original array:");
            PrintArray(mergeSortInput);

            MergeSort(mergeSortInput);

            Console.WriteLine("Sorted array:");
            PrintArray(mergeSortInput);
        }
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

        public static void MergeSort(int[] arr)
        {
            int n = arr.Length;
            if (n > 1)
            {
                int mid = n / 2;
                int[] left = new int[mid];
                int[] right = new int[n - mid];

                for (int i = 0; i < mid; i++)
                {
                    left[i] = arr[i];
                }
                for (int i = mid; i < n; i++)
                {
                    right[i - mid] = arr[i];
                }

                MergeSort(left);
                MergeSort(right);
                Merge(left, right, arr);
            }
        }

        public static void Merge(int[] left, int[] right, int[] arr)
        {
            int i = 0, j = 0, k = 0;
            int leftLength = left.Length;
            int rightLength = right.Length;

            while (i < leftLength && j < rightLength)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < leftLength)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < rightLength)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }

        public static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }


    }
}