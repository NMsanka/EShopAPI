using System.Collections.Generic;
using System.Data;

namespace EShop.Data.Common.Parameters
{
    internal class DbInputParameterCollection : List<DbInputParameter>
    {
        internal void Add(string name, object value)
        {
            Add(new DbInputParameter(name, value));
        }

        internal void Add(string name, object value, DbType dataType)
        {
            Add(new DbInputParameter(name, dataType, value));
        }

        internal void Add(string name, object value, DbType dataType, ParameterDirection parameterDirection)
        {
            Add(new DbInputParameter(name, dataType, value, parameterDirection));
        }
    }
}
