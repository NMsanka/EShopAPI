using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EShop.Logic.Extention
{
    public static class Extentions
    {
        public static string GetDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static IList<T> MapToList<T, S>(this IList<S> list) where T : new()
        {
            IList<T> result = null;
            var entity = typeof(T);

            var propertyDetails = new Dictionary<string, PropertyInfo>();

            try
            {
                if (list == null || list.Count() == 0)
                    return result;

                result = new List<T>();
                var properties = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                propertyDetails = properties.ToDictionary(
                     p =>
                     {
                         var attribute = p.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>().Single();
                         return attribute.Description.ToUpper();
                     },
                     p => p);

                foreach (var item in list)
                {
                    T newObject = new T();

                    Type type = typeof(S);

                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        if (propertyDetails.ContainsKey(property.Name.ToUpper()))
                        {
                            var Info = propertyDetails[property.Name.ToUpper()];
                            if ((Info != null) && Info.CanWrite)
                            {
                                var val = property.GetValue(item);
                                Info.SetValue(newObject, (val == DBNull.Value) ? null : val, null);
                            }
                        }
                    }
                    result.Add(newObject);
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static T MapToSingle<T, S>(this S source) where T : new()
        {
            T result = new T();
            var entity = typeof(T);
            var propertyDetails = new Dictionary<string, PropertyInfo>();
            try
            {
                if (source == null)
                    return result;

                var properties = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                propertyDetails = properties.ToDictionary(
                    p =>
                    {
                        var attribute = p.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>().Single();
                        return attribute.Description.ToUpper();
                    },
                    p => p);

                Type type = typeof(S);

                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (propertyDetails.ContainsKey(property.Name.ToUpper()))
                    {
                        var Info = propertyDetails[property.Name.ToUpper()];
                        if ((Info != null) && Info.CanWrite)
                        {
                            var val = property.GetValue(source);
                            Info.SetValue(result, (val == DBNull.Value) ? null : val, null);
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<GroupResult> GroupByMany<TElement>(this IEnumerable<TElement> elements, params Func<TElement, object>[] groupSelectors)
        {
            if (groupSelectors.Length > 0)
            {
                var selector = groupSelectors.First();

                //reduce the list recursively until zero
                var nextSelectors = groupSelectors.Skip(1).ToArray();
                return
                    elements.GroupBy(selector).Select(
                        g => new GroupResult
                        {
                            Key = g.Key,
                            Count = g.Count(),
                            Items = g,
                            SubGroups = g.GroupByMany(nextSelectors)
                        });
            }
            else
                return null;
        }


        public class GroupResult
        {
            public object Key { get; set; }

            public int Count { get; set; }

            public IEnumerable Items { get; set; }

            public IEnumerable<GroupResult> SubGroups { get; set; }

            public override string ToString()
            {
                return string.Format("{0} ({1})", Key, Count);
            }
        }

    }
}
