namespace KeepCalm_KeepTrack.Client
{
    partial class AddTaskForm
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
            components = new System.ComponentModel.Container();
            taskNameTextBox = new TextBox();
            taskDescriptionTextBox = new TextBox();
            saveButton = new Button();
            infoLabel = new Label();
            closeButton = new Button();
            infoLabelCleaningTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // taskNameTextBox
            // 
            taskNameTextBox.BackColor = Color.Black;
            taskNameTextBox.ForeColor = Color.Gainsboro;
            taskNameTextBox.Location = new Point(12, 12);
            taskNameTextBox.MaxLength = 255;
            taskNameTextBox.Name = "taskNameTextBox";
            taskNameTextBox.PlaceholderText = "Task Name";
            taskNameTextBox.Size = new Size(419, 35);
            taskNameTextBox.TabIndex = 0;
            taskNameTextBox.TextAlign = HorizontalAlignment.Center;
            taskNameTextBox.TextChanged += OnTaskNameTextChanged;
            // 
            // taskDescriptionTextBox
            // 
            taskDescriptionTextBox.BackColor = Color.Black;
            taskDescriptionTextBox.ForeColor = Color.Gainsboro;
            taskDescriptionTextBox.Location = new Point(12, 53);
            taskDescriptionTextBox.MaxLength = 2048;
            taskDescriptionTextBox.Multiline = true;
            taskDescriptionTextBox.Name = "taskDescriptionTextBox";
            taskDescriptionTextBox.PlaceholderText = "Task Description (optional)";
            taskDescriptionTextBox.Size = new Size(419, 104);
            taskDescriptionTextBox.TabIndex = 1;
            taskDescriptionTextBox.TextAlign = HorizontalAlignment.Center;
            taskDescriptionTextBox.TextChanged += OnTaskDescriptionTextChanged;
            // 
            // saveButton
            // 
            saveButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            saveButton.BackColor = Color.Black;
            saveButton.FlatAppearance.BorderColor = Color.Black;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            saveButton.FlatAppearance.MouseOverBackColor = Color.Black;
            saveButton.Location = new Point(12, 248);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(200, 48);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += OnSaveButtonClicked;
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
            // infoLabelCleaningTimer
            // 
            infoLabelCleaningTimer.Interval = 3000;
            infoLabelCleaningTimer.Tick += OnInfoLabelCleaningTimerTicked;
            // 
            // AddTaskForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.DimGray;
            ClientSize = new Size(443, 308);
            Controls.Add(closeButton);
            Controls.Add(infoLabel);
            Controls.Add(saveButton);
            Controls.Add(taskDescriptionTextBox);
            Controls.Add(taskNameTextBox);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddTaskForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Task Details";
            FormClosed += OnAddTaskFormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox taskNameTextBox;
        private TextBox taskDescriptionTextBox;
        private Button saveButton;
        private Label infoLabel;
        private Button closeButton;
        private System.Windows.Forms.Timer infoLabelCleaningTimer;
    }
}
