using Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Tests.Utility
{
    public class DbContextFactory
    {
        public static ApplicationDbContext CreateContext(SqliteConnection db)
        {
            DbContextOptions<ApplicationDbContext> options = GetOptionsSqlLite(db);
            return new ApplicationDbContext(options);
        }

        public static DbContextOptions<ApplicationDbContext> GetOptionsSqlLite(SqliteConnection connection)
        {
            var loggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseSqlite(connection)
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .Options;

            return options;
        }
    }
}