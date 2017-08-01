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
    public class RectangularMatrix<T>
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
        public T this[int i, int j]
        {
            get
            {
                CheckInputIndexes(i, j);
                return matrix[i][j];//TODO:Goodbye incapsulation #0 if ref type.
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
            if (rows < 1)
                throw new ArgumentException("Number of rows must be more then zero.");
            if (columns < 1)
                throw new ArgumentException("Number of coumns must be more then zero.");

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

            matrix = array;//TODO:Goodbye incapsulation #1
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangularMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> One-dimensional array type of <see cref="T"/>. </param>
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
                    matrix[i][j] = array[i * ColumnsNum + j];//TODO:Goodbye incapsulation #2
                }
        }
        
        #endregion


        #region Methods

        /// <summary>
        /// Summarizes current and other matrices type of <see cref="RectangularMatrix{T}"/>.
        /// </summary>
        /// <param name="otherMatrix"> The second matrix to addition. </param>
        /// <param name="func"> Function with addition condition. </param>
        /// <returns> new Instance of <see cref="RectangularMatrix{T}"/> with summary matrix. </returns>
        public T[][] SumWithMatrix(RectangularMatrix<T> otherMatrix, Func<T, T, T> func)
            => RectangularMatrix<T>.SumMatrices(this, otherMatrix, func);

        /// <summary>
        /// Summarizes two matrices type of <see cref="RectangularMatrix{T}"/>.
        /// </summary>
        /// <param name="ob1"> The first matrix to addition. </param>
        /// <param name="ob2"> The second matrix to addition. </param>
        /// <param name="func"> Function with addition condition. </param>
        /// <returns> new Instance of <see cref="RectangularMatrix{T}"/> with summary matrix. </returns>
        public static T[][] SumMatrices(RectangularMatrix<T> ob1, RectangularMatrix<T> ob2, Func<T, T, T> func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (ob1 == null)
                throw new ArgumentNullException(nameof(ob1));
            if (ob2 == null)
                throw new ArgumentNullException(nameof(ob2));

            if (ob1.RowsNum != ob2.RowsNum || ob1.ColumnsNum != ob2.ColumnsNum)
                throw new ArgumentException("Matrices must have the same sizes.");


            T[][] res = new T[ob1.RowsNum][];

            for (int i = 0; i < ob1.RowsNum; i++)
                res[i] = new T[ob1.ColumnsNum];

            for (int i = 0; i < ob1.RowsNum; i++)
                for (int j = 0; j < ob1.ColumnsNum; j++)
                    res[i][j] = func(ob1[i, j], ob2[i, j]);

            return res;
        }

        #endregion


        #region Protected methods

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> eventArgs)
        {
            if (eventArgs == null)
                throw new ArgumentNullException(nameof(eventArgs));

            ElementChanged?.Invoke(this, eventArgs);
        }

        protected void CheckInputIndexes(int i, int j)
        {
            if (i < 0 || i >= RowsNum)
                throw new ArgumentOutOfRangeException("Incorrect index of row.");
            if (j < 0 || i >= ColumnsNum)
                throw new ArgumentOutOfRangeException("Incorrect index of column.");
        }

        protected void CheckInputArray(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
        }

        protected void CheckInputArray(T[] array, int i, int j)
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

    /// <summary>
    /// Event arguments for ElementChanged event of <see cref="RectangularMatrix{T}"/>.
    /// </summary>
    /// <typeparam name="T"> Type of elements in matrix. </typeparam>
    public class ElementChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Row of changed element.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Column of changed element.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Old value of element.
        /// </summary>
        public T OldValue { get; }

        /// <summary>
        /// New value of element.
        /// </summary>
        public T NewValue { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ElementChangedEventArgs{T}"/>.
        /// </summary>
        /// <param name="i"> Row of changed element. </param>
        /// <param name="j"> Column of changed element. </param>
        /// <param name="oldValue"> Old value of changed element. </param>
        /// <param name="value"> New value of element. </param>
        public ElementChangedEventArgs(int i, int j, T oldValue, T value)
        {
            Row = i;
            Column = j;
            OldValue = oldValue;
            NewValue = value;
        }
    }
}
