using System;
using System.Collections.Generic;
using System.Linq;
using eQuantic.Core.Linq.Filter;

namespace NoCond.Api.Binders
{
    
    /// <summary>
    /// Filter Parser
    /// </summary>
    public static class FilterParser
    {
        private static readonly Type[] ValidListTypes = new Type[] {
            typeof(IEnumerable<>),
            typeof(ICollection<>),
            typeof(IList<>),
            typeof(List<>)
        };

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<IFiltering> Parse(string values)
        {
            var filters = new List<Filtering>();
            var queryStringValues = values.Split(',');
            foreach (var queryStringValue in queryStringValues)
            {
                var columnNameAndValue = queryStringValue.Split(':', 2);
                var columnName = columnNameAndValue[0];

                if (string.IsNullOrEmpty(columnName))
                {
                    continue;
                }
                string value = columnNameAndValue.Length > 1 ? columnNameAndValue[1] : null;

                filters.Add(new Filtering(columnName, value, null));
            }

            return filters;
        }

        internal static bool IsValidListType(Type type)
        {
            return type.IsGenericType && ValidListTypes.Any(t => t.IsAssignableFrom(type.GetGenericTypeDefinition()));
        }
    }
}