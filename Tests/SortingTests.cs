using System;
using System.Transactions;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        // (SORTED[], NOT_SORTED[])
        public (int[], int[]) CreateArrays(int size)
        {
            var sorted = new int[size];
            var rand = new Random();
            sorted[0] = rand.Next() % 100;

            // Create sorted array
            for (int i = 1; i < size; i++)
            {
                sorted[i] = sorted[i - 1] + rand.Next() % 100;
            }

            // Create unsorted array
            var swapTimes = rand.Next() % 100;
            var unsorted = new int[size];
            Array.Copy(sorted, unsorted, size);
            for (int i = 0; i < swapTimes; i++)
            {
                var index1 = rand.Next() % size;
                var index2 = rand.Next() % size;
                var tmp = unsorted[index1];
                unsorted[index1] = unsorted[index2];
                unsorted[index2] = tmp;
            }

            return (sorted, unsorted);
        }

        [TestCase(6)]
        public void MergeSort(int size)
        {
            var (sorted, unsorted) = CreateArrays(size);
            var actual = new AlgorithmsPractise.Sorting().MergeSort(unsorted);
            Assert.AreEqual(sorted, actual);
        }

        [TestCase(6)]
        public void HeapSort(int size)
        {
            var (sorted, unsorted) = CreateArrays(size);
            var actual = new AlgorithmsPractise.Sorting().HeapSort(unsorted);
            Assert.AreEqual(sorted, actual);
        }

        [TestCase(6)]
        public void QuickSort(int size)
        {
            var (sorted, unsorted) = CreateArrays(size);
            var actual = new AlgorithmsPractise.Sorting().QuickSort(unsorted);
            Assert.AreEqual(sorted, actual);
        }
    }
}