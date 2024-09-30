using KeepCalm_KeepTrack.Database;

namespace KeepCalm_KeepTrack.Client
{
    public partial class AddTaskForm : Form
    {
        public event EventHandler? OnCustomClosed;

        private const string NO_NAME_INFO = "You have to insert a task name!";
        private const string NO_PROJECT_ID_INFO = "You have to select a project before adding a task!";
        private const string TASK_ADDED_INFO = "New task added to database";
        private const string TASK_NOT_ADDED_INFO = "Task cannot be added due to errors!";

        private readonly SqlDatabase db;
        private readonly int selectedProjectId;

        private string taskName;
        private string taskDescription;

        public AddTaskForm(SqlDatabase db, int selectedProjectId)
        {
            InitializeComponent();

            this.db = db;
            this.selectedProjectId = selectedProjectId;

            taskName = string.Empty;
            taskDescription = string.Empty;
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

            int projectId = selectedProjectId;

            if (projectId < 0)
            {
                PrintInfo(NO_PROJECT_ID_INFO);

                return;
            }

            if (!await db.AddTaskAsync(taskName, taskDescription, selectedProjectId))
            {
                PrintInfo(TASK_NOT_ADDED_INFO);

                return;
            }

            PrintInfo(TASK_ADDED_INFO);

            ClearForm();
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            OnCustomClosed?.Invoke(this, EventArgs.Empty);

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

        private void OnAddTaskFormClosing(object sender, FormClosingEventArgs e)
        {
            OnCustomClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}
