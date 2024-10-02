using KeepCalm_KeepTrack.Database;
using KeepCalm_KeepTrack.Database.Entities;

namespace KeepCalm_KeepTrack.Client
{
    public partial class ShowTotalTimeForm : Form
    {
        public event EventHandler? OnCustomClosed;

        private const string NO_PROJECTS_FOUND = "NO PROJECTS HAVE BEEN FOUND!";

        private readonly SqlDatabase db;

        public ShowTotalTimeForm(SqlDatabase db)
        {
            InitializeComponent();

            this.db = db;
        }

        private void OnShowTotalTimeFormLoaded(object sender, EventArgs e)
        {
            List<ProjectEntity>? projectList = db.GetProjectList();
            if (projectList == null || projectList.Count <= 0)
            {
                infoLabel.Text = NO_PROJECTS_FOUND;
                return;
            }

            foreach (ProjectEntity project in projectList)
            {
                projectNameComboBox.Items.Add(project.ProjectName);
            }
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            OnCustomClosed?.Invoke(this, EventArgs.Empty);

            Close();
        }

        private void OnShowTotalTimeFormClosing(object sender, FormClosingEventArgs e)
        {
            OnCustomClosed?.Invoke(this, EventArgs.Empty);
        }

        private async void OnProjectNameComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectEntity? project = await GetProjectAsync();
            if (project == null)
            {
                return;
            }

            List<TaskEntity>? taskList = db.GetTaskListForProjectWithId(project.ProjectId);

            List<TimeFrameEntity> timeFrameList = new List<TimeFrameEntity>();
            if (taskList != null && taskList.Count > 0)
            {
                foreach (TaskEntity task in taskList)
                {
                    List<TimeFrameEntity>? timeFrameForTaskList = db.GetTimeFrameListForTaskWithId(task.TaskId);
                    if (timeFrameForTaskList == null || timeFrameForTaskList.Count <= 0)
                    {
                        continue;
                    }

                    timeFrameList.AddRange(timeFrameForTaskList);
                }
            }

            PrintInfo(project, taskList, timeFrameList);
        }

        private void PrintInfo(ProjectEntity project, List<TaskEntity>? taskList, List<TimeFrameEntity> timeFrameList)
        {
            infoLabel.Text = string.Empty;

            infoLabel.Text += $"Project: {project.ProjectName}\n";

            int taskAmount = taskList == null || taskList.Count <= 0 ? 0 : taskList.Count;
            infoLabel.Text += $"Total tasks: {taskAmount}\n";

            if (timeFrameList.Count <= 0)
            {
                infoLabel.Text += "Work is not started yet!";
                return;
            }

            timeFrameList.Sort((tf_x, tf_y) => tf_x.TimeFrameStart.CompareTo(tf_y.TimeFrameStart));

            infoLabel.Text += $"Work started on: {timeFrameList.First().TimeFrameStart.ToShortDateString()}\n";
            infoLabel.Text += $"Work finished on: {timeFrameList.Last().TimeFrameEnd.ToShortDateString()}\n";

            TimeSpan totalTimeWorked = new TimeSpan();
            foreach (TimeFrameEntity timeFrame in timeFrameList)
            {
                totalTimeWorked += timeFrame.TimeFrameEnd - timeFrame.TimeFrameStart;
            }

            int totalHours = totalTimeWorked.Hours;
            int totalMinutes = totalTimeWorked.Minutes;
            int totalSeconds = totalTimeWorked.Seconds;

            infoLabel.Text += $"Time spent on this work: {totalHours}h {totalMinutes}m {totalSeconds}s";
        }

        private async Task<ProjectEntity?> GetProjectAsync()
        {
            if (projectNameComboBox == null)
            {
                return null;
            }

            if (projectNameComboBox.Items == null)
            {
                return null;
            }

            if (projectNameComboBox.SelectedIndex == -1)
            {
                return null;
            }

            string? porjectName = projectNameComboBox.Items[projectNameComboBox.SelectedIndex]?.ToString();
            if (string.IsNullOrWhiteSpace(porjectName))
            {
                return null;
            }

            return await db.GetProjectWithNameAsync(porjectName);
        }
    }
}
