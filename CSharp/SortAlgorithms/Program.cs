using System;

namespace SortAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 2, 3, 5, 6, 8, 9, 7, 0 };
            //SortAlgorithms.BubbleSort(arr);
            //SortAlgorithms.SelectionsSort(arr);
            SortAlgorithms.InsertionSort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i]}, ");
            }
        }
    }
}
