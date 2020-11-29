using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EShop.API.Extentions
{
    public static class CsvMapper
    {
        public static T MapToObject<T>(this IDictionary<string, string> source) where T : new()
        {
            var entity = typeof(T);
            var propertyDetails = new Dictionary<string, PropertyInfo>();
            var properties = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            propertyDetails = properties.ToDictionary(
                 p =>
                 {
                     var attribute = p.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>().Single();
                     return attribute.Description.ToUpper();
                 },
                 p => p);

            T result = new T();
            Type type = typeof(T);

            foreach (var item in source)
            {
                if (propertyDetails.ContainsKey(item.Key.ToUpper()))
                {
                    var info = propertyDetails[item.Key.ToUpper()];

                    if ((info != null) && info.CanWrite)
                    {
                        info.SetValue(result, item.Value);
                    }

                }
            }
            return result;

        }
    }
}