using KeepCalm_KeepTrack.Database.Entities;

namespace KeepCalm_KeepTrack.Database
{
    public class SqlDatabase
    {
        private ApplicationDbContextFactory? dbFactory;

        public SqlDatabase()
        {
            dbFactory = new ApplicationDbContextFactory();
        }

        public async Task AddProjectAsync(string projectName, string projectDescription)
        {
            if (dbFactory == null) return;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                ProjectEntity project = new ProjectEntity()
                {
                    ProjectName = projectName,
                    ProjectDescription = projectDescription,
                    TaskEntityList = new List<TaskEntity>()
                };

                await db.ProjectTable.AddAsync(project);

                await db.SaveChangesAsync();
            }
        }

        #region "DEBUG"
        public async Task AddTestTimeFrame()
        {
            if (dbFactory == null) return;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                TaskEntity? task = await db.TaskTable.FindAsync(1);
                if (task == null)
                {
                    return;
                }

                DateTime startTime = DateTime.Now;
                DateTime endTime = DateTime.Now.AddSeconds(120);
                TimeSpan totalTime = endTime - startTime;

                TimeFrameEntity timeFrame = new TimeFrameEntity()
                {
                    TaskEntity = task,
                    TaskId = task.ProjectId,
                    TimeFrameStart = startTime,
                    TimeFrameEnd = endTime,
                    TimeFrameTime = totalTime
                };

                await db.TimeFrameTable.AddAsync(timeFrame);

                await db.SaveChangesAsync();
            }
        }

        public async Task AddTestTask()
        {
            if (dbFactory == null) return;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                ProjectEntity? project = await db.ProjectTable.FindAsync(1);
                if (project == null)
                {
                    return;
                }

                TaskEntity task = new TaskEntity()
                {
                    ProjectEntity = project,
                    ProjectId = project.ProjectId,
                    TaskName = "Test Name",
                    TaskDescription = "Test description",
                    TimeFrameEntityList = new List<TimeFrameEntity>()
                };

                await db.TaskTable.AddAsync(task);

                await db.SaveChangesAsync();
            }
        }

        public async Task AddTestProject()
        {
            if (dbFactory == null) return;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                ProjectEntity project = new ProjectEntity()
                {
                    ProjectName = "Test Name",
                    ProjectDescription = "Test description",
                    TaskEntityList = new List<TaskEntity>()
                };

                await db.ProjectTable.AddAsync(project);

                await db.SaveChangesAsync();
            }
        }
        #endregion
    }
}
