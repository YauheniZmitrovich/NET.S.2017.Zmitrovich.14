using System;
using System.Collections.Generic;

namespace Task1.Logic
{
    /// <summary>
    /// Generate various sequences of numbers.
    /// </summary>
    public static class SequenceGenerator
    {
        /// <summary>
        /// Generate sequence of fibonacci numbers up to a certain limit. 
        /// </summary>
        /// <param name="condition"> Termination condition. </param>
        /// <returns> Sequence of int fibonacci numbers. </returns>
        public static IEnumerable<int> GenerateFibonacciNumbers(Predicate<int> condition)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            int prev = 0, curr = 1;
           
            while (condition(curr))
            {

                yield return curr;

                int temp = curr;
                curr = prev + curr;
                prev = temp;
            }
        }
    }
}
