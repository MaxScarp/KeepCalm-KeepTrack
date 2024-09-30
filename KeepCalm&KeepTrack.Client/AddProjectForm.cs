using KeepCalm_KeepTrack.Database;

namespace KeepCalm_KeepTrack.Client
{
    public partial class AddProjectForm : Form
    {
        public event EventHandler? OnCustomClosed;

        private const string NO_NAME_INFO = "You have to insert a project name!";
        private const string PROJECT_ADDED_INFO = "New project added to database";
        private const string PROJECT_NOT_ADDED_INFO = "Project cannot be added due to errors!";

        private readonly SqlDatabase db;

        private string projectName;
        private string projectDescription;

        public AddProjectForm(SqlDatabase db)
        {
            InitializeComponent();

            this.db = db;

            projectName = string.Empty;
            projectDescription = string.Empty;
        }

        private void OnProjectNameTextChanged(object sender, EventArgs e)
        {
            projectName = projectNameTextBox.Text;
        }

        private void OnProjectDescriptionTextChanged(object sender, EventArgs e)
        {
            projectDescription = projectDescriptionTextBox.Text;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(projectName))
            {
                PrintInfo(NO_NAME_INFO);

                return;
            }

            if (!await db.AddProjectAsync(projectName, projectDescription))
            {
                PrintInfo(PROJECT_NOT_ADDED_INFO);

                return;
            }

            PrintInfo(PROJECT_ADDED_INFO);

            ClearForm();
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            OnCustomClosed?.Invoke(this, EventArgs.Empty);

            Close();
        }

        private void ClearForm()
        {
            projectNameTextBox.Text = string.Empty;
            projectDescriptionTextBox.Text = string.Empty;
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
