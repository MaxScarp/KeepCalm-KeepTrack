using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace KeepCalm_KeepTrack.Database
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private const string DB_CONNECTION_STRING_NAME = "KeepCalm";

        public ApplicationDbContext CreateDbContext(string[]? args = null)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(ConfigurationHelper.GetConnectionString(DB_CONNECTION_STRING_NAME))
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
