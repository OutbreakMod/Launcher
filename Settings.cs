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

            INIFile config = Form1.GetConfig();

            this.textBoxCBAA3.Text = config.Read("Mod", "CBA");
            this.textBoxCUPT.Text = config.Read("Mod", "Terrains");
            this.textBoxCUPW.Text = config.Read("Mod", "Weapons");
            this.textBoxOutbreak.Text = config.Read("Mod", "Outbreak");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            INIFile config = Form1.GetConfig();

            config.Write("Launcher", "Windowed", this.checkBox1.Checked ? "1" : "0");
            config.Write("Launcher", "CloseAfterJoin", this.checkBox1.Checked ? "1" : "0");
            config.Write("Launcher", "Path", this.textBox1.Text);
            config.Write("Launcher", "LaunchParameters", this.textBox2.Text);

            config.Write("Mod", "CBA", config.Read("Mod", "CBA"));
            config.Write("Mod", "Weapons", config.Read("Mod", "Weapons"));
            config.Write("Mod", "Terrains", config.Read("Mod", "Terrains"));
            config.Write("Mod", "Outbreak", config.Read("Mod", "Outbreak"));

            FileSettings.SetValue("Path", config.Read("Launcher", "Path"));
            FileSettings.SetValue("LaunchParameters", config.Read("Launcher", "LaunchParameters"));
            FileSettings.SetValue("Windowed", config.Read("Launcher", "Windowed"));
            FileSettings.SetValue("CloseAfterJoin", config.Read("Launcher", "CloseAfterJoin"));
        }
    }
}
