namespace KeepCalm_KeepTrack.Client
{
    partial class TimeFrameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startStopButton = new Button();
            infoLabel = new Label();
            closeButton = new Button();
            taskDescriptionTextBox = new TextBox();
            taskNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // startStopButton
            // 
            startStopButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startStopButton.BackColor = Color.Black;
            startStopButton.FlatAppearance.BorderColor = Color.Black;
            startStopButton.FlatAppearance.BorderSize = 0;
            startStopButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            startStopButton.FlatAppearance.MouseOverBackColor = Color.Black;
            startStopButton.Location = new Point(12, 248);
            startStopButton.Name = "startStopButton";
            startStopButton.Size = new Size(200, 48);
            startStopButton.TabIndex = 2;
            startStopButton.Text = "Start/Stop";
            startStopButton.UseVisualStyleBackColor = false;
            startStopButton.Click += OnStartStopButtonClicked;
            // 
            // infoLabel
            // 
            infoLabel.Location = new Point(12, 160);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(419, 85);
            infoLabel.TabIndex = 4;
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            closeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            closeButton.BackColor = Color.Black;
            closeButton.FlatAppearance.BorderColor = Color.Black;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            closeButton.FlatAppearance.MouseOverBackColor = Color.Black;
            closeButton.Location = new Point(231, 248);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(200, 48);
            closeButton.TabIndex = 5;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += OnCloseButtonClicked;
            // 
            // taskDescriptionTextBox
            // 
            taskDescriptionTextBox.BackColor = Color.Black;
            taskDescriptionTextBox.Enabled = false;
            taskDescriptionTextBox.ForeColor = Color.Gainsboro;
            taskDescriptionTextBox.Location = new Point(12, 53);
            taskDescriptionTextBox.MaxLength = 2048;
            taskDescriptionTextBox.Multiline = true;
            taskDescriptionTextBox.Name = "taskDescriptionTextBox";
            taskDescriptionTextBox.Size = new Size(419, 104);
            taskDescriptionTextBox.TabIndex = 1;
            taskDescriptionTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // taskNameTextBox
            // 
            taskNameTextBox.BackColor = Color.Black;
            taskNameTextBox.Enabled = false;
            taskNameTextBox.ForeColor = Color.Gainsboro;
            taskNameTextBox.Location = new Point(12, 12);
            taskNameTextBox.MaxLength = 255;
            taskNameTextBox.Name = "taskNameTextBox";
            taskNameTextBox.Size = new Size(419, 35);
            taskNameTextBox.TabIndex = 0;
            taskNameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // TimeFrameForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.DimGray;
            ClientSize = new Size(443, 308);
            Controls.Add(closeButton);
            Controls.Add(infoLabel);
            Controls.Add(startStopButton);
            Controls.Add(taskDescriptionTextBox);
            Controls.Add(taskNameTextBox);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "TimeFrameForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Time Frame Details";
            Load += OnTimeFrameFormLoaded;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button startStopButton;
        private Label infoLabel;
        private Button closeButton;
        private TextBox taskDescriptionTextBox;
        private TextBox taskNameTextBox;
    }
}
