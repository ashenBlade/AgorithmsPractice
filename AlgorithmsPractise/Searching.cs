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

        public double CalculateSquareRoot(double number, int depth = 20)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Number can't be negative");
            // TODO
            if (number < 1)
                return double.NegativeInfinity;
            // Square root of number is some M: M^2 = (number)
            // => Make binary search in range from 1 to number (depth count)
            var l = 1.0; // Left side
            var r = number;
            var m = (l + r) / 2; // Middle number
            for (int i = 0; i < depth; i++)
            {
                // If m*m is lefter than number => move left border to middle
                if (m * m <= number)
                    l = m;
                // Else move right border to middle
                else
                    r = m;
                // Update middle number
                m = (l + r) / 2.0;
            }
            return m;
        }
    }
}