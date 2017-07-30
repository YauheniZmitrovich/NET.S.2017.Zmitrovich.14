using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    /// <summary>
    /// Represents errors when set is empty. 
    /// </summary>
    public sealed class SetIsEmptyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SetIsEmptyException"/> .
        /// </summary>
        public SetIsEmptyException() : base("Queue is empty.") { }

        /// <summary>
        /// Initializes a new instance of <see cref="SetIsEmptyException"/> 
        /// class with message string.
        /// </summary>
        /// <param name="message"> The message about exception. </param>
        public SetIsEmptyException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of <see cref="SetIsEmptyException"/> 
        /// class with message string and inner exception.
        /// </summary>
        /// <param name="message"> The message about exception. </param>
        /// <param name="innerException"> The inner exception. </param>
        public SetIsEmptyException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
