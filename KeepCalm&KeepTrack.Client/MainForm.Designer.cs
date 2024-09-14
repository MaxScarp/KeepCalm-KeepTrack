namespace KeepCalm_KeepTrack.Client
{
    partial class MainForm
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
            addProjectButton = new Button();
            addTaskButton = new Button();
            addTimeFrameButton = new Button();
            infoLabel = new Label();
            SuspendLayout();
            // 
            // addProjectButton
            // 
            addProjectButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addProjectButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addProjectButton.BackColor = Color.Black;
            addProjectButton.FlatAppearance.BorderColor = Color.Black;
            addProjectButton.FlatAppearance.BorderSize = 0;
            addProjectButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            addProjectButton.FlatAppearance.MouseOverBackColor = Color.Black;
            addProjectButton.Location = new Point(12, 12);
            addProjectButton.Name = "addProjectButton";
            addProjectButton.Size = new Size(200, 48);
            addProjectButton.TabIndex = 0;
            addProjectButton.Text = "Add Project";
            addProjectButton.UseVisualStyleBackColor = false;
            addProjectButton.Click += OnAddProjectButtonClicked;
            // 
            // addTaskButton
            // 
            addTaskButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addTaskButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addTaskButton.BackColor = Color.Black;
            addTaskButton.FlatAppearance.BorderColor = Color.Black;
            addTaskButton.FlatAppearance.BorderSize = 0;
            addTaskButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            addTaskButton.FlatAppearance.MouseOverBackColor = Color.Black;
            addTaskButton.Location = new Point(218, 12);
            addTaskButton.Name = "addTaskButton";
            addTaskButton.Size = new Size(200, 48);
            addTaskButton.TabIndex = 1;
            addTaskButton.Text = "Add Task";
            addTaskButton.UseVisualStyleBackColor = false;
            addTaskButton.Click += OnAddTaskButtonClicked;
            // 
            // addTimeFrameButton
            // 
            addTimeFrameButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addTimeFrameButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addTimeFrameButton.BackColor = Color.Black;
            addTimeFrameButton.FlatAppearance.BorderColor = Color.Black;
            addTimeFrameButton.FlatAppearance.BorderSize = 0;
            addTimeFrameButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            addTimeFrameButton.FlatAppearance.MouseOverBackColor = Color.Black;
            addTimeFrameButton.Location = new Point(424, 12);
            addTimeFrameButton.Name = "addTimeFrameButton";
            addTimeFrameButton.Size = new Size(200, 48);
            addTimeFrameButton.TabIndex = 2;
            addTimeFrameButton.Text = "Add Time Frame";
            addTimeFrameButton.UseVisualStyleBackColor = false;
            addTimeFrameButton.Click += OnAddTimeFrameButtonClicked;
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Location = new Point(12, 95);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(133, 30);
            infoLabel.TabIndex = 3;
            infoLabel.Text = "DEBUG INFO";
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            Controls.Add(infoLabel);
            Controls.Add(addTimeFrameButton);
            Controls.Add(addTaskButton);
            Controls.Add(addProjectButton);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KeepCalm&KeepTrack";
            Load += OnMainFormLoaded;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addProjectButton;
        private Button addTaskButton;
        private Button addTimeFrameButton;
        private Label infoLabel;
    }
}
