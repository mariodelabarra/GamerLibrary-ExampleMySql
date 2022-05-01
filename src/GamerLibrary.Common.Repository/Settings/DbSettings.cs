using Microsoft.Extensions.Options;

namespace GamerLibrary.Common.Repository
{
    public interface IDbSettings
    {
        /// <summary>
        /// Gets the connection string of the current database instance
        /// </summary>
        string? ConnectionString { get; }

        /// <summary>
        /// Gets the database name
        /// </summary>
        string? DatabaseName { get; }
    }

    public class DbSettings : IDbSettings
    {
        private readonly IOptions<DbOptions> _options;

        public DbSettings(IOptions<DbOptions> options)
        {
            _options = options;
        }

        /// <inheritdoc/>
        public string? ConnectionString => _options.Value.ConnectionString;


        /// <inheritdoc/>
        public string? DatabaseName => _options.Value.Database;
    }
}
