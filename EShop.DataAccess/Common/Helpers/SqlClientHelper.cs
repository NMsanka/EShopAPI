using EShop.Data.Common.Parameters;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace EShop.Data.Common.Helpers
{
    internal class SqlClientHelper : DbClientHelper
    {
        /// <summary>
        /// Executes the query command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns></returns>
        internal override DbDataReader ExecuteQueryCommand(DbCommand command, List<DbInputParameter> parameters, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            return base.ExecuteQueryCommand(command, parameters, commandBehavior);
        }

        /// <summary>
        /// Executes the non query command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal override int ExecuteNonQueryCommand(DbCommand command, List<DbInputParameter> parameters)
        {
            return base.ExecuteNonQueryCommand(command, parameters);
        }

        /// <summary>
        /// Executes the scalar command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal override object ExecuteScalarCommand(DbCommand command, List<DbInputParameter> parameters)
        {
            return base.ExecuteScalarCommand(command, parameters);
        }

        /// <summary>
        /// Attaches the parameters.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        internal override void AttachParameters(DbCommand command, List<DbInputParameter> parameters)
        {
            base.AttachParameters(command, parameters);
        }
    }
}