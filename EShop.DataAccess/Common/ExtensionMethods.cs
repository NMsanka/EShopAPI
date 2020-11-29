using System;
using System.Data.Common;

namespace EShop.Data.Common
{
    /// <summary>
    /// ExtensionMethods
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static object GetValue(this DbDataReader dbDataReader, string name)
        {
            int ordinal = dbDataReader.GetOrdinal(name);
            if (dbDataReader.IsDBNull(ordinal))
                return (object)null;
            return dbDataReader.GetValue(ordinal);
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static DateTime GetDateTime(this DbDataReader dbDataReader, string name)
        {
            return dbDataReader.GetDateTime(name, false).Value;
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="dReader">The d reader.</param>
        /// <param name="name">The name.</param>
        /// <param name="IsNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">Cannot cast DBNull.Value to type 'System.DateTime'.</exception>
        internal static DateTime? GetDateTime(this DbDataReader dReader, string name, bool IsNullable)
        {
            int ordinal = dReader.GetOrdinal(name);
            if (!dReader.IsDBNull(ordinal))
                return new DateTime?(dReader.GetDateTime(ordinal));
            if (IsNullable)
                return new DateTime?();
            throw new InvalidCastException("Cannot cast DBNull.Value to type 'System.DateTime'.");
        }

        /// <summary>
        /// Gets the double.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static double GetDouble(this DbDataReader dbDataReader, string name)
        {
            return dbDataReader.GetDouble(name, false).Value;
        }

        /// <summary>
        /// Gets the double.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <param name="IsNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">Cannot cast DBNull.Value to type 'System.Double'.</exception>
        internal static double? GetDouble(this DbDataReader dbDataReader, string name, bool IsNullable)
        {
            int ordinal = dbDataReader.GetOrdinal(name);
            if (!dbDataReader.IsDBNull(ordinal))
                return new double?(dbDataReader.GetDouble(ordinal));
            if (IsNullable)
                return new double?();
            throw new InvalidCastException("Cannot cast DBNull.Value to type 'System.Double'.");
        }

        /// <summary>
        /// Gets the decimal.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static Decimal GetDecimal(this DbDataReader dbDataReader, string name)
        {
            return dbDataReader.GetDecimal(name, false).Value;
        }

        /// <summary>
        /// Gets the decimal.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <param name="IsNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">Cannot cast DBNull.Value to type 'System.Decimal'.</exception>
        internal static Decimal? GetDecimal(this DbDataReader dbDataReader, string name, bool IsNullable)
        {
            int ordinal = dbDataReader.GetOrdinal(name);
            if (!dbDataReader.IsDBNull(ordinal))
                return new Decimal?(dbDataReader.GetDecimal(ordinal));
            if (IsNullable)
                return new Decimal?();
            throw new InvalidCastException("Cannot cast DBNull.Value to type 'System.Decimal'.");
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static string GetString(this DbDataReader dbDataReader, string name)
        {
            int ordinal = dbDataReader.GetOrdinal(name);
            if (dbDataReader.IsDBNull(ordinal))
                return (string)null;
            return dbDataReader.GetString(ordinal);
        }

        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static bool GetBoolean(this DbDataReader dbDataReader, string name)
        {
            return dbDataReader.GetBoolean(name, false).Value;
        }

        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <param name="IsNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">Cannot cast DBNull.Value to type 'System.Boolean'.</exception>
        internal static bool? GetBoolean(this DbDataReader dbDataReader, string name, bool IsNullable)
        {
            int ordinal = dbDataReader.GetOrdinal(name);
            if (!dbDataReader.IsDBNull(ordinal))
                return new bool?(dbDataReader.GetBoolean(ordinal));
            if (IsNullable)
                return new bool?();
            throw new InvalidCastException("Cannot cast DBNull.Value to type 'System.Boolean'.");
        }

        /// <summary>
        /// Gets the byte.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static byte GetByte(this DbDataReader dbDataReader, string name)
        {
            return dbDataReader.GetByte(name, false).Value;
        }

        /// <summary>
        /// Gets the byte.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <param name="IsNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">Cannot cast DBNull.Value to type 'System.Byte'.</exception>
        internal static byte? GetByte(this DbDataReader dbDataReader, string name, bool IsNullable)
        {
            int ordinal = dbDataReader.GetOrdinal(name);
            if (!dbDataReader.IsDBNull(ordinal))
                return new byte?(dbDataReader.GetByte(ordinal));
            if (IsNullable)
                return new byte?();
            throw new InvalidCastException("Cannot cast DBNull.Value to type 'System.Byte'.");
        }

        /// <summary>
        /// Gets the name of the data type.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static string GetDataTypeName(this DbDataReader dbDataReader, string name)
        {
            int ordinal = dbDataReader.GetOrdinal(name);
            return dbDataReader.GetDataTypeName(ordinal);
        }

        /// <summary>
        /// Gets the int16.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static short GetInt16(this DbDataReader dbDataReader, string name)
        {
            return dbDataReader.GetInt16(name, false).Value;
        }

        /// <summary>
        /// Gets the int16.
        /// </summary>
        /// <param name="dReader">The d reader.</param>
        /// <param name="name">The name.</param>
        /// <param name="IsNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">Cannot cast DBNull.Value to type 'System.Int16'.</exception>
        internal static short? GetInt16(this DbDataReader dReader, string name, bool IsNullable)
        {
            int ordinal = dReader.GetOrdinal(name);
            if (!dReader.IsDBNull(ordinal))
                return new short?(dReader.GetInt16(ordinal));
            if (IsNullable)
                return new short?();
            throw new InvalidCastException("Cannot cast DBNull.Value to type 'System.Int16'.");
        }

        /// <summary>
        /// Gets the int32.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static int GetInt32(this DbDataReader dbDataReader, string name)
        {
            return dbDataReader.GetInt32(name, false).Value;
        }

        /// <summary>
        /// Gets the int32.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <param name="IsNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">Cannot cast DBNull.Value to type 'System.Int32'.</exception>
        internal static int? GetInt32(this DbDataReader dbDataReader, string name, bool IsNullable)
        {
            int ordinal = dbDataReader.GetOrdinal(name);
            if (!dbDataReader.IsDBNull(ordinal))
                return new int?(dbDataReader.GetInt32(ordinal));
            if (IsNullable)
                return new int?();
            throw new InvalidCastException("Cannot cast DBNull.Value to type 'System.Int32'.");
        }

        /// <summary>
        /// Gets the int64.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static long GetInt64(this DbDataReader dbDataReader, string name)
        {
            return dbDataReader.GetInt64(name, false).Value;
        }

        internal static long? GetInt64(this DbDataReader dbDataReader, string name, bool IsNullable)
        {
            int ordinal = dbDataReader.GetOrdinal(name);
            if (!dbDataReader.IsDBNull(ordinal))
                return new long?(dbDataReader.GetInt64(ordinal));
            if (IsNullable)
                return new long?();
            throw new InvalidCastException("Cannot cast DBNull.Value to type 'System.Int64'.");
        }

        /// <summary>
        /// Gets the character.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static char GetChar(this DbDataReader dbDataReader, string name)
        {
            return dbDataReader.GetChar(name, false).Value;
        }

        /// <summary>
        /// Gets the character.
        /// </summary>
        /// <param name="dbDataReader">The database data reader.</param>
        /// <param name="name">The name.</param>
        /// <param name="IsNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">Cannot cast DBNull.Value to type 'System.Char'.</exception>
        internal static char? GetChar(this DbDataReader dbDataReader, string name, bool IsNullable)
        {
            int ordinal = dbDataReader.GetOrdinal(name);
            if (!dbDataReader.IsDBNull(ordinal))
                return new char?(dbDataReader.GetChar(ordinal));
            if (IsNullable)
                return new char?();
            throw new InvalidCastException("Cannot cast DBNull.Value to type 'System.Char'.");
        }

        /// <summary>
        /// Gets the float.
        /// </summary>
        /// <param name="dReader">The d reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static float GetFloat(this DbDataReader dReader, string name)
        {
            return dReader.GetFloat(name, false).Value;
        }

        /// <summary>
        /// Gets the float.
        /// </summary>
        /// <param name="dReader">The d reader.</param>
        /// <param name="name">The name.</param>
        /// <param name="IsNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">Cannot cast DBNull.Value to type 'System.Single'.</exception>
        internal static float? GetFloat(this DbDataReader dReader, string name, bool IsNullable)
        {
            int ordinal = dReader.GetOrdinal(name);
            if (!dReader.IsDBNull(ordinal))
                return new float?(dReader.GetFloat(ordinal));
            if (IsNullable)
                return new float?();
            throw new InvalidCastException("Cannot cast DBNull.Value to type 'System.Single'.");
        }

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <param name="dReader">The d reader.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static Guid GetGuid(this DbDataReader dReader, string name)
        {
            return dReader.GetGuid(name, false).Value;
        }

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <param name="dReader">The d reader.</param>
        /// <param name="name">The name.</param>
        /// <param name="IsNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Cannot cast DBNull.Value to type 'System.Guid'.</exception>
        internal static Guid? GetGuid(this DbDataReader dReader, string name, bool IsNullable)
        {
            int ordinal = dReader.GetOrdinal(name);
            if (!dReader.IsDBNull(ordinal))
                return new Guid?(dReader.GetGuid(ordinal));
            if (IsNullable)
                return new Guid?();
            throw new Exception("Cannot cast DBNull.Value to type 'System.Guid'.");
        }
    }
}
