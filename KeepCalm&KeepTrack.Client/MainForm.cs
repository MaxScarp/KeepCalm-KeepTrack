using KeepCalm_KeepTrack.Database;
using KeepCalm_KeepTrack.Database.Entities;

namespace KeepCalm_KeepTrack.Client
{
    public partial class MainForm : Form
    {
        private ApplicationDbContextFactory? dbFactory;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnMainFormLoaded(object sender, EventArgs e)
        {
            dbFactory = new ApplicationDbContextFactory();
        }

        private async void OnAddProjectButtonClicked(object sender, EventArgs e)
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

            infoLabel.Text = "PROJECT ADDED TO DB!";
        }

        private async void OnAddTaskButtonClicked(object sender, EventArgs e)
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

            infoLabel.Text = "TASK ADDED TO DB!";
        }

        private async void OnAddTimeFrameButtonClicked(object sender, EventArgs e)
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

            infoLabel.Text = "TIME FRAME ADDED TO DB!";
        }
    }
}
