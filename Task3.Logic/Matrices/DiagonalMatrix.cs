using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Logic.Interfaces;

namespace Task3.Logic.Matrices
{
    /// <summary>
    /// Representation of a diagonal matrix.
    /// </summary>
    /// <typeparam name="T"> The type of elements in the matrix. </typeparam>
    public class DiagonalMatrix<T> : IMatrix<T>, IChangableMatrix<T> where T : struct
    {
        #region Private fields

        protected T[] array;

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

                if (i != j)
                    return default(T);

                return array[i];
            }
            set
            {
                CheckInputIndexes(i, j);

                var oldValue = array[i];
                array[i] = value;

                OnElementChanged(new ElementChangedEventArgs<T>(i, j, oldValue, value));
            }
        }

        /// <summary>
        /// Length of the one side.
        /// </summary>
        public int Size { get; protected set; }

        /// <summary>
        /// Count of rows.
        /// </summary>
        public int RowsNum => Size;

        /// <summary>
        /// Count of columns.
        /// </summary>
        public int ColumnsNum => Size;

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <param name="size"> The length of the sides. </param>
        public DiagonalMatrix(int size)
        {
            if (size < 1)
                throw new ArgumentException("Size must be more than zero.");

            Size = size;

            array = new T[size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <param name="arr"> Two-dimensional array type of <see cref="T"/>. </param>
        public DiagonalMatrix(T[][] arr)
        {
            CheckInputArray(arr);

            Size = arr.GetLength(0);

            array = new T[Size];

            for (int i = 0; i < Size; i++)
                array[i] = arr[i][i];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/>.
        /// </summary>
        /// <param name="array"> 
        /// One-dimensional array with elements type of <see cref="T"/>. Intializes main diagonal.
        /// </param>
        public DiagonalMatrix(T[] arr)
        {
            CheckInputArray(arr);

            Size = arr.Length;

            array = new T[Size];

            for (int i = 0; i < Size; i++)
                array[i] = arr[i];
        }

        #endregion


        #region Protected and private methods

        protected void OnElementChanged(ElementChangedEventArgs<T> eventArgs)
        {
            if (eventArgs == null)
                throw new ArgumentNullException(nameof(eventArgs));

            ElementChanged?.Invoke(this, eventArgs);
        }

        protected virtual void CheckInputArray(T[][] arr)
        {
            #region Null ref validation

            if (arr == null)
                throw new ArgumentNullException(nameof(arr));

            for (int i = 0; i < arr.GetLength(0); i++)
                if (arr[i] == null)
                    throw new ArgumentNullException(nameof(arr));

            #endregion

            
            #region As square matrix validation

            int size = (int)Math.Sqrt(arr.Length);

            if (arr.GetLength(0) != arr[0].Length)
                throw new ArgumentException("Incorrect size of input array.");

            #endregion


            #region As diagonal matrix validation

            for (int i = 0; i < Size; i++)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    bool flag1 = EqualityComparer<T>.Default.Equals(arr[i][j], default(T));
                    bool flag2 = EqualityComparer<T>.Default.Equals(arr[j][i], default(T));

                    if (flag1 && flag2 == false)
                        throw new ArgumentException("Input matrix must be diagonal.");
                }
            }

            #endregion
        }

        protected virtual void CheckInputArray(T[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
        }

        private void CheckInputIndexes(int i, int j)
        {
            if (i < 0 || i >= Size)
                throw new ArgumentOutOfRangeException("Incorrect index of row.");
            if (j < 0 || i >= Size)
                throw new ArgumentOutOfRangeException("Incorrect index of column.");
        }

        #endregion
    }
}
