using KeepCalm_KeepTrack.Database;
using KeepCalm_KeepTrack.Database.Entities;

namespace KeepCalm_KeepTrack.Client
{
    public partial class TimeFrameForm : Form
    {
        private const string NO_DESCRIPTION_FOUND = "EMPTY";
        private const string NO_TIME_FRAME_FOUND = "You have spent no time on this task yet!";
        private const string BUTTON_TEXT_START = "Start";
        private const string BUTTON_TEXT_STOP = "Stop";

        private readonly int taskId;
        private readonly string taskName;
        private readonly string? taskDescription;

        private readonly SqlDatabase db;

        private bool isTimerStarted;
        private TimeFrameEntity? timeFrame;

        public TimeFrameForm(int taskId, string taskName, string? taskDescription, SqlDatabase db)
        {
            InitializeComponent();

            this.taskId = taskId;
            this.taskName = taskName;
            this.taskDescription = taskDescription;

            this.db = db;

            isTimerStarted = false;
        }

        private void OnTimeFrameFormLoaded(object sender, EventArgs e)
        {
            taskNameTextBox.Text = taskName;
            taskDescriptionTextBox.Text = string.IsNullOrWhiteSpace(taskDescription) ? taskDescription : NO_DESCRIPTION_FOUND;

            UpdateInfo();
            UpdateStartStopButtonUI();
        }

        private async void OnStartStopButtonClicked(object sender, EventArgs e)
        {
            if (!isTimerStarted)
            {
                timeFrame = await db.AddTimeFrameAsync(taskId);
                if (timeFrame == null)
                {
                    return;
                }

                isTimerStarted = true;
            }
            else
            {
                if (timeFrame == null)
                {
                    return;
                }

                if (!await db.UpdateTimeFrame(timeFrame))
                {
                    return;
                }

                isTimerStarted = false;

                UpdateInfo();
            }

            UpdateStartStopButtonUI();
        }

        private void UpdateInfo()
        {
            List<TimeFrameEntity>? timeFrameList = db.GetTimeFrameListForTaskWithId(taskId);
            if (timeFrameList == null || timeFrameList.Count <= 0)
            {
                infoLabel.Text = NO_TIME_FRAME_FOUND;
            }
            else
            {
                timeFrameList.Sort((tf_x, tf_y) => tf_x.TimeFrameStart.CompareTo(tf_y.TimeFrameStart));

                TimeSpan totalTimeWorked = new TimeSpan();
                foreach (TimeFrameEntity timeFrame in timeFrameList)
                {
                    totalTimeWorked += timeFrame.TimeFrameEnd - timeFrame.TimeFrameStart;
                }

                int totalHours = totalTimeWorked.Hours;
                int totalMinutes = totalTimeWorked.Minutes;
                int totalSeconds = totalTimeWorked.Seconds;

                infoLabel.Text = $"First date started: {timeFrameList.First().TimeFrameStart}\nLast date worked: {timeFrameList.Last().TimeFrameEnd}\nTotal time worked: {totalHours}h {totalMinutes}m {totalSeconds}s";
            }
        }

        private void UpdateStartStopButtonUI()
        {
            startStopButton.Text = isTimerStarted ? BUTTON_TEXT_STOP : BUTTON_TEXT_START;
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            if (isTimerStarted)
            {
                OnStartStopButtonClicked(sender, e);
            }

            Close();
        }
    }
}
