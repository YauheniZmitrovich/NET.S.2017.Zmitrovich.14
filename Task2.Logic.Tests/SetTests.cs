using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2.Logic.Tests
{
    /// <summary>
    /// Represents a fat person.
    /// </summary>
    public sealed class FatPerson : IEquatable<FatPerson>, ICloneable
    {
        private int _weight;

        /// <summary>
        /// Weight of the person.
        /// </summary>
        public int Weight
        {
            get => _weight;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Weight must be more than zero");
                _weight = value;
            }
        }

        /// <summary>
        /// Name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(FatPerson other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _weight == other._weight;
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((FatPerson)obj);
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return _weight;
        }

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        /// <filterpriority>2</filterpriority>
        public object Clone()//TODO:
        {
            int h = Weight;
            string n = Name;
            return new FatPerson() { Weight = h, Name = n };
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return _weight.ToString();
        }
    }

    /// <summary>
    /// Unit tests using NUnit Framework.
    /// </summary>
    [TestFixture]
    public class SetTests
    {
        #region Constructors tests

        [Test]
        [Category("Task2")]
        public void CtorWithIEnumerable_NullRef_ThrowsArgumentNullException()
        {
            Assert.Catch<ArgumentNullException>(() =>
                {
                    Set<FatPerson> set = new Set<FatPerson>(null);
                }
            );
        }

        [Test]
        [Category("Task2")]
        public void CtorWithCapacity_NegativeNumber_ThrowsArgumentException()
        {
            Assert.Catch<ArgumentException>(() =>
                {
                    Set<FatPerson> set = new Set<FatPerson>(-5);
                }
            );
        }

        #endregion


        #region Methods tests


        #region Good scripts

        [Test]
        [Category("Task2")]
        public void UnionWith_AllOk()
        {
            Set<FatPerson> set1 = new Set<FatPerson>();
            Set<FatPerson> set2 = new Set<FatPerson>();
            Set<FatPerson> expectedSet = new Set<FatPerson>();

            for (int i = 100; i < 200; i += 25)
                set1.Add(new FatPerson() {Weight = i});

            for (int i = 200; i < 300; i += 25)
                set1.Add(new FatPerson() { Weight = i });

            for (int i = 100; i < 300; i += 25)
                expectedSet.Add(new FatPerson() { Weight = i });


            set1.UnionWith(set2);


            Assert.AreEqual(expectedSet,set1);
        }

        [Test]
        [Category("Task2")]
        public void ExceptWith_AllOk()
        {
            Set<FatPerson> set1 = new Set<FatPerson>();
            Set<FatPerson> set2 = new Set<FatPerson>();
            Set<FatPerson> expectedSet = new Set<FatPerson>();

            for (int i = 100; i < 300; i += 25)
                set1.Add(new FatPerson() { Weight = i });

            for (int i = 100; i < 200; i += 25)
                set2.Add(new FatPerson() { Weight = i });

            for (int i = 200; i < 300; i += 25)
                expectedSet.Add(new FatPerson() { Weight = i });


            set1.ExceptWith(set2);


            Assert.AreEqual(expectedSet, set1);
        }

        [Test]
        [Category("Task2")]
        public void SymmetricExceptWith_AllOk()
        {
            Set<FatPerson> set1 = new Set<FatPerson>();
            Set<FatPerson> set2 = new Set<FatPerson>();
            Set<FatPerson> expectedSet = new Set<FatPerson>();

            for (int i = 150; i < 250; i += 25)
                set1.Add(new FatPerson() { Weight = i });

            for (int i = 200; i < 300; i += 25)
                set2.Add(new FatPerson() { Weight = i });

            for (int i = 150; i < 200; i += 25)
                expectedSet.Add(new FatPerson() { Weight = i });
            for (int i = 250; i < 300; i += 25)
                expectedSet.Add(new FatPerson() { Weight = i });

            set1.SymmetricExceptWith(set2);


            Assert.AreEqual(expectedSet, set1);
        }
        #endregion


        #region Exceptions

        [Test]
        [Category("Task2")]
        public void Add_NullRef_ThrowsArgumentNullException()
        {
            Set<string> set = new Set<string>();
            Assert.Catch<ArgumentNullException>(() => set.Add(null));
        }

        [Test]
        [Category("Task2")]
        public void Remove_EmptyEqueue_ThrowsQuequeIsEmptyException()
        {
            Set<FatPerson> set = new Set<FatPerson>();
            Assert.Catch<SetIsEmptyException>(() => set.Remove(new FatPerson()));
        }

        #endregion


        #endregion
    }
}
