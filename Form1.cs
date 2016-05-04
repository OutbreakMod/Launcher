using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutbreakLauncher
{
    public partial class Form1 : Form
    {
        private static INIFile ConfigFile;

        public static Form1 Form;
        public static SplashScreen SplashForm;

        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        public Form1(SplashScreen SplashForm)
        {
            Form = this;
            InitializeComponent();

            Form1.SplashForm = SplashForm;
            this.FormClosing += Form1_FormClosing;

            String ConfigPath = Environment.CurrentDirectory + "\\config.ini";
            ConfigFile = new INIFile(ConfigPath);

            if (!File.Exists(ConfigPath))
            {
                ConfigFile.Write("Launcher", "Path", "C:/Program Files (x86)/Steam/SteamApps/common/Arma 3");
                ConfigFile.Write("Launcher", "LaunchParameters", "-mod=@CBA_A3;@CUP_Terrains;@CUP_Weapons;@Outbreak");
                ConfigFile.Write("Launcher", "Windowed", "0");
                ConfigFile.Write("Launcher", "CloseAfterJoin", "0");

                ConfigFile.Write("Mod", "CBA", "@CBA_A3");
                ConfigFile.Write("Mod", "Terrains", "@CUP_Terrains");
                ConfigFile.Write("Mod", "Weapons", "@CUP_Weapons");
                ConfigFile.Write("Mod", "Outbreak", "@Outbreak");
            }

            FileSettings.SetValue("Path", ConfigFile.Read("Launcher", "Path"));
            FileSettings.SetValue("LaunchParameters", ConfigFile.Read("Launcher", "LaunchParameters"));
            FileSettings.SetValue("Windowed", ConfigFile.Read("Launcher", "Windowed"));
            FileSettings.SetValue("CloseAfterJoin", ConfigFile.Read("Launcher", "CloseAfterJoin"));

            bool foundPath = false;

            if (Directory.Exists(FileSettings.GetValue("Path")))
            {
                foundPath = File.Exists(FileSettings.GetValue("Path") + "/arma3.exe");
            }

            if (!foundPath)
            {
                MessageBox.Show(this, "Could not find Arma 3 directory, please correct correct it in the settings menu.");
            }

            bool statusAIATP = false;
            bool statusMAS = false;
            bool statusOutbreak = true;

            if (Directory.Exists(FileSettings.GetValue("Path") + "/" + ConfigFile.Read("Mod", "Outbreak")))
            {
                try {
                    WebClient client = new WebClient();
                    string response = client.DownloadString("http://outbreakmod.com/download/file_list_generate.php");

                    foreach (String FileData in response.Split(Environment.NewLine.ToCharArray()))
                    {
                        if (FileData.Length < 1)
                        {
                            continue;
                        }

                        string Name = FileData.Split('|')[0];
                        string Checksum = FileData.Split('|')[1];

                        bool FileExists = File.Exists(FileSettings.GetValue("Path") + "/" + ConfigFile.Read("Mod", "Outbreak")  + "/" + Name);

                        if (!FileExists)
                        {
                            statusOutbreak = false;
                        }
                        else
                        {
                            string Filesum = "";

                            using (var stream = File.Open(FileSettings.GetValue("Path") + "/" + ConfigFile.Read("Mod", "Outbreak") + "/" + Name, FileMode.Open))
                            {
                                SHA1Managed sha = new SHA1Managed();
                                byte[] checksum = sha.ComputeHash(stream);
                                Filesum = BitConverter.ToString(checksum).Replace("-", string.Empty);
                            }

                            if (Checksum.ToLower() != Filesum.ToLower())
                            {
                                statusOutbreak = false;
                            }
                        }
                    }

                    if (statusOutbreak)
                    {
                        this.txtVersionStatus.ForeColor = System.Drawing.Color.Green;
                        this.txtVersionStatus.Text = "Up to date";
                    }
                    else
                    {
                        this.txtVersionStatus.ForeColor = System.Drawing.Color.Red;
                        this.txtVersionStatus.Text = "Needs Update (Click to Update)";
                    }
                } catch
                {

                }
            }

            if (Directory.Exists(FileSettings.GetValue("Path") + "/" + ConfigFile.Read("Mod", "CBA")))
            {
                statusMAS = true;
                this.txtCBAA3Status.ForeColor = System.Drawing.Color.Green;
                this.txtCBAA3Status.Text = "Installed";
            }

            if (Directory.Exists(FileSettings.GetValue("Path") + "/" + ConfigFile.Read("Mod", "Weapons")))
            {
                statusMAS = true;
                this.txtWeaponsStatus.ForeColor = System.Drawing.Color.Green;
                this.txtWeaponsStatus.Text = "Installed";
            }

            if (Directory.Exists(FileSettings.GetValue("Path") + "/" + ConfigFile.Read("Mod", "Terrains")))
            {
                statusAIATP = true;
                this.txtTerrainStatus.ForeColor = System.Drawing.Color.Green;
                this.txtTerrainStatus.Text = "Installed";
            }

            if (!statusAIATP || !statusMAS)
            {
                ModsNotFound notFoundForm = new ModsNotFound();
                notFoundForm.Show();
            }
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Form1.SplashForm.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Text == "Settings")
                {
                    frm.TopMost = true;
                    return;
                }
            }

            Settings settings = new Settings();
            settings.Show();
        }

        public static INIFile GetConfig()
        {
            return ConfigFile;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtVersionStatus_Click(object sender, EventArgs e)
        {
            if (txtVersionStatus.Text == "Not Installed (Click to Install)" || txtVersionStatus.Text == "Needs Update (Click to Update)")
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Text == "Verify Files")
                    {
                        frm.TopMost = true;
                        return;
                    }
                }

                VerifyFiles verifyFiles = new VerifyFiles();
                verifyFiles.Show();
            }
        }

        private void verifyFilesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Text == "Verify Files")
                {
                    frm.TopMost = true;
                    return;
                }
            }

            VerifyFiles verifyFiles = new VerifyFiles();
            verifyFiles.Show();
        }

        private void txtMasWeapons_Click(object sender, EventArgs e)
        {

        }
    }
}
