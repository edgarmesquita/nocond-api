using System;
using System.Linq;
using eQuantic.Core.Linq.Filter;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace NoCond.Api.Binders
{
    /// <summary>
    /// Filter Model Binder Provider
    /// </summary>
    public class FilterModelBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// Gets the binder.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var modelType = context.Metadata.ModelType;
            modelType = modelType.IsArray ? modelType.GetElementType() : modelType;

            if (FilterParser.IsValidListType(modelType))
            {
                modelType = modelType.GetGenericArguments().FirstOrDefault();
            }

            if (typeof(IFiltering).IsAssignableFrom(modelType))
            {
                return new BinderTypeModelBinder(typeof(FilterModelBinder));
            }
            return null;
        }
    }
}