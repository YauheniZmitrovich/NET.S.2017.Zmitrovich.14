using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Logic
{
    /// <summary>
    /// Representation of a square matrix.
    /// </summary>
    /// <typeparam name="T"> The type of elements in the matrix. </typeparam>
    public class SquareMatrix<T> : RectangularMatrix<T>
    {
        #region Properties

        /// <summary>
        /// Length of the one side.
        /// </summary>
        public int Size { get; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/>.
        /// </summary>
        /// <param name="size"> The length of the sides. </param>
        public SquareMatrix(int size) : base(size, size)
        {
            Size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> Two-dimensional array type of <see cref="T"/>. </param>
        public SquareMatrix(T[][] array) : base(array)
        {
            CheckInputArray(array);

            Size = array.GetLength(0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> One-dimensional array type of <see cref="T"/>. </param>
        public SquareMatrix(T[] array, int size) : base(array, size, size)
        {
            CheckInputArray(array, size);

            Size = size;
        }

        #endregion


        #region Protected methods

        protected void CheckInputIndexes(int size)
        {
            if (size < 0 || size >= Size)
                throw new ArgumentOutOfRangeException("Incorrect size.");
        }

        protected void CheckInputArray(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException("Incorrect size of input array.");
        }

        protected void CheckInputArray(T[] array, int size)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Length % size != 0)
                throw new ArgumentException("Square of size must be equal to array length.");
            if (size<1)
                throw new ArgumentOutOfRangeException("Size must be more than zero.");
        }

        #endregion
    }
}
