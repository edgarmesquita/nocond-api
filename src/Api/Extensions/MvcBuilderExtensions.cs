using Microsoft.Extensions.DependencyInjection;
using NoCond.Api.Binders;
using NoCond.Api.Filters;

namespace NoCond.Api.Extensions
{
    /// <summary>
    /// MVC Builder Extensions
    /// </summary>
    public static class MvcBuilderExtensions
    {
        /// <summary>
        /// Adds Filter Model Binder
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddFilterModelBinder(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddMvcOptions(opt =>
            {
                opt.ModelBinderProviders.Insert(0, new FilterModelBinderProvider());
            });
            return mvcBuilder;
        }

        /// <summary>
        /// Adds Sort Model Binder
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddSortModelBinder(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddMvcOptions(opt =>
            {
                opt.ModelBinderProviders.Insert(0, new SortModelBinderProvider());
            });
            return mvcBuilder;
        }
    }
}