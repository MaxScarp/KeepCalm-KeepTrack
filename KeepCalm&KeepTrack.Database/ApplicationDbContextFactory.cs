using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KeepCalm_KeepTrack.Database
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private const string ENVIRONMENT_VARIABLE = "KEEP_KALM_DB_CONNECTION_STRING";

        public ApplicationDbContext CreateDbContext(string[]? args = null)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            //DEBUG - DELETE this once finished the project
            string? connectionString = Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE);
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("SOMETHING WENT WRONG WITH ENVIRONMENT VARIABLE!");
            }

            optionsBuilder.UseSqlServer(connectionString);

            //optionsBuilder.UseSqlServer(ConfigurationHelper.GetConnectionString(DB_CONNECTION_STRING_NAME))
            //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
