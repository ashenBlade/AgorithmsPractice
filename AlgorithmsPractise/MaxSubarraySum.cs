using System;

namespace AlgorithmsPractise
{
    public class MaxSubarraySum
    {
        public int GetMaxSubSum(int[] array)
        {
            var best = 0;
            var sum = 0;
            foreach (var num in array)
            {
                sum = Math.Max(num, sum + num);
                best = Math.Max(sum, best);
            }

            return best;
        }
    }
}