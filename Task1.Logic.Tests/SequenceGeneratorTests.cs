using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using static Task1.Logic.SequenceGenerator;

namespace Task1.Logic.Tests
{
    [TestFixture]
    public class SequenceGeneratorTests
    {
        #region Good script

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_QuantityIs2_ReturnsSequenceOfTwoElements()
        {
            IEnumerable<BigInteger> expectedRes = new BigInteger[] { 1, 1 };

            IEnumerable<BigInteger> res = GenerateFibonacciNumbers(2);

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_BoundIs5_ReturnsSequenceOfFiveElements()
        {
            IEnumerable<BigInteger> expectedRes = new BigInteger[] { 1, 1, 2, 3, 5 };

            IEnumerable<BigInteger> res = GenerateFibonacciNumbers(5);

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_BoundIs7_ReturnsSequenceOfFiveElements()
        {
            IEnumerable<BigInteger> expectedRes = new BigInteger[] { 1, 1, 2, 3, 5, 8, 13 };

            IEnumerable<BigInteger> res = GenerateFibonacciNumbers(7);

            Assert.AreEqual(expectedRes, res);
        }

        #endregion


        #region Exceptions

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_NullReference_ThrowsArgumentNullException()
        {
            IEnumerable<BigInteger> res;

            Assert.Catch<ArgumentException>(() =>
            {
                res = GenerateFibonacciNumbers(-4);
            });
        }

        #endregion
    }
}
