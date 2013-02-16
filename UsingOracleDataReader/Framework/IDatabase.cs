using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace UsingOracleDataReader.Framework
{
    /// <summary>
    /// Backward compatibility.
    /// </summary>
    public interface IDatabase : IDBHelper
    {
    }


    /// <summary>
    /// Interface for a DatabaseHelper
    /// </summary>
    public interface IDBHelper
    {
        /// <summary>
        /// The underlying connection to the datastore.
        /// </summary>
        ConnectionInfo Connection { get; set; }


        /// <summary>
        /// Core method which all the 
        /// 1. ExecuteScalar
        /// 2. ExecuteNonQuery
        /// 3. ExecuteReader
        /// 4. ExecuteDataTable methods call.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="dbParameters"></param>
        /// <param name="useTransaction"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        TResult Execute<TResult>(string commandText, CommandType commandType, DbParameter[] dbParameters, bool useTransaction, Func<DbCommand, TResult> executor);


        /// <summary>
        /// Execute non-query sql.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string commandText, CommandType commandType, params DbParameter[] dbParameters);


        /// <summary>
        /// Execute non-query sql.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        int ExecuteNonQueryText(string commandText, params DbParameter[] dbParameters);


        /// <summary>
        /// Execute non-query sql.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        int ExecuteNonQueryProc(string commandText, params DbParameter[] dbParameters);


        /// <summary>
        /// Execute sql and return datareader.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="action"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        void ExecuteReader(string commandText, CommandType commandType, Action<IDataReader> action, params DbParameter[] dbParameters);


        /// <summary>
        /// Execute sql and return datareader.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="action"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        void ExecuteReaderText(string commandText, Action<IDataReader> action, params DbParameter[] dbParameters);


        /// <summary>
        /// Execute sql and return datareader.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="action"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        void ExecuteReaderProc(string commandText, Action<IDataReader> action, params DbParameter[] dbParameters);


        /// <summary>
        /// Execute sql and return single scalar value.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        object ExecuteScalar(string commandText, CommandType commandType, params DbParameter[] dbParameters);


        /// <summary>
        /// Execute sql and return single scalar value.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        object ExecuteScalarText(string commandText, params DbParameter[] dbParameters);


        /// <summary>
        /// Execute sql and return single scalar value.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        object ExecuteScalarProc(string commandText, params DbParameter[] dbParameters);


        /// <summary>
        /// Build an input parameter.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        DbParameter BuildInParam(string paramName, DbType dbType, object val);


        /// <summary>
        /// Builds the input parameter and adds it to the list of parameters.
        /// </summary>
        /// <param name="parameters">list of parameters to add to after building.</param>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="val"></param>
        void AddInParam(IList<DbParameter> parameters, string paramName, DbType dbType, object val);


        /// <summary>
        /// Build an input parameter.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        DbParameter BuildOutParam(string paramName, DbType dbType);


        /// <summary>
        /// Get the database provider factory that creates con, cmd, params etc.
        /// </summary>
        /// <returns></returns>
        DbProviderFactory GetFactory();


        /// <summary>
        /// Get a connection to the appropriate database.
        /// </summary>
        /// <returns></returns>
        DbConnection GetConnection();


        /// <summary>
        /// Create a new dbcommand using the connection.
        /// </summary>
        /// <param name="con"></param>
        /// <param name="commmandText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        DbCommand GetCommand(DbConnection con, string commmandText, CommandType commandType);
    }
}