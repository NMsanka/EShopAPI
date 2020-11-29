using CommercePromote.Data.Common.Helpers;
using CommercePromote.Data.Common.Parameters;
using CommercePromote.Data.Common.Utilties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CommercePromote.Data.Common
{
    internal class DbTransactionHandle : DbDataAccessHandle
    {
        private DbTransaction Transaction { get; set; }

        internal DbTransactionHandle(string connectionString, string provider)
        {
            Factory = DbProviderFactories.GetFactory(provider);
            Connection = this.Factory.CreateConnection();
            Connection.ConnectionString = connectionString;
            SetDbClient(provider);
        }

        internal DbTransactionHandle(DbConnection connection, DbTransaction transaction, string provider)
        {
            Connection = connection;
            Transaction = transaction;
            SetDbClient(provider);
        }

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

        internal override void Commit()
        {
            if (Transaction == null)
                return;
            Transaction.Commit();
        }

        internal override void Rollback()
        {
            if (Transaction == null)
                return;
            Transaction.Rollback();
        }

        internal override void End()
        {
            if (Connection.State != ConnectionState.Open)
                return;
            Connection.Close();
        }

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
