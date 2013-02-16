using System.Collections.Generic;

namespace UsingOracleDataReader.Framework
{
    /// <summary>
    /// Base class for RowMapping.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IRowMapper<TSource, TResult>
    {
        /// <summary>
        /// Whether or not the callback for after rows mapped is enabled.
        /// </summary>
        bool IsCallbackEnabledForAfterRowsMapped { get; set; }


        /// <summary>
        /// Maps all the rows in TSource to list objects of type T.
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        IList<TResult> MapRows(TSource dataSource);


        /// <summary>
        /// Maps a specific row to an item of type TResult
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="rowId"></param>
        /// <returns></returns>
        TResult MapRow(TSource dataSource, int rowId);


        /// <summary>
        /// Call back for on after rows have been mapped.
        /// </summary>
        /// <param name="items"></param>
        void OnAfterRowsMapped(IList<TResult> items);
    }
}