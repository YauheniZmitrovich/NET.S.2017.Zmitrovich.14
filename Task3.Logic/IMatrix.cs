using System;

namespace Task3.Logic
{
    /// <summary>
    /// Defines main functions of a matrix.
    /// </summary>
    /// <typeparam name="T"> Type of elements of matrix. </typeparam>
    public interface IMatrix<T> where T : struct
    {
        /// <summary>
        /// The event when any element changes.
        /// </summary>
        event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i"> Index of row. </param>
        /// <param name="j"> Index of column. </param>
        T this[int i, int j] { get; set; }

        /// <summary>
        /// Count of rows.
        /// </summary>
        int RowsNum { get; }

        /// <summary>
        /// Count of columns.
        /// </summary>
        int ColumnsNum { get; }
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