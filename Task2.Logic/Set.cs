using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    /// <summary>
    /// Represents a set of values. 
    /// </summary>
    /// <typeparam name="T">  The type of elements in the set. </typeparam>
    public sealed class Set<T> : ISet<T>, ICollection<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
        where T : class, IEquatable<T>, ICloneable
    {
        #region Private fields

        private T[] _array;

        #endregion


        #region Properties

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether is read-only.
        /// </summary>
        public bool IsReadOnly { get; } = true;

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="Set{T}"/>
        /// that is empty and has the default initial capacity.
        /// </summary>
        public Set()
        {
            Count = 0;
            _array = new T[0];
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Set{T}"/>
        /// that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">
        /// The initial number of elements that the <see cref="Set{T}"/> can contain.
        /// </param>
        public Set(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("Capacity can't be less than zero.");

            Count = 0;
            _array = new T[capacity];
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Set{T}"/> that contains 
        /// elements copied from the specified collection and has sufficient capacity
        /// to accommodate the number of elements copied.
        /// </summary>
        /// <param name="array"> 
        /// The collection whose elements are copied to the new <see cref="Set{T}"/> 
        /// </param>
        public Set(IEnumerable<T> array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            _array = new T[array.Count()];

            foreach (var elem in array)
            {
                Add(elem);
            }
        }

        #endregion


        #region Destructive methods

        /// <summary>
        /// Adds an object to the end of the <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="item"> 
        /// The object to add to the <see cref="Set{T}"/>.
        /// </param>
        /// <returns> Returns true if the operation is successful. </returns>
        public bool Add(T item)
        {

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (Contains(item))
                return false;

            if (this.Count == _array.Length)
            {
                T[] objArray = new T[Count + 1];
                Array.Copy(_array, objArray, Count);

                objArray[Count] = item;

                _array = objArray;
                Count++;
            }
            else
            {
                _array[Count] = item;
                Count++;
            }

            return true;
        }

        /// <summary>
        /// Removes all objects from the <see cref="Set{T}"/>.
        /// </summary>
        public void Clear()
        {
            _array = new T[_array.Length];
            Count = 0;
        }

        /// <summary>
        /// Removes the object from the <see cref="Set{T}"/>.
        /// </summary>
        /// <param name="item"> 
        /// The object to remove from the <see cref="Set{T}"/>.
        /// </param>
        /// <returns> Returns true if the operation is successful. </returns>
        public bool Remove(T item)
        {
            if (Count == 0)
                throw new SetIsEmptyException();

            int index;

            for (index = 0; index < Count; index++)
                if (_array[index].Equals(item))
                {
                    break;
                }

            if (index == Count)
                return false;

            while (index < Count - 1)
            {
                _array[index] = _array[index + 1];
                index++;
            }

            Count--;

            return true;
        }

        /// <summary>
        /// Modifies the current set so that it contains all elements that are present in
        /// either the current set or the specified collection.
        /// </summary>
        /// <param name="other"> The collection to compare to the current set. </param>
        public void UnionWith(IEnumerable<T> other)
        {

            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (_array.Length < Count + other.Count())
            {
                T[] resArray = new T[Count + other.Count()];

                _array.CopyTo(resArray, 0);

                int i = Count;
                foreach (var el in other)
                    resArray[i++] = el;

                _array = resArray;
            }
            else
            {
                foreach (var el in other)
                    Add(el);
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are also in a
        /// specified collection.
        /// </summary>
        /// <param name="other"> The collection to compare to the current set. </param>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            Set<T> res = new Set<T>(Count);

            foreach (var el in this)
                if (other.Contains(el))
                    res.Add(el);

            _array = new T[res.Count];
            Count = res.Count;

            res.CopyTo(_array, 0);
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current set.
        /// </summary>
        /// <param name="other"> The collection of items to remove from the set. </param>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            Set<T> res = new Set<T>(Count);

            foreach (var el in this)
                if (!other.Contains(el))
                    res.Add(el);

            _array = new T[res.Count];
            Count = res.Count;

            res.CopyTo(_array, 0);
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are present either
        /// in the current set or in the specified collection, but not both.
        /// </summary>
        /// <param name="other">  The collection to compare to the current set. </param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            foreach (var el in other)
                if (Contains(el))
                {
                    Remove(el);
                }
                else
                {
                    Add(el);
                }
        }

        #endregion


        #region Nondestructive methods

        /// <summary>
        /// Determines whether <see cref="Set{T}"/> contains a specific value.
        /// </summary>
        /// <param name="item">  The object to locate in <see cref="Set{T}"/>. </param>
        /// <returns> 
        /// True if item is found in <see cref="Set{T}"/>; otherwise, false.
        /// </returns>
        public bool Contains(T item)
        {
            foreach (T t in this)
                if (t.Equals(item))
                    return true;

            return false;
        }

        /// <summary>
        /// Copies the elements of <see cref="Set{T}"/> to an System.Array,
        /// starting at a particular System.Array index.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional System.Array that is the destination of the elements copied
        /// from  <see cref="Set{T}"/> . The System.Array must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">  The zero-based index in array at which copying begins. </param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || array.Length < Count + arrayIndex)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            int i = 0;
            foreach (var el in this)
            {
                array[arrayIndex + i] = (T)el.Clone();
                i++;
            }
        }

        /// <summary>
        /// Determines whether a set is a subset of a specified collection.
        /// </summary>
        /// <param name="other"> The collection to compare to the current set. </param>
        /// <returns>  true if the current set is a subset of other; otherwise, false. </returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            foreach (var el in this)
            {
                if (!other.Contains(el))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether the current set is a superset of a specified collection.
        /// </summary>
        /// <param name="other"> The collection to compare to the current set. </param>
        /// <returns> true if the current set is a superset of other; otherwise, false. </returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            foreach (var el in other)
                if (!Contains(el))
                    return false;

            return true;
        }

        /// <summary>
        /// Determines whether the current set is a proper (strict) superset of a specified
        /// collection.
        /// </summary>
        /// <param name="other"> The collection to compare to the current set. </param>
        /// <returns>  true if the current set is a proper superset of other; otherwise, false. </returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (_array.SequenceEqual(other))
                return false;

            return IsSupersetOf(other);
        }

        /// <summary>
        /// Determines whether the current set is a proper (strict) subset of a specified
        /// collection.
        /// </summary>
        /// <param name="other"> The collection to compare to the current set. </param>
        /// <returns> true if the current set is a proper subset of other; otherwise, false. </returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (_array.SequenceEqual(other))
                return false;

            return IsSubsetOf(other);
        }

        /// <summary>
        /// Determines whether the current set overlaps with the specified collection.
        /// </summary>
        /// <param name="other"> The collection to compare to the current set. </param>
        /// <returns> 
        /// true if the current set and other share at least one common element; otherwise, false.
        /// </returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            foreach (var el in other)
            {
                if (Contains(el))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the current set and the specified collection contain the same
        /// elements.
        /// </summary>
        /// <param name="other"> The collection to compare to the current set. </param>
        /// <returns> true if the current set is equal to other; otherwise, false. </returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (other.Count() != Count)
                return false;

            foreach (var el in other)
                if (!Contains(el))
                    return false;

            return true;
        }

        #endregion


        #region Iterator

        /// <summary>
        /// Iterator.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return _array[i];
        }

        #endregion


        #region Private methods

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
