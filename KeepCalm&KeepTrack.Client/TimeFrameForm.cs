namespace KeepCalm_KeepTrack.Client
{
    public partial class TimeFrameForm : Form
    {
        public event EventHandler? OnCustomClosed;

        private const string NO_DESCRIPTION_FOUND = "EMPTY";

        private readonly int selectedTaskId;

        private readonly string taskName;
        private readonly string? taskDescription;

        public TimeFrameForm(int selectedTaskId, string taskName, string? taskDescription)
        {
            InitializeComponent();

            this.selectedTaskId = selectedTaskId;
            this.taskName = taskName;
            this.taskDescription = taskDescription;
        }

        private void OnTimeFrameFormLoaded(object sender, EventArgs e)
        {
            taskNameTextBox.Text = taskName;
            taskDescriptionTextBox.Text = string.IsNullOrWhiteSpace(taskDescription) ? taskDescription : NO_DESCRIPTION_FOUND;

            infoLabel.Text = "TEST";
        }

        private void OnTimeFrameFormClosed(object sender, FormClosedEventArgs e)
        {
            OnCustomClosed?.Invoke(this, EventArgs.Empty);
        }

        private void OnStartStopButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
