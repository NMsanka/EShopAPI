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
    public class DbDataTransactionHandle : DbDataAccessHandle
    {
        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        /// <value>
        /// The transaction.
        /// </value>
        private DbTransaction Transaction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbDataTransactionHandle"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="provider">The provider.</param>
        public DbDataTransactionHandle(string connectionString, string provider)
        {
            Factory = DbProviderFactories.GetFactory(provider);
            Connection = this.Factory.CreateConnection();
            Connection.ConnectionString = connectionString;
            SetDbClient(provider);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbDataTransactionHandle"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="provider">The provider.</param>
        public DbDataTransactionHandle(DbConnection connection, DbTransaction transaction, string provider)
        {
            Connection = connection;
            Transaction = transaction;
            SetDbClient(provider);
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
                DbCommand command = this.Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.Transaction = this.Transaction;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                return this.ClientHelper.ExecuteNonQueryCommand(command, (List<DbInputParameter>)null);
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
                command.Transaction = Transaction;
                command.CommandTimeout = 0;
                return ClientHelper.ExecuteNonQueryCommand(command, parameters);
            }
            catch
            {
                throw;
            }
            finally
            {
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
                command.Transaction = Transaction;
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
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DbCommand command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.Transaction = Transaction;
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
            }
        }

        /// <summary>
        /// Gets the one value.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        internal override object GetOneValue(DbSqlStructure structure)
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DbCommand command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.CommandType = structure.SqlType;
                command.Transaction = Transaction;
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
            }
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
                command.Transaction = Transaction;
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
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DbCommand command = Connection.CreateCommand();
                command.CommandText = structure.Sql;
                command.Transaction = Transaction;
                command.CommandType = structure.SqlType;
                command.CommandTimeout = 0;
                return ClientHelper.ExecuteQueryCommand(command, parameters, CommandBehavior.Default);
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        internal override void Commit()
        {
            if (Transaction == null)
                return;
            Transaction.Commit();
        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        internal override void Rollback()
        {
            if (Transaction == null)
                return;
            Transaction.Rollback();
        }

        /// <summary>
        /// Ends this instance.
        /// </summary>
        internal override void End()
        {
            if (Connection.State != ConnectionState.Open)
                return;
            Connection.Close();
        }

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
