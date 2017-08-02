using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Task3.Logic.Matrices;

namespace Task3.Logic.Tests
{
    [TestFixture]
    public class DiagonalMatrixTests
    {
        #region Constructors

        [Test]
        [Category("Task3")]
        public void CtorWithSize_NegativeSize_ThrowsArgumentException()
        {
            DiagonalMatrix<int> matr;
            Assert.Catch<ArgumentException>(() => matr = new DiagonalMatrix<int>(-5));
        }

        [Test]
        [Category("Task3")]
        public void CtorWithTwoDimensionalArray_RectangularArr_ThrowsArgumentException()
        {
            DiagonalMatrix<int> matr;
            int[][] arr =
            {
                new int[] {1, 2, 3, 4},
                new int[] {5, 6, 7, 8},
                new int[] {9, 10, 11, 12}
            };

            Assert.Catch<ArgumentException>(() => matr = new DiagonalMatrix<int>(arr));
        }

        [Test]
        [Category("Task3")]
        public void CtorWithOneDimensionalArray_NullRef_ThrowsArgumentException()
        {
            DiagonalMatrix<int> matr;
            int[] arr = null;

            Assert.Catch<ArgumentNullException>(() => matr = new DiagonalMatrix<int>(arr));
        }

        #endregion
    }
}
