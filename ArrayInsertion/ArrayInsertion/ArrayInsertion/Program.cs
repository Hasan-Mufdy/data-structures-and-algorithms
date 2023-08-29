using System;
namespace Array_Sorted_Insertion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            Console.WriteLine("Unsorted array:");
            foreach (int num in input)
            {
                Console.Write(num + " - ");
            }
            Console.WriteLine();

            int[] sorted = InsertionSort(input);

            Console.WriteLine("Sorted array:");
            foreach (int num in sorted)
            {
                Console.Write(num + " - ");
            }
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
    }
}