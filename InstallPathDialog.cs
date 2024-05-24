using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerYangyang
{
    public partial class InstallPathDialog : Form
    {
        public InstallPathDialog()
        {
            InitializeComponent();
        }

        private void PathBrowseButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog()
            {
                InitialDirectory = @"C:\",
            };

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetFileName(dialog.SelectedPath) == "Wuthering Waves Game" && File.Exists($@"{dialog.SelectedPath}\Wuthering Waves.exe"))
                {
                    ErrorLabel.Visible = false;
                    InstallPathTextBox.Text = dialog.SelectedPath;
                    OKButton.Enabled = true;
                }
                else
                {
                    ErrorLabel.Visible = true;
                }
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.InstallPath = InstallPathTextBox.Text;
            Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
