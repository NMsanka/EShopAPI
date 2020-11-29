using EShop.Data.Common.Parameters;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace EShop.Data.Common.Helpers
{
    public abstract class DbClientHelper
    {
        /// <summary>
        /// Executes the query command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns></returns>
        internal virtual DbDataReader ExecuteQueryCommand(DbCommand command, List<DbInputParameter> parameters, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            this.AttachParameters(command, parameters);
            return command.ExecuteReader(commandBehavior);
        }

        /// <summary>
        /// Executes the non query command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal virtual int ExecuteNonQueryCommand(DbCommand command, List<DbInputParameter> parameters)
        {
            AttachParameters(command, parameters);
            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// Executes the scalar command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal virtual object ExecuteScalarCommand(DbCommand command, List<DbInputParameter> parameters)
        {
            AttachParameters(command, parameters);
            return command.ExecuteScalar();
        }

        /// <summary>
        /// Executes the scalar command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        internal virtual object ExecuteScalarCommand(DbCommand command)
        {
            return command.ExecuteScalar();
        }

        /// <summary>
        /// Attaches the parameters.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        internal virtual void AttachParameters(DbCommand command, List<DbInputParameter> parameters)
        {
            if (parameters == null)
                return;
            foreach (DbInputParameter parameter in parameters)
            {
                DbParameter parameterOut = command.CreateParameter();

                parameterOut.ParameterName = parameter.Name;
                if (parameter.Value == null)
                {
                    parameterOut.DbType = parameter.DataType;
                    parameterOut.Value = System.DBNull.Value;
                }
                else
                {
                    parameterOut.DbType = parameter.DataType;
                    parameterOut.Value = parameter.Value;
                }
                parameterOut.Direction = parameter.ParameterDirection;
                command.Parameters.Add(parameterOut);
            }
        }
    }
}
