using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Logic;

namespace Task2.ConsoleUI
{
    class Program
    {
        /// <summary>
        /// Representation of a soldier.
        /// </summary>
        public sealed class Soldier : IEquatable<Soldier>,ICloneable
        {
            private int _height;

            /// <summary>
            /// Height of the soldier.
            /// </summary>
            public int Height
            {
                get => _height;
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Height must be more than zero");
                    _height = value;
                }
            }

            /// <summary>
            /// Name of the soldier.
            /// </summary>
            public string Name { get; set; }

            /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
            /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
            /// <param name="other">An object to compare with this object.</param>
            public bool Equals(Soldier other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return _height == other._height;
            }

            /// <summary>Determines whether the specified object is equal to the current object.</summary>
            /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
            /// <param name="obj">The object to compare with the current object. </param>
            /// <filterpriority>2</filterpriority>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return Equals((Soldier)obj);
            }

            /// <summary>Serves as the default hash function. </summary>
            /// <returns>A hash code for the current object.</returns>
            /// <filterpriority>2</filterpriority>
            public override int GetHashCode()
            {
                return _height;
            }

            /// <summary>Creates a new object that is a copy of the current instance.</summary>
            /// <returns>A new object that is a copy of this instance.</returns>
            /// <filterpriority>2</filterpriority>
            public object Clone()//TODO:
            {
                return new Soldier(){Height = this.Height,Name = this.Name};
            }

            /// <summary>Returns a string that represents the current object.</summary>
            /// <returns>A string that represents the current object.</returns>
            /// <filterpriority>2</filterpriority>
            public override string ToString()
            {
                return _height.ToString();
            }
        }

        static void Main(string[] args)
        {
            //The similar example of logic of Set tests from
            //https://msdn.microsoft.com/en-us/library/bb358446(v=vs.110).aspx

            Set<Soldier> firstDivision = new Set<Soldier>();
            Set<Soldier> armyOfSoldiers = new Set<Soldier>();

            for (int i = 181; i < 185; i++)
            {
                firstDivision.Add(new Soldier(){Height = i});
            }

            for (int i = 180; i < 190; i++)
            {
                armyOfSoldiers.Add(new Soldier() { Height = i });
            }

            Console.Write("firstDivision contains {0} elements: ", firstDivision.Count);
            DisplaySet(firstDivision);

            Console.Write("armyOfSoldiers contains {0} elements: ", armyOfSoldiers.Count);
            DisplaySet(armyOfSoldiers);

            Console.WriteLine("firstDivision overlaps armyOfSoldiers: {0}",
                firstDivision.Overlaps(armyOfSoldiers));

            Console.WriteLine("armyOfSoldiers and firstDivision are equal sets: {0}",
                armyOfSoldiers.SetEquals(firstDivision));

            // Show the results of sub/superset testing
            Console.WriteLine("firstDivision is a subset of armyOfSoldiers: {0}",
                firstDivision.IsSubsetOf(armyOfSoldiers));
            Console.WriteLine("armyOfSoldiers is a superset of firstDivision: {0}",
                armyOfSoldiers.IsSupersetOf(firstDivision));
            Console.WriteLine("firstDivision is a proper subset of armyOfSoldiers: {0}",
                firstDivision.IsProperSubsetOf(armyOfSoldiers));
            Console.WriteLine("armyOfSoldiers is a proper superset of firstDivision: {0}",
                armyOfSoldiers.IsProperSupersetOf(firstDivision));

            // Modify armyOfSoldiers to remove numbers that are not in firstDivision.
            armyOfSoldiers.IntersectWith(firstDivision);
            Console.Write("armyOfSoldiers contains {0} elements: ", armyOfSoldiers.Count);
            DisplaySet(armyOfSoldiers);

            Console.WriteLine("armyOfSoldiers and firstDivision are equal sets: {0}",
                armyOfSoldiers.SetEquals(firstDivision));

            // Show the results of sub/superset testing with the modified set.
            Console.WriteLine("firstDivision is a subset of armyOfSoldiers: {0}",
                firstDivision.IsSubsetOf(armyOfSoldiers));
            Console.WriteLine("armyOfSoldiers is a superset of firstDivision: {0}",
                armyOfSoldiers.IsSupersetOf(firstDivision));
            Console.WriteLine("firstDivision is a proper subset of armyOfSoldiers: {0}",
                firstDivision.IsProperSubsetOf(armyOfSoldiers));
            Console.WriteLine("armyOfSoldiers is a proper superset of firstDivision: {0}",
                armyOfSoldiers.IsProperSupersetOf(firstDivision));
        }

        static void DisplaySet<T>(Set<T> set) where T:class,IEquatable<T>,ICloneable
        {
            foreach (var el  in set)
            {
                Console.Write(el.ToString()+" ");
            }
            Console.WriteLine();
        }

        /* This code example produces output similar to the following:
         * firstDivision contains 4 elements: { 181 182 183 184 }
         * armyOfSoldiers contains 10 elements: { 180 181 182 183 184 185 186 187 188 189 }
         * firstDivision overlaps armyOfSoldiers: True
         * armyOfSoldiers and firstDivision are equal sets: False
         * firstDivision is a subset of armyOfSoldiers: True
         * armyOfSoldiers is a superset of firstDivision: True
         * firstDivision is a proper subset of armyOfSoldiers: True
         * armyOfSoldiers is a proper superset of firstDivision: True
         * armyOfSoldiers contains 4 elements: { 181 182 183 184 }
         * armyOfSoldiers and firstDivision are equal sets: True
         * firstDivision is a subset of armyOfSoldiers: True
         * armyOfSoldiers is a superset of firstDivision: True
         * firstDivision is a proper subset of armyOfSoldiers: False
         * armyOfSoldiers is a proper superset of firstDivision: False
         */
    }
}

