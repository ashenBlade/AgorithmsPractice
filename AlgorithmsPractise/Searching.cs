using System;

namespace AlgorithmsPractise
{
    public class Searching
    {
        public int BinarySearch<T>(T[] array, T element) where T : IComparable<T>
        {
            return BinarySearch(array, element, 0, array.Length - 1);
        }

        private int BinarySearch<T>(T[] array, T element, int left, int right) where T : IComparable<T>
        {
            // Element not found
            if (right < left)
                return -1;
            int middle = (left + right) / 2;
            if (array[middle].CompareTo(element) == 0)
                return middle;

            if (array[middle].CompareTo(element) > 0)
                return BinarySearch(array, element, left, middle - 1);
            return BinarySearch(array, element, middle + 1, right);
        }
    }
}