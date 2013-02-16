using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace UsingOracleDataReader.Framework
{
    /// <summary>
    /// Class containing various helper methods for accessing data.
    /// </summary>
    public static class DBQuery
    {

        #region Public execute with row mapping methods
        /// <summary>
        /// Executes the rowmapper with a single input parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbHelper"></param>
        /// <param name="commandText">Store procedure name. E.g. "Posts_GetPostsByUser</param>
        /// <param name="commandType">StoredProcedure</param>
        /// <param name="rowMapper">The mapper that maps a record to an object.</param>
        /// <param name="paramName">E.g. "userName"</param>
        /// <param name="paramType">string</param>
        /// <param name="paramValue">user001</param>
        /// <returns></returns>
        public static IList<T> Query<T>(this IDBHelper dbHelper, string commandText, CommandType commandType, string paramName, DbType paramType, object paramValue, IRowMapper<IDataReader, T> rowMapper)
        {
            DbParameter parameter = dbHelper.BuildInParam(paramName, paramType, paramValue);
            return Query<T>(dbHelper, commandText, commandType, new DbParameter[1] { parameter }, rowMapper);
        }


        /// <summary>
        /// Executes the rowmapper with a single input parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbHelper">Database helper</param>
        /// <param name="commandText">Store procedure name. E.g. "Posts_GetPostsByUser</param>
        /// <param name="commandType">StoredProcedure</param>
        /// <param name="rowMapper">The mapper that maps a record to an object.</param>
        /// <returns></returns>
        public static IList<T> QueryNoParams<T>(this IDBHelper dbHelper, string commandText, CommandType commandType, IRowMapper<IDataReader, T> rowMapper)
        {
            return Query<T>(dbHelper, commandText, commandType, null, rowMapper);
        }


        /// <summary>
        /// Executes the rowmappers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbHelper">Database helper</param>
        /// <param name="commandText">Store procedure name. E.g. "Posts_GetPostsByUser</param>
        /// <param name="commandType">StoredProcedure</param>       
        /// <param name="rowMapper">The mapper that maps a record to an object.</param>
        /// <param name="dbParameters">Array of parameters for the query.</param>
        /// <returns></returns>
        public static IList<T> Query<T>(this IDBHelper dbHelper, string commandText, CommandType commandType, DbParameter[] dbParameters, IRowMapper<IDataReader, T> rowMapper)
        {
            DbCommand command = dbHelper.BuildCommand(commandText, commandType, dbParameters);

            IList<T> items = null;

            using (command.Connection)
            {
                command.Connection.Open();
                IDataReader reader = command.ExecuteReader();

                // Map the workshops.
                items = rowMapper.MapRows(reader);

                reader.Close();
                command.Dispose();
            }
            return items;
        }


        /// <summary>
        /// Executes the rowmapper and get a single output parameter result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TOutputParam"></typeparam>
        /// <param name="dbHelper">Database helper</param>
        /// <param name="commandText">Store procedure name. E.g. "Posts_GetPostsByUser</param>
        /// <param name="commandType">StoredProcedure</param>
        /// <param name="rowMapper">The mapper that maps a record to an object.</param>
        /// <param name="dbParameters">Array of parameters for the query</param>
        /// <param name="outputParamName">The name of the output parameter</param>
        /// <returns></returns>
        public static Tuple2<IList<T>, TOutputParam> Query<T, TOutputParam>(this IDBHelper dbHelper, string commandText, CommandType commandType, DbParameter[] dbParameters,
            IRowMapper<IDataReader, T> rowMapper, string outputParamName)
        {
            Tuple2<IList<T>, IDictionary<string, object>> result = Query<T>(dbHelper, commandText, commandType, dbParameters, rowMapper, new string[] { outputParamName });
            return new Tuple2<IList<T>, TOutputParam>(result.First, (TOutputParam)result.Second[outputParamName]);
        }


        /// <summary>
        /// Executes the rowmapper and get multiple output parameter results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbHelper"></param>
        /// <param name="commandText">Store procedure name. E.g. "Posts_GetPostsByUser</param>
        /// <param name="commandType">StoredProcedure</param>
        /// <param name="rowMapper">The mapper that maps a record to an object.</param>
        /// <param name="dbParameters">Array of parameters for the query</param>
        /// <param name="outputParamNames">Array of output parameter names.</param>
        /// <returns></returns>
        public static Tuple2<IList<T>, IDictionary<string, object>> Query<T>(this IDBHelper dbHelper, string commandText, CommandType commandType, DbParameter[] dbParameters,
            IRowMapper<IDataReader, T> rowMapper, string[] outputParamNames)
        {
            DbCommand command = dbHelper.BuildCommand(commandText, CommandType.StoredProcedure, dbParameters);

            IList<T> items = null;
            IDictionary<string, object> paramResults = new Dictionary<string, object>();

            using (command.Connection)
            {
                command.Connection.Open();
                IDataReader reader = command.ExecuteReader();

                // Map the workshops.
                items = rowMapper.MapRows(reader);

                // NOTE: Must close reader to get output params.                
                reader.Close();

                // Now get all the output parameters.
                if (outputParamNames != null && outputParamNames.Length > 0)
                {
                    foreach (string outputParamName in outputParamNames)
                    {
                        object paramResult = command.Parameters[outputParamName].Value;
                        paramResults[outputParamName] = paramResult;
                    }
                }
                command.Dispose();
            }
            return new Tuple2<IList<T>, IDictionary<string, object>>(items, paramResults);
        }
        #endregion
    }

    /// <summary>
    /// This structure can be used to hold
    /// a tuple of two different types of objects.
    /// </summary>
    /// <typeparam name="T1">Type of first object.</typeparam>
    /// <typeparam name="T2">Type of second object.</typeparam>
    public struct Tuple2<T1, T2>
    {
        private readonly T1 _first;
        /// <summary>
        /// The first item of the tuple
        /// </summary>
        public T1 First
        {
            get { return _first; }
        }


        private readonly T2 _second;
        /// <summary>
        /// The second item of the tuple
        /// </summary>
        public T2 Second
        {
            get { return _second; }
        }


        /// <summary>
        /// Initialize the tuple items.
        /// </summary>
        /// <param name="first">First item of tuple.</param>
        /// <param name="second">Second item of tuple.</param>
        public Tuple2(T1 first, T2 second)
        {
            _first = first;
            _second = second;
        }
    }
}