namespace KeepCalm_KeepTrack.Client
{
    public partial class AddTaskForm : Form
    {
        private const string NO_NAME_INFO = "You have to insert a task name!";
        private const string NO_PROJECT_ID_INFO = "You have to select a project before adding a task!";
        private const string TASK_ADDED_INFO = "New task added to database";

        private readonly MainForm mainForm;

        private string taskName;
        private string taskDescription;

        public AddTaskForm(MainForm mainForm)
        {
            InitializeComponent();

            taskName = string.Empty;
            taskDescription = string.Empty;

            this.mainForm = mainForm;
        }

        private void OnAddTaskFormClosed(object sender, FormClosedEventArgs e)
        {
            switch (mainForm.DataLayoutState)
            {
                case DataLayoutState.PROJECT:
                    mainForm.UpdateProjectUI();
                    break;
                case DataLayoutState.TASK:
                    mainForm.UpdateTaskUI(mainForm.selectedProjectId);
                    break;
                case DataLayoutState.TIME_FRAME:
                    break;
            }
        }

        private void OnTaskNameTextChanged(object sender, EventArgs e)
        {
            taskName = taskNameTextBox.Text;
        }

        private void OnTaskDescriptionTextChanged(object sender, EventArgs e)
        {
            taskDescription = taskDescriptionTextBox.Text;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskName))
            {
                PrintInfo(NO_NAME_INFO);

                return;
            }

            int projectId = mainForm.selectedProjectId;

            if (projectId < 0)
            {
                PrintInfo(NO_PROJECT_ID_INFO);

                return;
            }

            await mainForm.Db.AddTaskAsync(taskName, taskDescription, mainForm.selectedProjectId);

            PrintInfo(TASK_ADDED_INFO);

            ClearForm();
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearForm()
        {
            taskNameTextBox.Text = string.Empty;
            taskDescriptionTextBox.Text = string.Empty;
        }

        private void OnInfoLabelCleaningTimerTicked(object sender, EventArgs e)
        {
            ClearInfoAndStopTimer();
        }

        private void ClearInfoAndStopTimer()
        {
            if (!string.IsNullOrWhiteSpace(infoLabel.Text))
            {
                infoLabel.Text = string.Empty;
            }

            infoLabelCleaningTimer.Stop();
        }

        private void PrintInfo(string info)
        {
            infoLabelCleaningTimer.Stop();

            infoLabel.Text = info;

            infoLabelCleaningTimer.Start();
        }
    }
}
