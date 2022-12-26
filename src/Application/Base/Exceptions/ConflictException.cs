using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace NoCond.Application.Base.Exceptions
{
    /// <summary>
    /// Conflict Exception
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ConflictException : Exception
    {
        public ConflictException() : base("Conflicts found.")
        {
        }

        public ConflictException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected ConflictException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}