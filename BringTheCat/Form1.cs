using System;
using System.Media;
using System.Windows.Forms;

namespace BringTheCat
{
    public partial class Form1 : Form
    {
        bool sound = true;
        SoundPlayer simpleSound = new SoundPlayer(@"beep.wav");
        int seconds;
        string countdown;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 1000 };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //allows window to be moved. Do not touch.
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            seconds = 56;
            countdown = null;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            button2.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds < 100 && seconds > 9)
                countdown = "0" + seconds.ToString();
            if (seconds < 10)
                countdown = "00" + seconds.ToString();
            if (seconds == 0) {
                if(sound)
                    simpleSound.Play();
                countdown = "000";
                timer.Stop();
                button2.Enabled = true;
            }


            label1.Text = countdown;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                countdown = "000";
                timer.Stop();
                button2.Enabled = true;
                label1.Text = countdown;
            }
            if(comboBox1.SelectedIndex == 1)
            {
               
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Application.Exit();
            }
            comboBox1.SelectedIndex = -1;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sound = !sound;
            if (sound == true)
            {
                button1.Text = "Sound On";
            }
            else
            {
                button1.Text = "Sound Off";
            }
        }
    }
}
