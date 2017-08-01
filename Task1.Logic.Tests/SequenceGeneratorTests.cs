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

            IEnumerable<int> res = GenerateFibonacciNumbers(i => i <= 1);

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_BoundIs5_ReturnsSequenceOfFiveElements()
        {
            IEnumerable<int> expectedRes = new int[] { 1, 1, 2, 3, 5 };

            IEnumerable<int> res = Logic.SequenceGenerator.GenerateFibonacciNumbers(i => i <= 5);

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_BoundIs7_ReturnsSequenceOfFiveElements()
        {
            IEnumerable<int> expectedRes = new int[] { 1, 1, 2, 3, 5 };

            IEnumerable<int> res = Logic.SequenceGenerator.GenerateFibonacciNumbers(i => i <= 7.5);

            Assert.AreEqual(expectedRes, res);
        }

        #endregion


        #region Exceptions

        [Test]
        [Category("Task1")]
        public void GenerateFibonacciNumbers_NullReference_ThrowsArgumentNullException()
        {
            IEnumerable<int> res;

            res = GenerateFibonacciNumbers(null);//NO EXCEPTION!

            Assert.Catch<ArgumentException>(() =>
            {
                foreach (var n in GenerateFibonacciNumbers(null))//HERE
                {
                    int b = n;
                }
            });
        }

        #endregion
    }
}
