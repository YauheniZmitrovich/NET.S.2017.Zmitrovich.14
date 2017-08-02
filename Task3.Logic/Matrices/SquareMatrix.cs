using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Logic.Matrices
{
    /// <summary>
    /// Representation of a square matrix.
    /// </summary>
    /// <typeparam name="T"> The type of elements in the matrix. </typeparam>
    public class SquareMatrix<T> : RectangularMatrix<T> where T : struct
    {
        #region Properties

        /// <summary>
        /// Length of the one side.
        /// </summary>
        public int Size { get; protected set; }

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
            Size = array.GetLength(0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> One-dimensional array type of <see cref="T"/>. </param>
        public SquareMatrix(T[] array)
            : base(array, (int)Math.Sqrt(array.Length), (int)Math.Sqrt(array.Length))
        {
            Size = (int)Math.Sqrt(array.Length);
        }

        #endregion


        #region Protected methods

        protected override void CheckInputArray(T[] array, int i, int j)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            int size = (int)Math.Sqrt(array.Length);

            if (size * size != array.Length)
                throw new ArgumentException("Square root of array length must be integer.");
        }

        protected override void CheckInputArray(T[][] array) 
        {
            base.CheckInputArray(array);

            if (array.GetLength(0) != array[0].Length)
                throw new ArgumentException("Incorrect size of input array.");
        }

        #endregion
    }
}
