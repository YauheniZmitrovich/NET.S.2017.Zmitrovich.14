using System;

namespace Task3.Logic.Interfaces
{
    /// <summary>
    /// Defines main logic of a matrix.
    /// </summary>
    /// <typeparam name="T"> Type of elements of matrix. </typeparam>
    public interface IMatrix<T> where T : struct
    {
        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i"> Index of row. </param>
        /// <param name="j"> Index of column. </param>
        T this[int i, int j] { get; }

        /// <summary>
        /// Count of rows.
        /// </summary>
        int RowsNum { get; }

        /// <summary>
        /// Count of columns.
        /// </summary>
        int ColumnsNum { get; }
    }
}