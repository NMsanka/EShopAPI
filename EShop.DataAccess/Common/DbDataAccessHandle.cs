using EShop.Data.Common.Helpers;
using EShop.Data.Common.Parameters;
using EShop.Data.Common.Utilties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace EShop.Data.Common
{
    public abstract class DbDataAccessHandle
    {
        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public DbConnection Connection { get; set; }

        /// <summary>
        /// Gets or sets the factory.
        /// </summary>
        /// <value>
        /// The factory.
        /// </value>
        protected DbProviderFactory Factory { get; set; }

        /// <summary>
        /// Gets or sets the client helper.
        /// </summary>
        /// <value>
        /// The client helper.
        /// </value>
        protected DbClientHelper ClientHelper { get; set; }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        internal abstract int ExecuteNonQuery(DbSqlStructure structure);

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal abstract int ExecuteNonQuery(DbSqlStructure structure, List<DbInputParameter> parameters);

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="hasOutputValue">if set to <c>true</c> [has output value].</param>
        /// <param name="outparametername">The outparametername.</param>
        /// <returns></returns>
        internal abstract int ExecuteNonQuery(DbSqlStructure structure, List<DbInputParameter> parameters, bool hasOutputValue, string outparametername);

        /// <summary>
        /// Gets the one value.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal abstract object GetOneValue(DbSqlStructure structure, List<DbInputParameter> parameters);

        /// <summary>
        /// Gets the one value.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        internal abstract object GetOneValue(DbSqlStructure structure);

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal abstract DbDataReader ExecuteQuery(DbSqlStructure structure, List<DbInputParameter> parameters);

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        internal abstract DbDataReader ExecuteQuery(DbSqlStructure structure);

        /// <summary>
        /// Executes the bulk.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="dataTable">The data table.</param>
        internal abstract void ExecuteBulk(string table, DataTable dataTable);

        /// <summary>
        /// Executes the report query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        internal virtual DbDataAdapter ExecuteReportQuery(DbSqlStructure structure)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes the report query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        internal virtual DbDataAdapter ExecuteReportQuery(DbSqlStructure structure, List<DbInputParameter> parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes the disconnected.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        internal virtual DataTable ExecuteDisconnected(DbSqlStructure structure, List<DbInputParameter> parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes the disconnected.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        internal virtual DataTable ExecuteDisconnected(DbSqlStructure structure)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        internal virtual void Commit()
        {

        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        internal virtual void Rollback()
        {

        }

        /// <summary>
        /// Ends this instance.
        /// </summary>
        internal virtual void End()
        {

        }
    }
}
