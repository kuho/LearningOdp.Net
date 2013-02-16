using System.Data;
using System.Data.Common;

namespace UsingOracleDataReader.Framework
{
    /// <summary>
    /// Class containing various helper methods for accessing data.
    /// </summary>
    public static class DbBuilder
    {

        #region Command builder
        /// <summary>
        /// Builds a command object with a multiple parameters.
        /// </summary>
        /// <param name="dbHelper"></param>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DbCommand BuildCommand(this IDBHelper dbHelper, string commandText, CommandType commandType, DbParameter[] parameters)
        {
            DbConnection connection = dbHelper.GetConnection();
            DbCommand command = dbHelper.GetCommand(connection, commandText, commandType);
            command.Connection = connection;
            if (parameters != null && parameters.Length > 0)
            {
                command.Parameters.AddRange(parameters);
            }
            return command;
        }


        /// <summary>
        /// Builds a command object with a single parameter.
        /// </summary>
        /// <param name="dbHelper"></param>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="paramName"></param>
        /// <param name="paramType"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        public static DbCommand BuildCommand(this IDBHelper dbHelper, string commandText, CommandType commandType, string paramName, DbType paramType, object paramValue)
        {
            DbConnection connection = dbHelper.GetConnection();
            DbCommand command = dbHelper.GetCommand(connection, commandText, commandType);
            command.Connection = connection;
            command.Parameters.Add(dbHelper.BuildInParam(paramName, paramType, paramValue));
            return command;
        }
        #endregion
    }
}