namespace KeepCalm_KeepTrack.Client
{
    public partial class AddProjectForm : Form
    {
        private const string NO_NAME_INFO = "You have to insert a project name!";
        private const string PROJECT_ADDED_INFO = "New project added to database";

        private readonly MainForm mainForm;

        private string projectName;
        private string projectDescription;

        public AddProjectForm(MainForm mainForm)
        {
            InitializeComponent();

            projectName = string.Empty;
            projectDescription = string.Empty;

            this.mainForm = mainForm;
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

            await mainForm.db.AddProjectAsync(projectName, projectDescription);

            PrintInfo(PROJECT_ADDED_INFO);

            ClearForm();
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
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
