namespace KeepCalm_KeepTrack.Client
{
    partial class ShowTotalTimeForm
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
            infoLabel = new Label();
            closeButton = new Button();
            projectDescriptionTextBox = new TextBox();
            projectNameTextBox = new TextBox();
            SuspendLayout();
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
            closeButton.Location = new Point(121, 248);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(200, 48);
            closeButton.TabIndex = 5;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += OnCloseButtonClicked;
            // 
            // projectDescriptionTextBox
            // 
            projectDescriptionTextBox.BackColor = Color.Black;
            projectDescriptionTextBox.Enabled = false;
            projectDescriptionTextBox.ForeColor = Color.Gainsboro;
            projectDescriptionTextBox.Location = new Point(12, 53);
            projectDescriptionTextBox.MaxLength = 2048;
            projectDescriptionTextBox.Multiline = true;
            projectDescriptionTextBox.Name = "projectDescriptionTextBox";
            projectDescriptionTextBox.Size = new Size(419, 104);
            projectDescriptionTextBox.TabIndex = 1;
            projectDescriptionTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // projectNameTextBox
            // 
            projectNameTextBox.BackColor = Color.Black;
            projectNameTextBox.Enabled = false;
            projectNameTextBox.ForeColor = Color.Gainsboro;
            projectNameTextBox.Location = new Point(12, 12);
            projectNameTextBox.MaxLength = 255;
            projectNameTextBox.Name = "projectNameTextBox";
            projectNameTextBox.Size = new Size(419, 35);
            projectNameTextBox.TabIndex = 0;
            projectNameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ShowTotalTimeForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.DimGray;
            ClientSize = new Size(443, 308);
            Controls.Add(closeButton);
            Controls.Add(infoLabel);
            Controls.Add(projectDescriptionTextBox);
            Controls.Add(projectNameTextBox);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ShowTotalTimeForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Total Time";
            FormClosing += OnShowTotalTimeFormClosing;
            Load += OnShowTotalTimeFormLoaded;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label infoLabel;
        private Button closeButton;
        private TextBox projectDescriptionTextBox;
        private TextBox projectNameTextBox;
    }
}
