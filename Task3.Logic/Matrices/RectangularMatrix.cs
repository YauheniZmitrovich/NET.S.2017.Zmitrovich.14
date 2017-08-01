using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Logic
{
    /// <summary>
    /// Representation of a rectangular matrix.
    /// </summary>
    /// <typeparam name="T"> The type of elements in the matrix. </typeparam>
    public class RectangularMatrix<T> : IMatrix<T> where T : struct
    {
        #region Private and protected fields 

        protected T[][] matrix;

        #endregion


        #region Events indexator and properties

        /// <summary>
        /// The event when any element changes.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i"> Index of row. </param>
        /// <param name="j"> Index of column. </param>
        public virtual T this[int i, int j]
        {
            get
            {
                CheckInputIndexes(i, j);
                return matrix[i][j];
            }
            set
            {
                CheckInputIndexes(i, j);

                var oldValue = matrix[i][j];
                matrix[i][j] = value;

                OnElementChanged(new ElementChangedEventArgs<T>(i, j, oldValue, value));
            }
        }

        /// <summary>
        /// Count of rows.
        /// </summary>
        public int RowsNum { get; }

        /// <summary>
        /// Count of columns.
        /// </summary>
        public int ColumnsNum { get; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangularMatrix{T}"/>.
        /// </summary>
        /// <param name="rows"> The number of rows. </param>
        /// <param name="columns"> The number of columns. </param>
        public RectangularMatrix(int rows, int columns)
        {
            CheckInputSizes(rows, columns);

            RowsNum = rows;
            ColumnsNum = columns;

            matrix = new T[rows][];

            for (int i = 0; i < rows; i++)
                matrix[i] = new T[columns];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangularMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> Two-dimensional array type of <see cref="T"/>. </param>
        public RectangularMatrix(T[][] array)
        {
            CheckInputArray(array);

            RowsNum = array.GetLength(0);
            ColumnsNum = array[0].Length;

            matrix = array;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangularMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> One-dimensional array type of <see cref="T"/>. </param>
        /// <param name="rows"> The number of rows. </param>
        /// <param name="columns"> The number of columns. </param>
        public RectangularMatrix(T[] array, int rows, int columns)
        {
            CheckInputArray(array, rows, columns);

            matrix = new T[rows][];
            RowsNum = rows;
            ColumnsNum = columns;

            for (int i = 0; i < rows; i++)
                matrix[i] = new T[columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    matrix[i][j] = array[i * ColumnsNum + j];
                }
        }

        #endregion


        #region Protected methods

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> eventArgs)
        {
            if (eventArgs == null)
                throw new ArgumentNullException(nameof(eventArgs));

            ElementChanged?.Invoke(this, eventArgs);
        }


        protected virtual void CheckInputIndexes(int i, int j)
        {
            if (i < 0 || i >= RowsNum)
                throw new ArgumentOutOfRangeException("Incorrect index of row.");
            if (j < 0 || i >= ColumnsNum)
                throw new ArgumentOutOfRangeException("Incorrect index of column.");
        }

        protected void CheckInputSizes(int rows, int columns)
        {
            if (rows < 1)
                throw new ArgumentException("Number of rows must be more then zero.");
            if (columns < 1)
                throw new ArgumentException("Number of coumns must be more then zero.");
        }


        protected virtual void CheckInputArray(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
        }

        protected virtual void CheckInputArray(T[] array, int i, int j)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Length != i * j)
                throw new ArgumentException("Multiplication of indexes must be equal to array length.");
            if (i < 1 || j < 1)
                throw new ArgumentOutOfRangeException("Indexes must be more than zero.");
        }

        #endregion
    }

}
