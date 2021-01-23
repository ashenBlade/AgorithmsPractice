using System;
using System.Threading;

namespace AlgorithmsPractise
{
    public class Sorting
    {
        private void Swap<T>(T[] array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        #region Merge Sort
        public int[] MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
            return array;
        }
        private void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (right + left) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        private void Merge(int[] array, int left, int middle, int right)
        {
            if (left == right)
                return;
            var sorted = new int[right - left + 1];
            int l = 0, r = 0; // l - left subarray index, r - right subarray index
            var leftBorder = middle - left + 1;
            var rightBorder = right - middle;
            for (int i = 0; i <= right - left; i++)
            {
                sorted[i] = l < leftBorder && r < rightBorder
                                ? array[l + left] < array[r + middle + 1]
                                      ? array[l++ + left]
                                      : array[r++ + middle + 1]
                                : l < leftBorder
                                    ? array[l++ + left]
                                    : array[r++ + middle + 1];
                // if (l < leftBorder && r < rightBorder)
                // {
                //     if (array[l + left] < array[r + middle + 1])
                //     {
                //         sorted[i] = array[l + left];
                //         l++;
                //     }
                //     else
                //     {
                //         sorted[i] = array[r + middle + 1];
                //         r++;
                //     }
                // }
                // else
                // {
                //     if (l < leftBorder)
                //     {
                //         sorted[i] = array[l + left];
                //         l++;
                //     }
                //     else
                //     {
                //         sorted[i] = array[r + middle + 1];
                //         r++;
                //     }
                // }
            }


            Array.Copy(sorted, 0, array, left, sorted.Length);
        }
        #endregion

        #region Heap Sort
        public T[] HeapSort<T>(T[] array) where T: IComparable<T>
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
                Heapify(array, array.Length, i);
            for (int i = array.Length - 1; i >= 0; i--)
            {
                var tmp = array[0];
                array[0] = array[i];
                array[i] = tmp;
                Heapify(array, i, 0);
            }

            return array;
        }

        /// <summary>
        /// Sort element with current index in heap
        /// </summary>
        /// <param name="array">Heap to sort</param>
        /// <param name="size">Size of heap to sort</param>
        /// <param name="index">Index of element to sort</param>
        /// <typeparam name="T"></typeparam>
        private void Heapify<T>(T[] array,int size, int index) where T: IComparable<T>
        {
            var largest = index;
            var l = 2 * index + 1; // Left child
            var r = 2 * index + 2; // Right child
            if (l < size && array[largest].CompareTo(array[l]) < 0)
                largest = l;
            if (r < size && array[largest].CompareTo(array[r]) < 0)
                largest = r;
            if (largest != index)
            {
                var tmp = array[index];
                array[index] = array[largest];
                array[largest] = tmp;
                Heapify(array, size, largest);
            }
        }

        #endregion

        public T[] QuickSort<T>(T[] array) where T: IComparable<T>
        {
            QuickSort(array, 0, array.Length - 1);
            return array;
        }


        private void QuickSort<T>(T[] array, int first, int last) where T: IComparable<T>
        {
            // Array of 1 element is already sorted
            if (first >= last)
                return;

            // Place last element into right (true) position
            var p = Partial(array, first, last);

            // Process left, then right array parts
            QuickSort(array, first, p - 1);
            QuickSort(array, p + 1, last);
        }

        private int Partial<T>(T[] array, int first, int last) where T: IComparable<T>
        {
            if (first >= last)
                throw new ArgumentOutOfRangeException(nameof(first) + nameof(last));
            // Smallest element index
            int lower = first;

            // Compare every element in range with last
            for (int i = first; i < last; i++)
            {
                // If current element is smaller -> swap with lower
                // Then increase index of lower element by 1
                if (0 > array[i].CompareTo(array[last]))
                {
                    Swap(array, lower, i);
                    lower++;
                }
            }

            // Swap last element with first after smallest
            Swap(array, lower, last);
            return lower;
        }
    }
}