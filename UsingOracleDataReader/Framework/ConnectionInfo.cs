namespace UsingOracleDataReader.Framework
{
    /// <summary>
    /// Class to encapsulate a connection string.
    /// </summary>
    public class ConnectionInfo
    {
        private readonly string _connectionString;
        private readonly string _providerName;


        /// <summary>
        /// Default instance.
        /// </summary>
        public static readonly ConnectionInfo Empty = new ConnectionInfo(
            "Server=server1;Database=database1;User=user1;Password=password;", "System.Data.SqlClient");


        /// <summary>
        /// Default instance 2.
        /// </summary>
        public static readonly ConnectionInfo Default = new ConnectionInfo(
            "Server=server1;Database=database1;User=user1;Password=password;", "System.Data.SqlClient");


        /// <summary>
        /// Initialize using the connection string.
        /// </summary>
        /// <param name="connectionString"></param>
        public ConnectionInfo(string connectionString)
        {
            _connectionString = connectionString;
            _providerName = "System.Data.SqlClient";
        }


        /// <summary>
        /// Initialize using connection string and provider name.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="providerName"></param>
        public ConnectionInfo(string connectionString, string providerName)
        {
            _connectionString = connectionString;
            _providerName = providerName;
        }


        /// <summary>
        /// Get the connection string.
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
        }


        /// <summary>
        /// THe name of the database provider. e.g. "System.Data.SqlClient"
        /// </summary>
        public string ProviderName
        {
            get { return _providerName; }
        }
    }
}