using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Logic
{
    /// <summary>
    /// Representation of a symmetrical matrix.
    /// </summary>
    /// <typeparam name="T"> The type of elements in the matrix. </typeparam>
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}"/>.
        /// </summary>
        /// <param name="size"> The length of the sides. </param>
        public SymmetricalMatrix(int size) : base(size) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> Two-dimensional array type of <see cref="T"/>. </param>
        public SymmetricalMatrix(T[][] array) : base(array)
        {
            CheckInputArray(array);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> One-dimensional array type of <see cref="T"/>. </param>
        public SymmetricalMatrix(T[] array, int size) : base(array, size)
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
                    if (array[i][j].Equals(array[j][i]))
                    {
                        throw new ArgumentException("Input matrix must be symmetrical.");
                    }
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
                    if (array[i * size + j] .Equals(array[j * size + i]))
                    {
                        throw new ArgumentException("Input matrix must be symmetrical.");
                    }
                }
            }

        }

        #endregion
    }
}
