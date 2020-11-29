using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace EShop.Data.Extention
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

        public static IList<T> MapToList<T>(this DbDataReader dataReader) where T : new()
        {
            IList<T> result = null;
            var entity = typeof(T);

            var propertyDetails = new Dictionary<string, PropertyInfo>();

            try
            {
                if (dataReader == null || !dataReader.HasRows)
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

                while (dataReader.Read())
                {
                    T newObject = new T();
                    for (int Index = 0; Index < dataReader.FieldCount; Index++)
                    {
                        if (propertyDetails.ContainsKey(dataReader.GetName(Index).ToUpper()))
                        {
                            var Info = propertyDetails[dataReader.GetName(Index).ToUpper()];
                            if ((Info != null) && Info.CanWrite)
                            {
                                var Val = dataReader.GetValue(Index);
                                Info.SetValue(newObject, (Val == DBNull.Value) ? null : Val, null);
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

        public static T MapToSingle<T>(this DbDataReader dataReader) where T : new()
        {
            T result = new T();
            var entity = typeof(T);
            var propertyDetails = new Dictionary<string, PropertyInfo>();
            try
            {
                if (dataReader == null || !dataReader.HasRows)
                    return result;

                var properties = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                propertyDetails = properties.ToDictionary(
                    p =>
                    {
                        var attribute = p.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>().Single();
                        return attribute.Description.ToUpper();
                    },
                    p => p);

                dataReader.Read();

                for (int Index = 0; Index < dataReader.FieldCount; Index++)
                {
                    if (propertyDetails.ContainsKey(dataReader.GetName(Index).ToUpper()))
                    {
                        var propertyInfo = propertyDetails[dataReader.GetName(Index).ToUpper()];
                        if ((propertyInfo != null) && propertyInfo.CanWrite)
                        {
                            var value = dataReader.GetValue(Index);
                            propertyInfo.SetValue(result, (value == DBNull.Value) ? null : value, null);
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
    }
}
