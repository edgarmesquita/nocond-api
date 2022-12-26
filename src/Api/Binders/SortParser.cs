using System;
using System.Collections.Generic;
using System.Linq;
using eQuantic.Core.Linq.Sorter;

namespace NoCond.Api.Binders
{
    /// <summary>
    /// Sort Parser
    /// </summary>
    public static class SortParser
    {
        private static readonly Dictionary<string, SortDirection> ValidDirections = new Dictionary<string, SortDirection>(StringComparer.InvariantCultureIgnoreCase) {
            { "asc", SortDirection.Ascending },
            { "desc", SortDirection.Descending }
        };

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
        public static IEnumerable<ISorting> Parse(string values)
        {
            var sorts = new List<Sorting>();
            var queryStringValues = values.Split(',');
            foreach (var queryStringValue in queryStringValues)
            {
                var columnNameAndDirection = queryStringValue.Split(':');
                var columnName = columnNameAndDirection[0];

                if (string.IsNullOrEmpty(columnName))
                {
                    continue;
                }
                var direction = SortDirection.Ascending;

                if (columnNameAndDirection.Length > 1)
                {
                    direction = ParseDirection(columnNameAndDirection[1].Trim());
                }

                sorts.Add(new Sorting { ColumnName = columnName, SortDirection = SortDirection.Ascending });
            }

            return sorts;
        }

        /// <summary>
        /// Try parse.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="sortings"></param>
        /// <returns></returns>
        public static bool TryParse(string values, out IEnumerable<ISorting> sortings)
        {
            try
            {
                sortings = Parse(values);
                return true;
            }
            catch
            {
                sortings = null;
                return false;
            }
        }

        internal static bool IsValidListType(Type type)
        {
            return type.IsGenericType && ValidListTypes.Any(t => t.IsAssignableFrom(type.GetGenericTypeDefinition()));
        }

        private static SortDirection ParseDirection(string directionName)
        {
            if (!ValidDirections.ContainsKey(directionName))
            {
                throw new FormatException($"The sort direction '{directionName}' is invalid.");
            }

            return directionName.Equals("desc", StringComparison.InvariantCultureIgnoreCase) ?
                SortDirection.Descending :
                SortDirection.Ascending;
        }
    }
}