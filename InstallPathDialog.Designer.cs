namespace PowerYangyang
{
    partial class InstallPathDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PathBrowseButton = new Button();
            InstallPathTextBox = new TextBox();
            OKButton = new Button();
            label1 = new Label();
            ErrorLabel = new Label();
            ExitButton = new Button();
            SuspendLayout();
            // 
            // PathBrowseButton
            // 
            PathBrowseButton.Location = new Point(508, 71);
            PathBrowseButton.Name = "PathBrowseButton";
            PathBrowseButton.Size = new Size(75, 23);
            PathBrowseButton.TabIndex = 0;
            PathBrowseButton.Text = "Browse";
            PathBrowseButton.UseVisualStyleBackColor = true;
            PathBrowseButton.Click += PathBrowseButton_Click;
            // 
            // InstallPathTextBox
            // 
            InstallPathTextBox.Location = new Point(12, 71);
            InstallPathTextBox.Name = "InstallPathTextBox";
            InstallPathTextBox.Size = new Size(490, 23);
            InstallPathTextBox.TabIndex = 1;
            // 
            // OKButton
            // 
            OKButton.Enabled = false;
            OKButton.Location = new Point(508, 104);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 23);
            OKButton.TabIndex = 2;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(401, 30);
            label1.TabIndex = 3;
            label1.Text = "Select the game install directory where \"Wuthering Waves.exe\" was placed.\r\ne.g., D:\\Wuthering Waves\\Wuthering Waves Game";
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.ForeColor = Color.Red;
            ErrorLabel.Location = new Point(12, 53);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(344, 15);
            ErrorLabel.TabIndex = 4;
            ErrorLabel.Text = "Invalid game install directory. Please check your selection again.\r\n";
            ErrorLabel.Visible = false;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(12, 104);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 23);
            ExitButton.TabIndex = 5;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // InstallPathDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 139);
            ControlBox = false;
            Controls.Add(ExitButton);
            Controls.Add(ErrorLabel);
            Controls.Add(label1);
            Controls.Add(OKButton);
            Controls.Add(InstallPathTextBox);
            Controls.Add(PathBrowseButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "InstallPathDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "InstallPathDialog";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PathBrowseButton;
        private TextBox InstallPathTextBox;
        private Button OKButton;
        private Label label1;
        private Label ErrorLabel;
        private Button ExitButton;
    }
}