using System;
using System.Linq;
using AlgorithmsPractise;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tests
{
    public class SearchingTests
    {
        private int[] Array { get; set; }
        private Random Random { get; set; }

        [SetUp]
        public void SetUp()
        {
            var (sorted, _) = new Tests().CreateArrays(6);
            Array = sorted;
            Random = new Random();
        }

        [TestCase(6, 3, Description = "On array size of 6 and element is presented")]
        [TestCase(6, -1, Description = "On array size of 6 and element is not presented")]
        [TestCase(1, 0, Description = "On array size of 1 and element is presented")]
        [TestCase(1, -1,  Description = "On array size of 1 and element is not presented")]
        public void BinarySearch(int size, int expected)
        {
            int elementToSearch;
            if (expected == -1)
                elementToSearch = Array.Max() + 1;
            else
                elementToSearch = Array[expected];

            var actual = new Searching().BinarySearch(Array, elementToSearch);
            Assert.AreEqual(expected, actual);
        }

        private int GetUniqueElement(int[] array)
        {
            return array.Max() + 1;
        }
    }
}