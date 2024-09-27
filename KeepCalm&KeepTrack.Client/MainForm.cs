using KeepCalm_KeepTrack.Database;
using KeepCalm_KeepTrack.Database.Entities;

namespace KeepCalm_KeepTrack.Client
{
    public partial class MainForm : Form
    {
        private const string PROJECT_TITLE = "PROJECTS";
        private const string TASK_TITLE = "TASKS";
        private const string TIME_FRAME_TITLE = "TIME FRAMES";

        private readonly SqlDatabase db;
        private readonly Dictionary<int, System.Timers.Timer> timeFrameIdTimerDictionary;

        private DataLayoutState dataLayoutState;
        private int selectedProjectId;

        private AddProjectForm? addProjectForm;
        private AddTaskForm? addTaskForm;

        public MainForm()
        {
            InitializeComponent();

            db = new SqlDatabase();
            timeFrameIdTimerDictionary = new Dictionary<int, System.Timers.Timer>();
        }

        private void OnAddTimeFrameButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnAddTaskButtonClicked(object sender, EventArgs e)
        {
            if (selectedProjectId <= -1)
            {
                return;
            }

            addTaskForm = new AddTaskForm(db, selectedProjectId);
            addTaskForm.Show();

            addTaskForm.OnCustomClosed += AddTaskForm_OnCustomClosed;

            Enabled = false;
        }

        private void AddTaskForm_OnCustomClosed(object? sender, EventArgs e)
        {
            if (addTaskForm == null)
            {
                return;
            }

            addTaskForm.OnCustomClosed -= AddTaskForm_OnCustomClosed;

            CheckDataLayoutStateAndUpdateUI();

            addTaskForm = null;

            Enabled = true;
        }

        private void CheckDataLayoutStateAndUpdateUI()
        {
            switch (dataLayoutState)
            {
                case DataLayoutState.PROJECT:
                    UpdateProjectUI();
                    break;
                case DataLayoutState.TASK:
                case DataLayoutState.TIME_FRAME:
                    UpdateTaskUI(selectedProjectId);
                    break;
            }
        }

        private void OnAddProjectButtonClicked(object sender, EventArgs e)
        {
            addProjectForm = new AddProjectForm(db);
            addProjectForm.Show();

            addProjectForm.OnCustomClosed += AddProjectForm_OnCustomClosed;

            Enabled = false;
        }

        private void AddProjectForm_OnCustomClosed(object? sender, EventArgs e)
        {
            if (addProjectForm == null)
            {
                return;
            }

            addProjectForm.OnCustomClosed -= AddProjectForm_OnCustomClosed;

            CheckDataLayoutStateAndUpdateUI();

            addProjectForm = null;

            Enabled = true;
        }

        private void OnMainFormLoaded(object sender, EventArgs e)
        {
            UpdateProjectUI();
        }

        private void UpdateTaskUI(int projectId)
        {
            dataLayout.Controls.Clear();

            selectedProjectId = projectId;
            dataLayoutState = DataLayoutState.TASK;
            titleLabel.Text = TASK_TITLE;

            List<TaskEntity>? taskList = db.GetTaskListForProjectWithId(projectId);
            if (taskList != null || taskList?.Count > 0)
            {
                foreach (TaskEntity task in taskList)
                {
                    Button taskButton = ButtonFactory.CreateButton(task);

                    taskButton.Tag = task.TaskId;
                    taskButton.Text = task.TaskName;
                    buttonsTooltip.SetToolTip(taskButton, task.TaskDescription);

                    taskButton.Click += OnTaskButtonClicked;

                    dataLayout.Controls.Add(taskButton);
                }
            }
        }

        //public void UpdateTimeFrameUI(int taskId)
        //{
        //    List<TaskEntity>? taskList = Db.GetTaskListForProjectWithId(projectId);
        //    if (taskList == null || taskList.Count <= 0)
        //    {
        //        return;
        //    }

        //    dataLayout.Controls.Clear();

        //    foreach (TaskEntity task in taskList)
        //    {
        //        Button taskButton = ButtonFactory.CreateButton(task);

        //        taskButton.Tag = task.TaskId;
        //        taskButton.Text = task.TaskName;
        //        buttonsTooltip.SetToolTip(taskButton, task.TaskDescription);

        //        taskButton.Click += OnTaskButtonClicked;

        //        dataLayout.Controls.Add(taskButton);
        //    }

        //    selectedProjectId = projectId;
        //    DataLayoutState = DataLayoutState.TASK;
        //    titleLabel.Text = TASK_TITLE;
        //}

        private async void OnTaskButtonClicked(object? sender, EventArgs e)
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

            if (!int.TryParse(button.Tag.ToString(), out int taskId))
            {
                return;
            }

            TaskEntity? selectedTask = await db.GetTaskWithIdAsync(taskId);
            if (selectedTask == null)
            {
                return;
            }

            List<TimeFrameEntity>? timeFrameEntityList = db.GetTimeFrameListForTaskWithId(taskId);
            if (timeFrameEntityList == null || timeFrameEntityList.Count <= 0)
            {
                TimeFrameForm timeFrameForm = new TimeFrameForm(taskId, selectedTask.TaskName, selectedTask.TaskDescription, db);
                timeFrameForm.Show();

                return;
            }
        }

        private void UpdateProjectUI()
        {
            List<ProjectEntity>? projectList = db.GetProjectList();
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
            dataLayoutState = DataLayoutState.PROJECT;
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
            switch (dataLayoutState)
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
