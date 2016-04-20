using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Drawing;
using System.ComponentModel;

namespace OutbreakLauncher
{
    public partial class VerifyFiles : Form
    {
        private List<ModFile> FileList;
        private Dictionary<string, object[]> DownloadUrls = new Dictionary<string, object[]>();
        private string CurrentFile = "";

        public VerifyFiles()
        {
            this.FileList = new List<ModFile>();
            this.FormClosing += VerifyFiles_FormClosing;

            InitializeComponent();

            TableLayoutRowStyleCollection styles = tableLayoutPanel1.RowStyles;

            foreach (RowStyle style in styles)
            {
                style.SizeType = SizeType.Absolute;
                style.Height = 20;
            }
        }

        private void VerifyFiles_Load(object sender, EventArgs e)
        {
            this.DownloadList();
        }

        public void DownloadList()
        {
            this.FileList.Clear();
            this.tableLayoutPanel1.Controls.Clear();

            String Path = FileSettings.GetValue("Path") + "/@Outbreak/";

            WebClient client = new WebClient();
            string response = "";

            try
            {
                response = client.DownloadString("http://outbreakmod.com/download/file_list_generate.php");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            foreach (String FileData in response.Split(Environment.NewLine.ToCharArray()))
            {
                if (FileData.Length < 1)
                {
                    continue;
                }

                string Name = FileData.Split('|')[0];
                string Checksum = FileData.Split('|')[1];

                Label label = new Label();
                label.Text = Name.Split('/')[1];
                label.Width = 160;
                label.Name = Checksum;

                bool FileExists = File.Exists(FileSettings.GetValue("Path") + "/" + Form1.GetConfig().Read("Mod", "Outbreak") + "/" + Name);

                Label status = new Label();
                status.Width = 240;

                if (!FileExists)
                {
                    status.Text = "Not Installed";
                    status.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    string Filesum = "";

                    using (var stream = File.Open(FileSettings.GetValue("Path") + "/" + Form1.GetConfig().Read("Mod", "Outbreak")  + "/" + Name, FileMode.Open))
                    {
                        SHA1Managed sha = new SHA1Managed();
                        byte[] checksum = sha.ComputeHash(stream);
                        Filesum = BitConverter.ToString(checksum).Replace("-", string.Empty);
                    }

                    if (Checksum.ToLower() == Filesum.ToLower())
                    {
                        status.Text = "Installed && Up to date";
                        status.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                    else
                    {

                        status.Text = "Requires Update";
                        status.ForeColor = System.Drawing.Color.Red;
                    }
                }

                if (status.ForeColor == System.Drawing.Color.Red)
                {
                    this.FileList.Add(new ModFile(label.Text, true));
                    DownloadUrls.Add(Name, new object[] { "http://outbreakmod.com/download/" + Name, status });
                }

                int count = tableLayoutPanel1.Controls.Count;
                tableLayoutPanel1.Controls.Add(label, 0, count);
                tableLayoutPanel1.Controls.Add(status, 1, count);

                int HeightAdd = 20;

                this.Height = this.Height + HeightAdd;
                this.tableLayoutPanel1.Height = this.tableLayoutPanel1.Height + HeightAdd;
                this.button1.Location = new Point(this.button1.Location.X, this.button1.Location.Y + HeightAdd);
                this.downloadBar.Location = new Point(this.downloadBar.Location.X, this.downloadBar.Location.Y + HeightAdd);
                this.downloadNotif.Location = new Point(this.downloadNotif.Location.X, this.downloadNotif.Location.Y + HeightAdd);
            }

            if (this.FileList.Count < 1)
            {
                this.button1.Enabled = false;
                this.button1.Location = new Point(this.button1.Location.X, this.button1.Location.Y - 10);
                this.Height = this.Height - 100;

                this.downloadBar.Hide();
                this.downloadNotif.Hide();

            }
            else
            {
                MessageBox.Show("Some files were found to be either out of date or missing.");
                //this.Height = this.Height - 58;
               // this.downloadBar.Hide();
                //this.downloadNotif.Hide();
            }
        }

        private void VerifyFiles_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //Form1.SplashForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.FileList.Count < 1)
            {
                MessageBox.Show("There's no required updates");
            }
            else
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

                foreach (KeyValuePair<string, object[]> kvp in this.DownloadUrls)
                {
                    this.CurrentFile = kvp.Key;
                    string URL = kvp.Value[0].ToString();

                    client.DownloadFileAsync(new Uri(URL), FileSettings.GetValue("Path") + "/@Outbreak/" + kvp.Key);
                    return;
                }
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());

            double megabyteIn = Math.Round(bytesIn / 1000 / 1000, 1);
            double megabyteTotal = Math.Round(totalBytes / 1000 / 1000, 1);

            double percentage = bytesIn / totalBytes * 100;
            double percent = Math.Truncate(percentage);

            Label status = (Label)this.DownloadUrls[this.CurrentFile][1];
            status.Text = "Downloading...";
            status.ForeColor = System.Drawing.Color.Orange;

            this.downloadNotif.Text = "Downloading " + this.CurrentFile.Split('/')[1] + " " + megabyteIn + " MB / " + megabyteTotal + " MB (" + percent + "%)...";

            downloadBar.Value = int.Parse(percent.ToString());
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Label status = (Label) this.DownloadUrls[this.CurrentFile][1];
            status.Text = "Installed && Up to date";
            status.ForeColor = System.Drawing.Color.DarkGreen;

            this.DownloadUrls.Remove(this.CurrentFile);

            if (this.DownloadUrls.Count > 0)
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

                foreach(KeyValuePair < string, object[] > kvp in this.DownloadUrls)
                {
                    this.CurrentFile = kvp.Key;
                    string URL = kvp.Value[0].ToString();

                    client.DownloadFileAsync(new Uri(URL), FileSettings.GetValue("Path") + "/@Outbreak/" + kvp.Key);
                    return;
                }
            }
            else
            {
                this.downloadNotif.Text = "Downloading completed!";

                DelayAction(2000, new Action(() =>
                {
                    this.ResetForm();
                    this.DownloadList();
                }));

                Form1.Form.txtVersionStatus.ForeColor = System.Drawing.Color.Green;
                Form1.Form.txtVersionStatus.Text = "Up to date";
            }

        }

        public static void DelayAction(int millisecond, Action action)
        {
            var timer = new Timer();
            timer.Tick += delegate

            {
                action.Invoke();
                timer.Stop();
            };

            timer.Interval = (int)TimeSpan.FromMilliseconds(millisecond).TotalMilliseconds;
            timer.Start();
        }

        private void ResetForm()
        {
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.82699F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.17301F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 56);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(253, 21);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Update Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Verifying the files will check with our system \r\nto see if your mod is up to date" +
    ".";
            // 
            // downloadBar
            // 
            this.downloadBar.Location = new System.Drawing.Point(7, 107);
            this.downloadBar.Name = "downloadBar";
            this.downloadBar.Size = new System.Drawing.Size(253, 23);
            this.downloadBar.TabIndex = 5;
            // 
            // downloadNotif
            // 
            this.downloadNotif.AutoSize = true;
            this.downloadNotif.Location = new System.Drawing.Point(6, 84);
            this.downloadNotif.Name = "downloadNotif";
            this.downloadNotif.Size = new System.Drawing.Size(100, 13);
            this.downloadNotif.TabIndex = 6;
            this.downloadNotif.Text = "Download Status... ";
            // 
            // VerifyFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 187);
            this.Name = "VerifyFiles";
            this.Text = "Verify Files";
        }
    }
}
