using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
        public void GenerateFibonacciNumbers_BoundIs1_ReturnsSequenceOfTwoElements()
        {
            IEnumerable<int> expectedRes = new int[] { 1, 1 };

            IEnumerable<int> res = GenerateFibonacciNumbers(1);

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_BoundIs5_ReturnsSequenceOfFiveElements()
        {
            IEnumerable<int> expectedRes = new int[] { 1, 1, 2, 3, 5 };

            IEnumerable<int> res = Logic.SequenceGenerator.GenerateFibonacciNumbers(5);

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_BoundIs7_ReturnsSequenceOfFiveElements()
        {
            IEnumerable<int> expectedRes = new int[] { 1, 1, 2, 3, 5 };

            IEnumerable<int> res = Logic.SequenceGenerator.GenerateFibonacciNumbers(7);

            Assert.AreEqual(expectedRes, res);
        }

        #endregion


        #region Exceptions

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_BoundIsLessThanZero_ThrowsArgumentException()
        {
            Assert.Catch<ArgumentException>(() =>
            {
                foreach (var n in GenerateFibonacciNumbers(-3))//HERE
                {
                    int b = n;
                }
            });
        }

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_BoundIsZero_ThrowsArgumentException()
        {
            IEnumerable<int> res;
            
            res = GenerateFibonacciNumbers(0);//NO EXCEPTION!

            Assert.Catch<ArgumentException>(() =>
            {
                foreach (var n in res)//HERE
                {
                    int b = n;
                }
            });

        }

        #endregion
    }
}
