using System;
using System.Linq;
using System.Linq.Dynamic;

namespace EShop.API.Extentions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string sort)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (sort == null)
                return source;

            var listSort = sort.Split(',');

            foreach (var sortOption in listSort.Reverse())
            {
                if (sortOption.StartsWith("-"))
                    source = source.OrderBy(sortOption.Remove(0, 1) + " descending");
                else
                    source = source.OrderBy(sortOption);
            }

            return source;
        }
    }
}