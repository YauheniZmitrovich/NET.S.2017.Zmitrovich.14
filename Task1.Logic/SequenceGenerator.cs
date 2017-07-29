using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="bound"> The boundary to which array will be generated. </param>
        /// <returns> Sequence of int fibonacci numbers. </returns>
        public static IEnumerable<int> GenerateFibonacciNumbers(int bound)
        {
            if (bound < 1)
                throw new ArgumentException("The bound must be more than zero.");

            int prev = 0, curr = 1;
           
            while (curr <= bound)
            {

                yield return curr;

                int temp = curr;
                curr = prev + curr;
                prev = temp;
            }
        }
    }
}
