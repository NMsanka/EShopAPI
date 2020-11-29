using EShop.Data.Common.Exceptions;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace EShop.Data.Common.Utilties
{
    internal class DbSqlAdapter
    {
        private XDocument QueryContent;

        internal string DbProvider { get; set; }

        internal DbProviderType Provider
        {
            get
            {
                switch (this.DbProvider)
                {
                    case "System.Data.SqlClient":
                        return DbProviderType.SqlServer;
                    case "System.Data.OracleClient":
                        return DbProviderType.Oracle;
                    default:
                        return DbProviderType.Generic;
                }
            }
        }

        internal DbSqlStructure this[string key]
        {
            get
            {
                return GetSqlStructure(key);
            }
        }

        internal DbSqlAdapter(string fileName, string dbProvider)
        {
            this.DbProvider = dbProvider;
            Stream manifestResourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream(fileName);
            this.LoadSqlResource(fileName, manifestResourceStream);
        }

        internal DbSqlAdapter(string fileName)
        {
            Stream manifestResourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream(fileName);
            LoadSqlResource(fileName, manifestResourceStream);
        }

        private DbSqlStructure GetSqlStructure(string key)
        {
            XElement xelement = this.QueryContent.Descendants((XName)"Query").FirstOrDefault<XElement>((Func<XElement, bool>)(s => s.Attribute((XName)"id").Value.Equals(key)));
            if (xelement == null)
                throw new DataAccessException("Cannot find the specified SQL id");
            DbSqlStructure dbSqlStructure = new DbSqlStructure();
            if (!string.IsNullOrWhiteSpace(xelement.Element((XName)this.Provider.ToString()).Value))
            {
                dbSqlStructure.Sql = xelement.Element((XName)this.Provider.ToString()).Value.Trim();
                dbSqlStructure.SqlType = (CommandType)Enum.Parse(typeof(CommandType), xelement.Element((XName)this.Provider.ToString()).Attribute((XName)"commandType").Value);
            }
            else
            {
                dbSqlStructure.Sql = xelement.Element((XName)DbProviderType.Generic.ToString()).Value.Trim();
                dbSqlStructure.SqlType = (CommandType)Enum.Parse(typeof(CommandType), xelement.Element((XName)"Generic").Attribute((XName)"commandType").Value);
            }
            dbSqlStructure.ProviderType = Provider;
            if (Provider == DbProviderType.Oracle)
                dbSqlStructure.Sql = dbSqlStructure.Sql.Replace('@', ':');
            return dbSqlStructure;
        }

        private void LoadSqlResource(string fileName, Stream stream)
        {
            if (stream == null)
                throw new DataAccessException("Cannot find the specified SQL structure file");
            this.QueryContent = XDocument.Load(stream);
        }
    }
}
