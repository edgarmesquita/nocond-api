using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace NoCond.Application.Base.Exceptions
{
    /// <summary>
    /// Class EntityNotFoundException.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class EntityNotFoundException<TKey> : Exception
    {
        public TKey Id { get; }
        public Type Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException{TKey}"/> class.
        /// </summary>
        public EntityNotFoundException(TKey id) : base($"Entity '{id}' not found.")
        {
            Id = id;
        }

        public EntityNotFoundException(TKey id, Type type) : base($"Entity '{id}' of '{type.Name}' not found.")
        {
            Id = id;
            Type = type;
        }
        
        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}