using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutbreakLauncher
{
    public partial class SplashScreen : Form
    {
        private int TimerTick;

        public SplashScreen()
        {
            InitializeComponent();
            this.CenterToScreen();

            TimerTick = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TimerTick = this.TimerTick + 1;

            if (this.TimerTick == 1)
            {
                this.timer1.Stop();
                this.Hide();

                Form1 form = new Form1(this);
                form.Show();
            }
        }
    }
}
