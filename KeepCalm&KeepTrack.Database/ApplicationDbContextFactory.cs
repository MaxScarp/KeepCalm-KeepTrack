using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace KeepCalm_KeepTrack.Database
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private const string ENVIRONMENT_VARIABLE = "KEEP_KALM_DB_CONNECTION_STRING";
        private const string DB_CONNECTION_STRING_NAME = "default";

        public ApplicationDbContext CreateDbContext(string[]? args = null)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            string? connectionString = Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE);
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                optionsBuilder.UseSqlServer(ConfigurationHelper.GetConnectionString(DB_CONNECTION_STRING_NAME))
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
            }
            else
            {
                optionsBuilder.UseSqlServer(connectionString);
            }

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
