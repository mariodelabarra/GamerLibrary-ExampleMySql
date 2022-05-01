namespace GamerLibrary.Common.Repository
{
    public class DbOptions
    {
        public const string BaseSettingsKey = "GamerLibrary:Repository:SqlServer";

        /// <summary>
        /// Get the Key of Database Settings that it is defined on each settings files
        /// </summary>
        /// <param name="databaseName">Database name used in settings files</param>
        /// <returns>Formated setting Key</returns>
        public static string GetSettingsKey() => BaseSettingsKey;

        /// <summary>
        /// Get the ConnectionString of the Database Settings that it is defined on each setting file
        /// </summary>
        /// <param name="databaseName">Database name used in settings files</param>
        /// <returns></returns>
        public static string GetConnectionStringSettingsKey(string databaseName) => string.Format("{0}:{1}:{2}", BaseSettingsKey, databaseName, nameof(ConnectionString));

        public string? ConnectionString { get; set; }
        public string? Database { get; set; }
    }
}
