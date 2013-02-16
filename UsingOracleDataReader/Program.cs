using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using UsingOracleDataReader.Framework;

namespace UsingOracleDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var oracleConnectionStringBuilder = new OracleConnectionStringBuilder {
                                                                                      DataSource = "localhost/orcl",
                                                                                      UserID = "ed",
                                                                                      Password = "pass123"
                                                                                  };
            var db = new Database(oracleConnectionStringBuilder.ConnectionString, "Oracle.DataAccess.Client");

            try
            {
                var products = db.QueryNoParams("SELECT * FROM PRODUCTS", CommandType.Text, new ProductRowMapper());

                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            try
            {
                var products = db.Query("SELECT * FROM PRODUCTS where id = :id", CommandType.Text, "id", DbType.String, "E1", new ProductRowMapper());
                Console.WriteLine("Filtered by ID = E1");
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                DbParameter idParam = db.BuildInParam("id", DbType.String, "E1");
                DbParameter nameParam = db.BuildInParam("name", DbType.String, "Rear Lights");
                var dbParameters = new[] {idParam, nameParam};

                var products = db.Query<Product>("SELECT * FROM PRODUCTS where id = :id or name = :name", CommandType.Text, dbParameters, new ProductRowMapper());

                Console.WriteLine("Filtered by ID = E1 or Name = Rear Lights");
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }



            var oracleConnection = new OracleConnection(oracleConnectionStringBuilder.ConnectionString);

            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Starting work with Oracle");
                Console.ForegroundColor = ConsoleColor.White;

                oracleConnection.Open();
                var oracleCommand = oracleConnection.CreateCommand();
                oracleCommand.CommandText = "SELECT * FROM PRODUCTS";
                var oracleDataReader = oracleCommand.ExecuteReader();

                if (!oracleDataReader.HasRows)
                    return;

                while (oracleDataReader.Read())
                {
                    var id = oracleDataReader.GetString(oracleDataReader.GetOrdinal("ID"));
                    var name = oracleDataReader.GetString(oracleDataReader.GetOrdinal("Name"));
                    var price = oracleDataReader.GetDecimal(oracleDataReader.GetOrdinal("Price"));
                    var remarks = oracleDataReader.GetString(oracleDataReader.GetOrdinal("Remarks"));

                    Console.WriteLine("ID: {0}, Name: {1}, Price: {2}, Remarks: {3}", id, name, price, remarks);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oracle error: {0}", ex.ToString());
            }
            finally
            {
                oracleConnection.Close();
                oracleConnection.Dispose();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Stopping work with Oracle");
            }

        }
    }
}
