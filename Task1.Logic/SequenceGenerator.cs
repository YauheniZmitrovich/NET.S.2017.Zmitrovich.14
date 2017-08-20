using System;
using System.Collections.Generic;
using System.Numerics;

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
        /// <param name="quantity"> Quantity of numbers. </param>
        /// <returns> Sequence of int fibonacci numbers. </returns>
        public static IEnumerable<BigInteger> GenerateFibonacciNumbers(long quantity)
        {
            if (quantity < 1)
                throw new ArgumentException("The quantity must me more than zero.");

            return GenerateNums(quantity);

            IEnumerable<BigInteger> GenerateNums(long q)
            {
                BigInteger prev = 0, curr = 1;

                yield return 1;

                for (int i = 0; i < q - 1; i++)
                {
                    BigInteger temp = curr;
                    curr = prev + curr;
                    prev = temp;

                    yield return curr;
                }
            }

        }
    }
}
