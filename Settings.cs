using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutbreakLauncher
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = FileSettings.GetValue("Windowed") == "1";
            this.checkBox2.Checked = FileSettings.GetValue("CloseAfterJoin") == "1";
            this.textBox1.Text = FileSettings.GetValue("Path");
            this.textBox2.Text = FileSettings.GetValue("LaunchParameters");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            INIFile config = Form1.GetConfig();

            config.Write("Launcher", "Windowed", this.checkBox1.Checked ? "1" : "0");
            config.Write("Launcher", "CloseAfterJoin", this.checkBox1.Checked ? "1" : "0");
            config.Write("Launcher", "Path", this.textBox1.Text);
            config.Write("Launcher", "LaunchParameters", this.textBox2.Text);

            FileSettings.SetValue("Path", config.Read("Launcher", "Path"));
            FileSettings.SetValue("LaunchParameters", config.Read("Launcher", "LaunchParameters"));
            FileSettings.SetValue("Windowed", config.Read("Launcher", "Windowed"));
            FileSettings.SetValue("CloseAfterJoin", config.Read("Launcher", "CloseAfterJoin"));
        }
    }
}
