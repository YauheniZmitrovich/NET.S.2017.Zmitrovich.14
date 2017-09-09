using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Logic
{
    /// <summary>
    /// Binary search tree representation.
    /// </summary>
    public sealed class BinarySearchTree<T> : IEnumerable<T>, IEnumerable
    {
        #region Private fields

        private readonly Comparison<T> _compare;

        private Node<T> _root;

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="BinarySearchTree{T}"/>
        /// </summary>
        public BinarySearchTree() : this((Comparison<T>)null) { }

        /// <summary>
        /// Initializes a new instance of <see cref="BinarySearchTree{T}"/>
        /// </summary>
        /// <param name="comparer"> Compares two instances. </param>
        public BinarySearchTree(IComparer<T> comparer) : this(comparer.Compare) { }

        /// <summary>
        /// Initializes a new instance of <see cref="BinarySearchTree{T}"/>
        /// </summary>
        public BinarySearchTree(Comparison<T> comparison)
        {
            _root = null;
            _compare = comparison ?? Comparer<T>.Default.Compare;
        }

        #endregion


        #region Public methods

        /// <summary>
        /// Finds the element in the tree.
        /// </summary>
        /// <param name="element"> Element to find. </param>
        /// <returns> True if the element exists. </returns>
        public bool Contains(T element) => Contains(_root, element);

        /// <summary>
        /// Clears the tree.
        /// </summary>
        public void Clear()
        {
            _root = null;
        }


        /// <summary>
        /// Adds an element in the tree.
        /// </summary>
        /// <param name="element"> Element to add. </param>
        public void Add(T element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            _root = AddElement(_root, element);
        }

        /// <summary>
        /// Adds a collection in the tree.
        /// </summary>
        /// <param name="coll"> Collection to add. </param>
        public void Add(IEnumerable<T> coll)
        {
            if (coll == null)
                throw new ArgumentNullException(nameof(coll));

            foreach (var t in coll)
            {
                Add(t);
            }
        }


        /// <summary>
        /// Preorder traversal.
        /// </summary>
        /// <returns> IEnumerable for preorder. </returns>
        public IEnumerable<T> PreOrder() => PreOrder(_root);

        /// <summary>
        /// Postorder traversal.
        /// </summary>
        /// <returns> IEnumerable for postorder.</returns>
        public IEnumerable<T> PostOrder() => PostOrder(_root);

        /// <summary>
        /// Inorder traversal.
        /// </summary>
        /// <returns> IEnumerable for inorder. </returns>
        public IEnumerable<T> InOrder() => InOrder(_root);

        #endregion


        #region Iterator

        /// <summary>
        /// Iterator.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion


        #region Private methods

        private Node<T> AddElement(Node<T> node, T x)
        {
            if (node == null)
            {
                return new Node<T>(x);
            }

            int temp = _compare(x, node.Value);

            if (temp < 0)
                node.Left = AddElement(node.Left, x);
            else if (temp > 0)
                node.Right = AddElement(node.Right, x);

            return node;
        }

        private bool Contains(Node<T> node, T element)
        {
            if (node == null)
                return false;

            int temp = _compare(node.Value, element);

            if (temp == 0)
                return true;
            else if (temp < 0)
                return Contains(node.Right, element);
            else
                return Contains(node.Left, element);
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Value;

            if (node.Left != null)
                foreach (var n in PreOrder(node.Left))
                    yield return n;

            if (node.Right != null)
                foreach (var n in PreOrder(node.Right))
                    yield return n;
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
                foreach (var n in InOrder(node.Left))
                    yield return n;

            yield return node.Value;

            if (node.Right != null)
                foreach (var n in InOrder(node.Right))
                    yield return n;
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
                foreach (var n in PostOrder(node.Left))
                    yield return n;

            if (node.Right != null)
                foreach (var n in PostOrder(node.Right))
                    yield return n;

            yield return node.Value;
        }

        #endregion


        #region Node

        internal sealed class Node<T>
        {
            public Node<T> Left { get; set; }

            public Node<T> Right { get; set; }

            public T Value { get; set; }

            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        #endregion
    }
}

