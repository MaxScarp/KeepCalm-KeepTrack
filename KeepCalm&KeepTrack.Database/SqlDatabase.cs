﻿using KeepCalm_KeepTrack.Database.Entities;

namespace KeepCalm_KeepTrack.Database
{
    public class SqlDatabase
    {
        private ApplicationDbContextFactory? dbFactory;

        public SqlDatabase()
        {
            dbFactory = new ApplicationDbContextFactory();
        }

        private async Task<ProjectEntity?> GetProjectWithId(int projectId)
        {
            if (dbFactory == null) return null;

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                return await db.ProjectTable.FindAsync(projectId);
            }
        }

        public async Task AddTaskAsync(string taskName, string taskDescription, int projectId)
        {
            if (dbFactory == null) return;

            ProjectEntity? project = await GetProjectWithId(projectId);
            if (project == null)
            {
                return;
            }

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                TaskEntity task = new TaskEntity()
                {
                    ProjectEntity = project,
                    ProjectId = project.ProjectId,
                    TaskName = taskName,
                    TaskDescription = taskDescription,
                    TimeFrameEntityList = new List<TimeFrameEntity>()
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
        #endregion
    }
}
