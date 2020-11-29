using System.Data;

namespace EShop.Data.Common.Utilties
{
    internal class DbSqlStructure
    {
        private CommandType sqlType = CommandType.Text;
        private DbProviderType providerType = DbProviderType.Generic;

        internal string Sql { get; set; }

        internal CommandType SqlType
        {
            get
            {
                return sqlType;
            }
            set
            {
                sqlType = value;
            }
        }

        internal DbProviderType ProviderType
        {
            get
            {
                return providerType;
            }
            set
            {
                providerType = value;
            }
        }

        internal DbSqlStructure Format(params object[] args)
        {
            Sql = string.Format(Sql, args);
            return this;
        }
    }
}
