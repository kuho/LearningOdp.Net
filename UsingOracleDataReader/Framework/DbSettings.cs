namespace UsingOracleDataReader.Framework
{
    /// <summary>
    /// This class contains database settings.
    /// </summary>
    public class DbSettings
    {
        /// <summary>
        /// Enable transactions flag.
        /// </summary>
        public bool EnableTransactions = false;


        /// <summary>
        /// String to use when prefixing parameters.
        /// </summary>
        public string ParamPrefix = "@";
    }
}