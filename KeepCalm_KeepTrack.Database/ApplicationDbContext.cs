using KeepCalm_KeepTrack.Database.Configs;
using KeepCalm_KeepTrack.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeepCalm_KeepTrack.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ProjectEntity> ProjectTable { get; set; }
        public DbSet<TaskEntity> TaskTable { get; set; }
        public DbSet<TimeFrameEntity> TimeFrameTable { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectEntityConfig());
            modelBuilder.ApplyConfiguration(new TaskEntityConfig());
            modelBuilder.ApplyConfiguration(new TimeFrameEntityConfig());
        }
    }
}
