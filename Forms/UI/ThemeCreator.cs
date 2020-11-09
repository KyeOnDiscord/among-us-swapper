using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProSwapper
{
    public partial class ThemeCreator : Form
    {
        public ThemeCreator()
        {
            InitializeComponent();
            this.Icon = Main.appIcon;
            Region = Region.FromHrgn(Main.CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
        }
        private void ThemeCreator_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Main.ReleaseCapture();
                Main.SendMessage(Handle, Main.WM_NCLBUTTONDOWN, Main.HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e) => this.Close();
        private void button9_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog a = new OpenFileDialog())
            {
                a.Title = "Select a Pro Swapper Theme to import";
                a.DefaultExt = "protheme";
                a.Filter = "Pro Swapper Theme (.protheme)|*.protheme";
                a.ShowDialog();
                if (File.Exists(a.FileName))
                {
                    string[] data = File.ReadAllText(a.FileName).Split(';');
                    string[] panel1d = data[0].Split(',');
                    string[] panel2d = data[1].Split(',');
                    string[] panel3d = data[2].Split(',');
                    string[] panel4d = data[3].Split(',');
                    panel1.BackColor = Color.FromArgb(255, int.Parse(panel1d[0]), int.Parse(panel1d[1]), int.Parse(panel1d[2]));
                    panel2.BackColor = Color.FromArgb(255, int.Parse(panel2d[0]), int.Parse(panel2d[1]), int.Parse(panel2d[2]));
                    panel3.BackColor = Color.FromArgb(255, int.Parse(panel3d[0]), int.Parse(panel3d[1]), int.Parse(panel3d[2]));
                    panel4.BackColor = Color.FromArgb(255, int.Parse(panel4d[0]), int.Parse(panel4d[1]), int.Parse(panel4d[2]));
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Title = "Save the current theme";
            a.DefaultExt = "protheme";
            a.FileName = "Pro Swapper Theme.protheme";
            a.Filter = "Pro Swapper Theme (.protheme)|*.protheme";
            a.ShowDialog();
            if (a.FileName != null)
            {
                using (StreamWriter writer = new StreamWriter(a.FileName))
                {
                    writer.WriteLine(panel1.BackColor.R + "," + panel1.BackColor.G + "," + panel1.BackColor.B + ";" + panel2.BackColor.R + "," + panel2.BackColor.G + "," + panel2.BackColor.B + ";" + panel3.BackColor.R + "," + panel3.BackColor.G + "," + panel3.BackColor.B + ";" + panel4.BackColor.R + "," + panel4.BackColor.G + "," + panel4.BackColor.B);
                }
            }

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            color.ShowDialog();
            panel1.BackColor = color.Color;
        }
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            color.ShowDialog();
            panel2.BackColor = color.Color;
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            color.ShowDialog();
            panel3.BackColor = color.Color;
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            color.ShowDialog();
            panel4.BackColor = color.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings.Default.newtheme = panel1.BackColor.R + "," + panel1.BackColor.G + "," + panel1.BackColor.B + ";" + panel2.BackColor.R + "," + panel2.BackColor.G + "," + panel2.BackColor.B + ";" + panel3.BackColor.R + "," + panel3.BackColor.G + "," + panel3.BackColor.B + ";" + panel4.BackColor.R + "," + panel4.BackColor.G + "," + panel4.BackColor.B;
            Settings.Default.Save();
            MessageBox.Show("Pro Swapper needs to be restarted to load the theme. Restarting Pro Swapper now...", "Pro Swapper", MessageBoxButtons.OK, MessageBoxIcon.Information);
            File.Create("Restarting ProSwapper.pro");
            Process.Start(AppDomain.CurrentDomain.FriendlyName);
            Program.Cleanup();

        }

        private void ThemeCreator_Load(object sender, EventArgs e)
        {
            string[] data = Settings.Default.newtheme.Split(';');
            string[] panel1d = data[0].Split(',');
            string[] panel2d = data[1].Split(',');
            string[] panel3d = data[2].Split(',');
            string[] panel4d = data[3].Split(',');
            panel1.BackColor = Color.FromArgb(255, int.Parse(panel1d[0]), int.Parse(panel1d[1]), int.Parse(panel1d[2]));
            panel2.BackColor = Color.FromArgb(255, int.Parse(panel2d[0]), int.Parse(panel2d[1]), int.Parse(panel2d[2]));
            panel3.BackColor = Color.FromArgb(255, int.Parse(panel3d[0]), int.Parse(panel3d[1]), int.Parse(panel3d[2]));
            panel4.BackColor = Color.FromArgb(255, int.Parse(panel4d[0]), int.Parse(panel4d[1]), int.Parse(panel4d[2]));

            Color buttoncolor = panel3.BackColor;
            Color buttontext = panel4.BackColor;

            button2.BackColor = buttoncolor;
            button2.ForeColor = buttontext;

            button9.BackColor = buttoncolor;
            button9.ForeColor = buttontext;

            button3.BackColor = buttoncolor;
            button3.ForeColor = buttontext;

            button4.BackColor = buttoncolor;
            button4.ForeColor = buttontext;

            this.BackColor = panel1.BackColor;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] data = "0,33,113;64,85,170;65,105,255;255,255,255".Split(';');
            string[] panel1d = data[0].Split(',');
            string[] panel2d = data[1].Split(',');
            string[] panel3d = data[2].Split(',');
            string[] panel4d = data[3].Split(',');
            panel1.BackColor = Color.FromArgb(255, int.Parse(panel1d[0]), int.Parse(panel1d[1]), int.Parse(panel1d[2]));
            panel2.BackColor = Color.FromArgb(255, int.Parse(panel2d[0]), int.Parse(panel2d[1]), int.Parse(panel2d[2]));
            panel3.BackColor = Color.FromArgb(255, int.Parse(panel3d[0]), int.Parse(panel3d[1]), int.Parse(panel3d[2]));
            panel4.BackColor = Color.FromArgb(255, int.Parse(panel4d[0]), int.Parse(panel4d[1]), int.Parse(panel4d[2]));
        }
    }
}
