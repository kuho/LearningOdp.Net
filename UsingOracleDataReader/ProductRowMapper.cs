using System;
using System.Data;
using UsingOracleDataReader.Framework.Entity;

namespace UsingOracleDataReader
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Remarks { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Price: {2}, Remarks: {3}", Id, Name, Price, Remarks);
        }
    }

    /// <summary>
    /// RowMapper for User.
    /// </summary>
    public class ProductRowMapper : EntityRowMapper<Product>
    {
        /// <summary>
        /// Creates a new entity from data of a reader.
        /// </summary>
        /// <param name="reader">Reader with data.</param>
        /// <param name="rowNumber">Row number to use.</param>
        /// <returns>Created instance of entity.</returns>
        public override Product MapRow(IDataReader reader, int rowNumber)
        {
            var entity = new Product();
            entity.Id = reader["ID"] == DBNull.Value ? string.Empty : reader["ID"].ToString();
            entity.Name = reader["Name"] == DBNull.Value ? string.Empty : reader["Name"].ToString();
            entity.Price = reader["Price"] == DBNull.Value ? 0.0m : decimal.Parse(reader["Price"].ToString());
            entity.Remarks = reader["Remarks"] == DBNull.Value ? string.Empty : reader["Remarks"].ToString();
            return entity;
        }
    }
}