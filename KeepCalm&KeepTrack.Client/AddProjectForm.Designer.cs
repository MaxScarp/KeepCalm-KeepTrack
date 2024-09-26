namespace KeepCalm_KeepTrack.Client
{
    partial class AddProjectForm
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
            projectNameTextBox = new TextBox();
            projectDescriptionTextBox = new TextBox();
            saveButton = new Button();
            infoLabel = new Label();
            closeButton = new Button();
            infoLabelCleaningTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // projectNameTextBox
            // 
            projectNameTextBox.BackColor = Color.Black;
            projectNameTextBox.ForeColor = Color.Gainsboro;
            projectNameTextBox.Location = new Point(12, 12);
            projectNameTextBox.MaxLength = 255;
            projectNameTextBox.Name = "projectNameTextBox";
            projectNameTextBox.PlaceholderText = "Project Name";
            projectNameTextBox.Size = new Size(419, 35);
            projectNameTextBox.TabIndex = 0;
            projectNameTextBox.TextAlign = HorizontalAlignment.Center;
            projectNameTextBox.TextChanged += OnProjectNameTextChanged;
            // 
            // projectDescriptionTextBox
            // 
            projectDescriptionTextBox.BackColor = Color.Black;
            projectDescriptionTextBox.ForeColor = Color.Gainsboro;
            projectDescriptionTextBox.Location = new Point(12, 53);
            projectDescriptionTextBox.MaxLength = 2048;
            projectDescriptionTextBox.Multiline = true;
            projectDescriptionTextBox.Name = "projectDescriptionTextBox";
            projectDescriptionTextBox.PlaceholderText = "Project Description (optional)";
            projectDescriptionTextBox.Size = new Size(419, 104);
            projectDescriptionTextBox.TabIndex = 1;
            projectDescriptionTextBox.TextAlign = HorizontalAlignment.Center;
            projectDescriptionTextBox.TextChanged += OnProjectDescriptionTextChanged;
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
            // AddProjectForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.DimGray;
            ClientSize = new Size(443, 308);
            Controls.Add(closeButton);
            Controls.Add(infoLabel);
            Controls.Add(saveButton);
            Controls.Add(projectDescriptionTextBox);
            Controls.Add(projectNameTextBox);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddProjectForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Project Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox projectNameTextBox;
        private TextBox projectDescriptionTextBox;
        private Button saveButton;
        private Label infoLabel;
        private Button closeButton;
        private System.Windows.Forms.Timer infoLabelCleaningTimer;
    }
}
