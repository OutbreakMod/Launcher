using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutbreakLauncher
{
    public partial class ModsNotFound : Form
    {
        public ModsNotFound()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.armaholic.com/page.php?id=21912");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://outbreakmod.com/download/@allinarmaterrainpack_2015_01_01.zip.torrent");
        }

        private void ModsNotFound_Load(object sender, EventArgs e)
        {

        }
    }
}
