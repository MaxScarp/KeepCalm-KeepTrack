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

        public List<TimeFrameEntity>? GetTimeFrameListForTaskWithId(int taskId)
        {
            if (dbFactory == null) return null;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                return [.. db.TimeFrameTable.Where(tf => tf.TaskId == taskId)];
            }
        }

        public async Task<TimeFrameEntity?> AddEmptyTimeFrameAsync(int taskId)
        {
            if (dbFactory == null) return null;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                TimeFrameEntity timeFrame = new TimeFrameEntity()
                {
                    TimeFrameStart = DateTime.MinValue,
                    TimeFrameEnd = DateTime.MinValue,
                    TimeFrameTime = TimeSpan.MinValue,
                    TaskId = taskId
                };

                await db.TimeFrameTable.AddAsync(timeFrame);

                await db.SaveChangesAsync();

                return timeFrame;
            }
        }

        public async Task<TaskEntity?> GetTaskWithIdAsync(int taskId)
        {
            if (dbFactory == null) return null;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                return await db.TaskTable.FindAsync(taskId);
            }
        }

        public async Task AddTaskAsync(string taskName, string taskDescription, int projectId)
        {
            if (dbFactory == null) return;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                TaskEntity task = new TaskEntity()
                {
                    ProjectId = projectId,
                    TaskName = taskName,
                    TaskDescription = taskDescription
                };

                await db.TaskTable.AddAsync(task);

                await db.SaveChangesAsync();
            }
        }

        public List<TaskEntity>? GetTaskListForProjectWithId(int projectId)
        {
            if (dbFactory == null) return null;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                return [.. db.TaskTable.Where(t => t.ProjectId == projectId)];
            }
        }

        public List<ProjectEntity>? GetProjectList()
        {
            if (dbFactory == null) return null;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                return [.. db.ProjectTable];
            }
        }

        public async Task AddProjectAsync(string projectName, string projectDescription)
        {
            if (dbFactory == null) return;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                ProjectEntity project = new ProjectEntity()
                {
                    ProjectName = projectName,
                    ProjectDescription = projectDescription
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
        #endregion
    }
}
