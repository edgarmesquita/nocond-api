using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eQuantic.Core.Linq.Sorter;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NoCond.Api.Binders
{
    /// <summary>
    /// Sort Model Binder
    /// </summary>
    public class SortModelBinder : IModelBinder
    {
        /// <summary>
        /// Bind model.
        /// </summary>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var values = valueProviderResult.Values;
            var model = new List<ISorting>();

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                {
                    continue;
                }

                model.AddRange(SortParser.Parse(value));
            }

            if (bindingContext.ModelType.IsArray)
            {
                bindingContext.Result = ModelBindingResult.Success(model.ToArray());
            }
            else if (SortParser.IsValidListType(bindingContext.ModelType))
            {
                bindingContext.Result = ModelBindingResult.Success(model);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Success(model.FirstOrDefault());
            }

            return Task.CompletedTask;
        }
    }
}