using System;
using NUnit.Framework;
using Task3.Logic.Extensions;
using Task3.Logic.Matrices;

namespace Task3.Logic.Tests
{
    [TestFixture]
    public class MatrixExtensionsTests
    {
        #region Auxiliary data

        DiagonalMatrix<int> matr1 = new DiagonalMatrix<int>(
            new int[][]
            {
                new int[] {1, 0, 0},
                new int[] {0, 6, 0},
                new int[] {0, 0, 11}
            }
        );

        #endregion

        #region Tests

        [Test]
        [Category("Task3")]
        public void Add_AllOk_SumOfTwoMatrices()
        {
            DiagonalMatrix<int> expectedMatrix = new DiagonalMatrix<int>(
                new int[][]
                {
                    new int[] {2, 0, 0},
                    new int[] {0, 12, 0},
                    new int[] {0, 0, 22}
                }
            );

            Func<int, int, int> sumFunc = (int x, int y) => x + y;

            DiagonalMatrix<int> resMatrix = matr1.Add(matr1, sumFunc);

            bool equalFlag = true;

            for (int i = 0; i < resMatrix.Size; i++)
                for (int j = 0; j < resMatrix.Size; j++)
                    if (resMatrix[i, j] != expectedMatrix[i, j])
                        equalFlag = false;

            Assert.True(equalFlag);
        }

        [Test]
        [Category("Task3")]
        public void AddDiagonalMatrices_AllOk_SumOfTwoMatrices()
        {
            DiagonalMatrix<int> expectedMatrix = new DiagonalMatrix<int>(
                new int[][]
                {
                    new int[] {2, 0, 0},
                    new int[] {0, 12, 0},
                    new int[] {0, 0, 22}
                }
            );

            Func<int, int, int> sumFunc = (int x, int y) => x + y;

            DiagonalMatrix<int> resMatrix =matr1.Add(matr1, sumFunc);

            bool equalFlag = true;

            for (int i = 0; i < resMatrix.Size; i++)
                for (int j = 0; j < resMatrix.Size; j++)
                    if (resMatrix[i, j] != expectedMatrix[i, j])
                        equalFlag = false;

            Assert.True(equalFlag);
        }

        [Test]
        [Category("Task3")]
        public void AddDiagonalWithSymmetricalMatrices_AllOk_SumOfTwoMatrices()
        {
            SymmetricalMatrix<int> matr2 = new SymmetricalMatrix<int>(
                new int[][]
                {
                    new int[] {1, 2, 3},
                    new int[] {2, 6, 0},
                    new int[] {3, 0, 11}
                }
            );

            SymmetricalMatrix<int> expectedMatrix = new SymmetricalMatrix<int>(
                new int[][]
                {
                    new int[] {2, 2, 3},
                    new int[] {2, 12, 0},
                    new int[] {3, 0, 22}
                }
            );

            Func<int, int, int> sumFunc = (int x, int y) => x + y;

            SymmetricalMatrix<int> resMatrix = matr1.Add(matr2, sumFunc);

            bool equalFlag = true;

            for (int i = 0; i < resMatrix.Size; i++)
            for (int j = 0; j < resMatrix.Size; j++)
                if (resMatrix[i, j] != expectedMatrix[i, j])
                    equalFlag = false;

            Assert.True(equalFlag);
        }

        #endregion
    }
}