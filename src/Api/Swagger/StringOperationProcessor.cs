using System.Linq;
using NJsonSchema;
using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace NoCond.Api.Swagger
{
    /// <summary>
    /// Filter Operation Processor
    /// </summary>
    /// <seealso cref="NSwag.Generation.Processors.IOperationProcessor" />
    public class StringOperationProcessor<T> : IOperationProcessor
    {
        /// <summary>
        /// Processes the specified method information.
        /// </summary>
        /// <param name="context">The processor context.</param>
        /// <returns>
        /// true if the operation should be added to the Swagger specification.
        /// </returns>
        public bool Process(OperationProcessorContext context)
        {
            var sortParameters = context.Parameters.Where(p => p.Key.ParameterType == typeof(T));
            foreach (var sortParameter in sortParameters)
            {
                var position = context.OperationDescription.Operation.Parameters.IndexOf(sortParameter.Value);
                var newParameter = new OpenApiParameter
                {
                    Name = sortParameter.Value.Name,
                    Title = sortParameter.Value.Title,
                    Description = sortParameter.Value.Description,
                    Kind = sortParameter.Value.Kind,
                    Id = sortParameter.Value.Id,
                    Schema = new JsonSchema
                    {
                        Type = JsonObjectType.String
                    }
                };
                context.OperationDescription.Operation.Parameters.Insert(position, newParameter);
                context.OperationDescription.Operation.Parameters.Remove(sortParameter.Value);
            }
            return true;
        }
    }
}