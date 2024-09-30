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

        public async Task<bool> UpdateTimeFrame(TimeFrameEntity timeFrame)
        {
            if (dbFactory == null) return false;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                timeFrame.TimeFrameEnd = DateTime.Now;
                timeFrame.TimeFrameTime = timeFrame.TimeFrameEnd - timeFrame.TimeFrameStart;

                db.TimeFrameTable.Update(timeFrame);

                await db.SaveChangesAsync();

                return true;
            }
        }

        public List<TimeFrameEntity>? GetTimeFrameListForTaskWithId(int taskId)
        {
            if (dbFactory == null) return null;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                return [.. db.TimeFrameTable.Where(tf => tf.TaskId == taskId)];
            }
        }

        public async Task<TimeFrameEntity?> AddTimeFrameAsync(int taskId)
        {
            if (dbFactory == null) return null;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                TimeFrameEntity timeFrame = new TimeFrameEntity()
                {
                    TimeFrameStart = DateTime.Now,
                    TimeFrameEnd = new DateTime(),
                    TimeFrameTime = new TimeSpan(),
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

        public async Task<bool> AddTaskAsync(string taskName, string taskDescription, int projectId)
        {
            if (dbFactory == null) return false;

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

                return true;
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

        public async Task<bool> AddProjectAsync(string projectName, string projectDescription)
        {
            if (dbFactory == null) return false;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                ProjectEntity project = new ProjectEntity()
                {
                    ProjectName = projectName,
                    ProjectDescription = projectDescription
                };

                await db.ProjectTable.AddAsync(project);

                await db.SaveChangesAsync();

                return true;
            }
        }
    }
}
