using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace ProSwapper
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            this.Icon = Main.appIcon;
            Region = Region.FromHrgn(Main.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        private void button1_Click(object sender, EventArgs e) => this.Close();
        private void SettingsForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Main.ReleaseCapture();
                Main.SendMessage(Handle, Main.WM_NCLBUTTONDOWN, Main.HT_CAPTION, 0);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Find among us.exe
            using (OpenFileDialog a = new OpenFileDialog())
            {
                a.Title = "Select your Among Us.exe";
                a.Filter = "Among Us (*.exe*)|*.exe*";
                a.ShowDialog();
                if (a.SafeFileName != "Among Us.exe")
                {
                    MessageBox.Show("You didn't select Among Us.exe", "Pro Swapper Among Us", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Settings.Default.GameLocation = a.FileName;
                Settings.Default.Save();
                paksBox.Text = a.FileName;
                Main.AmongUsDataFolder = Path.GetDirectoryName(Settings.Default.GameLocation) + @"\Among Us_Data\";
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            pictureBox7.ImageLocation = "https://cdn.discordapp.com/attachments/774762337264599061/774832500572684308/folder.png";
            pictureBox1.ImageLocation = "https://cdn.discordapp.com/attachments/774762337264599061/774832510521049108/yt.png";
            pictureBox2.ImageLocation = "https://cdn.discordapp.com/attachments/774762337264599061/774832509041115145/twitter.png";
            paksBox.Text = Settings.Default.GameLocation;
            string[] data = Settings.Default.newtheme.Split(';');
            string[] panel2d = data[0].Split(',');
            this.BackColor = Color.FromArgb(255, int.Parse(panel2d[0]), int.Parse(panel2d[1]), int.Parse(panel2d[2]));

            string[] panel3d = data[2].Split(',');
            string[] panel4d = data[3].Split(',');

            Color buttoncolor = Color.FromArgb(255, int.Parse(panel3d[0]), int.Parse(panel3d[1]), int.Parse(panel3d[2]));
            Color buttontext = Color.FromArgb(255, int.Parse(panel4d[0]), int.Parse(panel4d[1]), int.Parse(panel4d[2]));

            button2.BackColor = buttoncolor;
            button2.ForeColor = buttontext;


            button10.BackColor = buttoncolor;
            button10.ForeColor = buttontext;

            button9.BackColor = buttoncolor;
            button9.ForeColor = buttontext;


            Restart.BackColor = buttoncolor;
            Restart.ForeColor = buttontext;

            label13.ForeColor = buttontext;
            label1.ForeColor = buttontext;
        }

        private void button2_Click(object sender, EventArgs e) => Process.Start(Path.GetDirectoryName(paksBox.Text));
        private void Restart_Click(object sender, EventArgs e)
        {
            Process.Start(AppDomain.CurrentDomain.FriendlyName);
            Program.Cleanup();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.GameLocation);
            Program.Cleanup();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://proswapper.xyz/donate.html");
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://proswapper.xyz/#credits");
        private void button10_Click(object sender, EventArgs e) => new ThemeCreator().ShowDialog();
        private void pictureBox1_Click(object sender, EventArgs e) => Process.Start("https://youtube.com/proswapperofficial");
        private void pictureBox2_Click(object sender, EventArgs e) => Process.Start("https://twitter.com/Pro_Swapper");
    }
}
