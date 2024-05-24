using System.Data.SQLite;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace PowerYangyang
{
    public partial class Form1 : Form
    {
        private readonly int[] fpsArray = new int[] { 30, 60, 90, 120 };

        private string connStr = "";

        private JsonNode? gameQualitySettingNode;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Display version
            var ver = Assembly.GetEntryAssembly()?.GetName().Version;
            this.Text = $"{this.Text} v{ver?.Major}.{ver?.Minor}.{ver?.Build}";

            if (Properties.Settings.Default.InstallPath == "")
            {
                var installPathDialog = new InstallPathDialog();
                var result = installPathDialog.ShowDialog();
                if (result != DialogResult.OK)
                {
                    this.Close();
                }
            }

            if (File.Exists($@"{Properties.Settings.Default.InstallPath}\Client\Saved\LocalStorage\LocalStorage.db") == false)
            {
                var result = MessageBox.Show(
                    "LocalStorage.db is not found.\nIf you have never launch the game, please launch the game first and retry.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                if (result != null)
                {
                    this.Close();
                }
            }

            var connStrBuilder = new SQLiteConnectionStringBuilder()
            {
                DataSource = $@"{Properties.Settings.Default.InstallPath}\Client\Saved\LocalStorage\LocalStorage.db"
            };
            connStr = connStrBuilder.ToString();

            // Read current value
            GetGameQualitySettingNode();

            var currentFps = GetFps();
            if (currentFps == -1)
            {
                var result = MessageBox.Show(
                    "Failed to get current fps from db.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                if (result != null)
                {
                    this.Close();
                }
            }
            else
            {
                var currentIndex = Array.IndexOf(fpsArray, currentFps);
                FPSTrackBar.Value = currentIndex != -1 ? currentIndex : 1;
                WriteLog($"Successfully initialized, current FPS is {currentFps}");
            }
        }

        private void FPSTrackBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            gameQualitySettingNode!["KeyCustomFrameRate"] = fpsArray[FPSTrackBar.Value];
            var result = WriteFameQualitySettings();
            if (result == true)
                WriteLog($"Set FPS to {fpsArray[FPSTrackBar.Value]}.");
            else
                WriteLog("Failed to change FPS value.");
        }

        private void GetGameQualitySettingNode()
        {
            string settingsJson = "";

            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from LocalStorage where key = @key";
                    cmd.Parameters.Add(new SQLiteParameter("@key", "GameQualitySetting"));
                    var result = cmd.ExecuteNonQuery();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            settingsJson = reader["value"].ToString() ?? "";
                        }
                        reader.Close();
                    }
                }

                conn.Close();
            }

            gameQualitySettingNode = JsonNode.Parse(settingsJson);
        }

        private int GetFps()
        {
            bool parsed = Int32.TryParse(gameQualitySettingNode?["KeyCustomFrameRate"]?.ToString(), out int fpsInt);
            return parsed ? fpsInt : -1;
        }

        private bool WriteFameQualitySettings()
        {
            var result = false;

            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    var tran = conn.BeginTransaction();

                    cmd.CommandText = "update LocalStorage set value = @value where key = @key";
                    cmd.Parameters.Add(new SQLiteParameter("@value", JsonSerializer.Serialize(gameQualitySettingNode)));
                    cmd.Parameters.Add(new SQLiteParameter("@key", "GameQualitySetting"));
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        tran.Rollback();
                    }
                    else
                    {
                        tran.Commit();
                        result = true;
                    }
                }

                conn.Close();
            }

            return result;
        }

        private void WriteLog(string message)
        {
            if (!string.IsNullOrWhiteSpace(LogTextBox.Text))
            {
                LogTextBox.AppendText("\r\n" + message);
            }
            else
            {
                LogTextBox.AppendText(message);
            }
            LogTextBox.ScrollToCaret();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
