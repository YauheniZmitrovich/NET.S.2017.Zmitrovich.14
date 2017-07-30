using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Logic
{
    /// <summary>
    /// Representation of a diagonal matrix.
    /// </summary>
    /// <typeparam name="T"> The type of elements in the matrix. </typeparam>
    public class DiagonalMatrix<T> : SymmetricalMatrix<T>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <param name="size"> The length of the sides. </param>
        public DiagonalMatrix(int size) : base(size) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> Two-dimensional array type of <see cref="T"/>. </param>
        public DiagonalMatrix(T[][] array) : base(array)
        {
            CheckInputArray(array);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> One-dimensional array type of <see cref="T"/>. </param>
        /// <param name="size"> Size of the sides of the matrix. </param>
        public DiagonalMatrix(T[] array, int size) : base(array, size)
        {
            CheckInputArray(array, size);
        }

        #endregion


        #region Protected methods

        protected void CheckInputArray(T[][] array)
        {
            base.CheckInputArray(array);

            for (int i = 0; i < Size; i++)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    bool flag1 = EqualityComparer<T>.Default.Equals(array[i][j], default(T));
                    bool flag2 = EqualityComparer<T>.Default.Equals(array[j][i], default(T));

                    if (flag1 && flag2 == false)
                        throw new ArgumentException("Input matrix must be diagonal.");
                }
            }
        }

        protected void CheckInputArray(T[] array, int size)
        {
            CheckInputArray(array, size);

            for (int i = 0; i < Size; i++)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    bool flag1 = EqualityComparer<T>.Default.Equals(array[i * size + j], default(T));
                    bool flag2 = EqualityComparer<T>.Default.Equals(array[j * size + i], default(T));

                    if (flag1 && flag2 == false)
                        throw new ArgumentException("Input matrix must be diagonal.");
                }
            }
        }

        #endregion
    }
}
