using System;

namespace AlgorithmsPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] {-1, 2, 4, -3, 5, 2, -5, 2};
            new Sorting().MergeSort(array);
            foreach (var i in array)
            {
                Console.WriteLine(i + " ");
            }
        }
    }
}