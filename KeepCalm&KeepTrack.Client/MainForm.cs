using KeepCalm_KeepTrack.Database;
using KeepCalm_KeepTrack.Database.Entities;

namespace KeepCalm_KeepTrack.Client
{
    public partial class MainForm : Form
    {
        private const string PROJECT_TITLE = "PROJECTS";
        private const string TASK_TITLE = "TASKS";
        private const string TIME_FRAME_TITLE = "TIME FRAMES";

        public readonly SqlDatabase Db;

        public DataLayoutState DataLayoutState;
        public int selectedProjectId;

        public MainForm()
        {
            InitializeComponent();

            Db = new SqlDatabase();
        }

        private void OnAddTimeFrameButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnAddTaskButtonClicked(object sender, EventArgs e)
        {
            AddTaskForm addTaskForm = new AddTaskForm(this);
            addTaskForm.ShowDialog();
        }

        private void OnAddProjectButtonClicked(object sender, EventArgs e)
        {
            AddProjectForm addProjectForm = new AddProjectForm(this);
            addProjectForm.ShowDialog();
        }

        private void OnMainFormLoaded(object sender, EventArgs e)
        {
            UpdateProjectUI();
        }

        public void UpdateTaskUI(int projectId)
        {
            List<TaskEntity>? taskList = Db.GetTaskListForProjectWithId(projectId);
            if (taskList == null || taskList.Count <= 0)
            {
                return;
            }

            dataLayout.Controls.Clear();

            foreach (TaskEntity task in taskList)
            {
                Button taskButton = ButtonFactory.CreateButton(task);

                taskButton.Tag = task.TaskId;
                taskButton.Text = task.TaskName;
                buttonsTooltip.SetToolTip(taskButton, task.TaskDescription);

                taskButton.Click += OnTaskButtonClicked;

                dataLayout.Controls.Add(taskButton);
            }

            selectedProjectId = projectId;
            DataLayoutState = DataLayoutState.TASK;
            titleLabel.Text = TASK_TITLE;
        }

        private void OnTaskButtonClicked(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void UpdateProjectUI()
        {
            List<ProjectEntity>? projectList = Db.GetProjectList();
            if (projectList == null || projectList.Count <= 0)
            {
                return;
            }

            dataLayout.Controls.Clear();

            foreach (ProjectEntity project in projectList)
            {
                Button projectButton = ButtonFactory.CreateButton(project);

                projectButton.Tag = project.ProjectId;
                projectButton.Text = project.ProjectName;
                buttonsTooltip.SetToolTip(projectButton, project.ProjectDescription);

                projectButton.Click += OnProjectButtonClicked;

                dataLayout.Controls.Add(projectButton);
            }

            selectedProjectId = -1;
            DataLayoutState = DataLayoutState.PROJECT;
            titleLabel.Text = PROJECT_TITLE;
        }

        private void OnProjectButtonClicked(object? sender, EventArgs e)
        {
            Button? button = sender as Button;
            if (button == null)
            {
                return;
            }

            if (button.Tag == null)
            {
                return;
            }

            if (!int.TryParse(button.Tag.ToString(), out int projectId))
            {
                return;
            }

            UpdateTaskUI(projectId);
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            switch (DataLayoutState)
            {
                case DataLayoutState.PROJECT:
                    break;
                case DataLayoutState.TASK:
                    UpdateProjectUI();
                    break;
                case DataLayoutState.TIME_FRAME:
                    UpdateTaskUI(selectedProjectId);
                    break;
            }
        }
    }
}
