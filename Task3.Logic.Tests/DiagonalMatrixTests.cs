using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

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
        public void CtorWithOneDimensionalArray_IncorrectSize_ThrowsArgumentException()
        {
            DiagonalMatrix<int> matr;
            int[] arr = { 1, 2, 3, 4, 9, 10, 11, 12 };

            Assert.Catch<ArgumentException>(() => matr = new DiagonalMatrix<int>(arr, 5));
        }

        #endregion


        #region Methods

        [Test]
        [Category("Task3")]
        public void SumWithMatrix_AllOk_SumOfThoMatrices()
        {
            DiagonalMatrix<int> matr1 = new DiagonalMatrix<int>(
                new int[][]
                {
                    new int[] {1, 2, 3},
                    new int[] {5, 6, 7},
                    new int[] {9, 10, 11}
                }
            );

            int[][] expectedArray =
                new int[][]
                {
                    new int[] {2, 4, 6},
                    new int[] {10, 12, 14},
                    new int[] {18, 20, 22}
                };

            Func<int, int, int> delFunc = (int x, int y) => x + y;

            Assert.AreEqual(expectedArray,matr1.SumWithMatrix(matr1,delFunc));
        }

        #endregion
    }
}
