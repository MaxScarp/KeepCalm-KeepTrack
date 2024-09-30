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
            components = new System.ComponentModel.Container();
            addProjectButton = new Button();
            addTaskButton = new Button();
            addTimeFrameButton = new Button();
            backButton = new Button();
            dataLayout = new FlowLayoutPanel();
            titleLabel = new Label();
            buttonsTooltip = new ToolTip(components);
            SuspendLayout();
            // 
            // addProjectButton
            // 
            addProjectButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addProjectButton.BackColor = Color.Black;
            addProjectButton.FlatAppearance.BorderColor = Color.Black;
            addProjectButton.FlatAppearance.BorderSize = 0;
            addProjectButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            addProjectButton.FlatAppearance.MouseOverBackColor = Color.Black;
            addProjectButton.Location = new Point(15, 12);
            addProjectButton.Name = "addProjectButton";
            addProjectButton.Size = new Size(200, 48);
            addProjectButton.TabIndex = 0;
            addProjectButton.Text = "Add Project";
            addProjectButton.UseVisualStyleBackColor = false;
            addProjectButton.Click += OnAddProjectButtonClicked;
            // 
            // addTaskButton
            // 
            addTaskButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addTaskButton.BackColor = Color.Black;
            addTaskButton.FlatAppearance.BorderColor = Color.Black;
            addTaskButton.FlatAppearance.BorderSize = 0;
            addTaskButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            addTaskButton.FlatAppearance.MouseOverBackColor = Color.Black;
            addTaskButton.Location = new Point(221, 12);
            addTaskButton.Name = "addTaskButton";
            addTaskButton.Size = new Size(200, 48);
            addTaskButton.TabIndex = 1;
            addTaskButton.Text = "Add Task";
            addTaskButton.UseVisualStyleBackColor = false;
            addTaskButton.Click += OnAddTaskButtonClicked;
            // 
            // addTimeFrameButton
            // 
            addTimeFrameButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addTimeFrameButton.BackColor = Color.Black;
            addTimeFrameButton.FlatAppearance.BorderColor = Color.Black;
            addTimeFrameButton.FlatAppearance.BorderSize = 0;
            addTimeFrameButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            addTimeFrameButton.FlatAppearance.MouseOverBackColor = Color.Black;
            addTimeFrameButton.Location = new Point(427, 12);
            addTimeFrameButton.Name = "addTimeFrameButton";
            addTimeFrameButton.Size = new Size(200, 48);
            addTimeFrameButton.TabIndex = 2;
            addTimeFrameButton.Text = "Add Time Frame";
            addTimeFrameButton.UseVisualStyleBackColor = false;
            addTimeFrameButton.Click += OnAddTimeFrameButtonClicked;
            // 
            // backButton
            // 
            backButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            backButton.BackColor = Color.Black;
            backButton.FlatAppearance.BorderColor = Color.Black;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            backButton.FlatAppearance.MouseOverBackColor = Color.Black;
            backButton.Location = new Point(15, 395);
            backButton.Name = "backButton";
            backButton.Size = new Size(200, 48);
            backButton.TabIndex = 4;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += OnBackButtonClicked;
            // 
            // dataLayout
            // 
            dataLayout.AutoScroll = true;
            dataLayout.BackColor = Color.DarkGray;
            dataLayout.BackgroundImageLayout = ImageLayout.None;
            dataLayout.Location = new Point(15, 97);
            dataLayout.Name = "dataLayout";
            dataLayout.Size = new Size(612, 292);
            dataLayout.TabIndex = 5;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(15, 64);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(612, 30);
            titleLabel.TabIndex = 7;
            titleLabel.Text = "PROJECTS";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.DimGray;
            ClientSize = new Size(642, 450);
            Controls.Add(titleLabel);
            Controls.Add(dataLayout);
            Controls.Add(backButton);
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
        }

        #endregion

        private Button addProjectButton;
        private Button addTaskButton;
        private Button addTimeFrameButton;
        private Button backButton;
        private FlowLayoutPanel dataLayout;
        private Label titleLabel;
        private ToolTip buttonsTooltip;
    }
}
