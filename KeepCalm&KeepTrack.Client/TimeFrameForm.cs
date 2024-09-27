using KeepCalm_KeepTrack.Database;
using KeepCalm_KeepTrack.Database.Entities;

namespace KeepCalm_KeepTrack.Client
{
    public partial class TimeFrameForm : Form
    {
        private const string NO_DESCRIPTION_FOUND = "EMPTY";
        private const string NO_TIME_FRAME_FOUND = "You have spent no time on this task yet!";
        private const string BUTTON_TEXT_START = "Start";
        private const string BUTTON_TEXT_STOP = "STop";

        private readonly int selectedTaskId;
        private readonly string taskName;
        private readonly string? taskDescription;

        private readonly SqlDatabase db;
        private readonly List<TimeFrameEntity>? timeFrameList;

        public TimeFrameForm(int selectedTaskId, string taskName, string? taskDescription, SqlDatabase db, List<TimeFrameEntity>? timeFrameList = null)
        {
            InitializeComponent();

            this.selectedTaskId = selectedTaskId;
            this.taskName = taskName;
            this.taskDescription = taskDescription;

            this.db = db;
            this.timeFrameList = timeFrameList;
        }

        private void OnTimeFrameFormLoaded(object sender, EventArgs e)
        {
            taskNameTextBox.Text = taskName;
            taskDescriptionTextBox.Text = string.IsNullOrWhiteSpace(taskDescription) ? taskDescription : NO_DESCRIPTION_FOUND;

            if (timeFrameList == null || timeFrameList.Count <= 0)
            {
                infoLabel.Text = NO_TIME_FRAME_FOUND;
            }
            else
            {
                timeFrameList.Sort((tf_x, tf_y) => tf_y.TimeFrameStart.CompareTo(tf_x.TimeFrameStart));

                TimeSpan totalTimeWorked = new TimeSpan();
                foreach (TimeFrameEntity timeFrame in timeFrameList)
                {
                    totalTimeWorked += timeFrame.TimeFrameEnd - timeFrame.TimeFrameStart;
                }

                int totalHours = totalTimeWorked.Hours;
                int totalMinutes = totalTimeWorked.Minutes;

                infoLabel.Text = $"First date started: {timeFrameList.First().TimeFrameStart}\nLast date worked: {timeFrameList.Last().TimeFrameEnd}\nTotal time worked: {totalHours} hours and {totalMinutes} minutes";
            }

            startStopButton.Text = BUTTON_TEXT_START;
        }

        private void OnTimeFrameFormClosed(object sender, FormClosedEventArgs e)
        {

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
