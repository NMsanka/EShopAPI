using EShop.Data.Common.Helpers;
using EShop.Data.Common.Parameters;
using EShop.Data.Common.Utilties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace EShop.Data.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="EShop.Data.Common.DbDataAccessHandle" />
    internal class DbDataServiceHandle : DbDataAccessHandle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbDataServiceHandle"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="provider">The provider.</param>
        internal DbDataServiceHandle(string connectionString, string provider)
        {
            Factory = DbProviderFactories.GetFactory(provider);
            Connection = this.Factory.CreateConnection();
            Connection.ConnectionString = connectionString;
            SetDbClient(provider);
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        internal override DbDataReader ExecuteQuery(DbSqlStructure structure)
        {
            DbCommand command = null;
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                return ClientHelper.ExecuteQueryCommand(command, null, CommandBehavior.CloseConnection);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
            }
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal override DbDataReader ExecuteQuery(DbSqlStructure structure, List<DbInputParameter> parameters)
        {
            DbCommand command = null;
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                return ClientHelper.ExecuteQueryCommand(command, parameters, CommandBehavior.CloseConnection);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
            }
        }

        /// <summary>
        /// Executes the report query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        internal override DbDataAdapter ExecuteReportQuery(DbSqlStructure structure)
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DbCommand command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                DbDataAdapter dataAdapter = Factory.CreateDataAdapter();
                dataAdapter.SelectCommand = command;
                return dataAdapter;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Executes the report query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal override DbDataAdapter ExecuteReportQuery(DbSqlStructure structure, List<DbInputParameter> parameters)
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DbCommand command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                ClientHelper.AttachParameters(command, parameters);
                DbDataAdapter dataAdapter = Factory.CreateDataAdapter();
                dataAdapter.SelectCommand = command;
                return dataAdapter;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        internal override int ExecuteNonQuery(DbSqlStructure structure)
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DbCommand command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                return ClientHelper.ExecuteNonQueryCommand(command, null);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal override int ExecuteNonQuery(DbSqlStructure structure, List<DbInputParameter> parameters)
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DbCommand command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                return ClientHelper.ExecuteNonQueryCommand(command, parameters);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="hasOutputValue">if set to <c>true</c> [has output value].</param>
        /// <param name="outparametername">The outparametername.</param>
        /// <returns></returns>
        internal override int ExecuteNonQuery(DbSqlStructure structure, List<DbInputParameter> parameters, bool hasOutputValue, string outparametername)
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DbCommand command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                int num = ClientHelper.ExecuteNonQueryCommand(command, parameters);
                if (hasOutputValue && command.Parameters.Contains(outparametername))
                    num = int.Parse(command.Parameters[outparametername].Value.ToString());
                return num;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Gets the one value.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        internal override object GetOneValue(DbSqlStructure structure)
        {
            DbCommand command = null;
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                object obj = ClientHelper.ExecuteScalarCommand(command);
                if (obj != null && obj != DBNull.Value)
                    return obj;
                return null;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (Connection != null)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Gets the one value.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal override object GetOneValue(DbSqlStructure structure, List<DbInputParameter> parameters)
        {
            DbCommand command = null;
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                object obj = ClientHelper.ExecuteScalarCommand(command, parameters);
                if (obj != null && obj != DBNull.Value)
                    return obj;
                return null;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (Connection != null)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Executes the disconnected.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal override DataTable ExecuteDisconnected(DbSqlStructure structure, List<DbInputParameter> parameters)
        {
            DbDataAdapter dbDataAdapter = (DbDataAdapter)null;
            DataTable dataTable = new DataTable();
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DbCommand command = this.Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                ClientHelper.AttachParameters(command, parameters);
                dbDataAdapter = this.Factory.CreateDataAdapter();
                dbDataAdapter.SelectCommand = command;
                dbDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (dbDataAdapter != null)
                    dbDataAdapter.Dispose();
                if (Connection != null)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Executes the disconnected.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        internal override DataTable ExecuteDisconnected(DbSqlStructure structure)
        {
            DbDataAdapter dbDataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DbCommand command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                dbDataAdapter = Factory.CreateDataAdapter();
                dbDataAdapter.SelectCommand = command;
                dbDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (dbDataAdapter != null)
                    dbDataAdapter.Dispose();
                if (Connection != null)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Executes the bulk.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="dataTable">The data table.</param>
        internal override void ExecuteBulk(string table, DataTable dataTable)
        {
            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(Connection as SqlConnection, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null)
            {
                DestinationTableName = table
            };
            Connection.Open();

            sqlBulkCopy.WriteToServer(dataTable);
            Connection.Close();
        }

        /// <summary>
        /// Sets the database client.
        /// </summary>
        /// <param name="provider">The provider.</param>
        private void SetDbClient(string provider)
        {
            switch (provider)
            {
                case "System.Data.SqlClient":
                    ClientHelper = new SqlClientHelper();
                    break;
                default:
                    ClientHelper = new GenricClientHelper();
                    break;
            }
        }
    }
}
