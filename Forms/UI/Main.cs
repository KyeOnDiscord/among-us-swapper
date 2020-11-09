using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ProSwapper
{
    public partial class Main : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public static Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
        public static string AmongUsDataFolder { get; set; }
        public Main()
        {
            InitializeComponent();
            this.Icon = appIcon;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

            if (Settings.Default.GameLocation.Contains("Among Us.exe"))
            AmongUsDataFolder = Path.GetDirectoryName(Settings.Default.GameLocation) + @"\Among Us_Data\";
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private static void CloseGame()
        {
            Process[] b = Process.GetProcesses();
            foreach (Process a in b)
            {

                if (a.ProcessName == "Among Us")
                {
                    a.Kill();
                    MessageBox.Show("Closed Among Us (Among Us needs to be closed to use Pro Swapper Among Us)!", "Pro Swapper Among Us", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) => Program.Cleanup();

        private void Main_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            pictureBox2.ImageLocation = "https://cdn.discordapp.com/attachments/774762337264599061/774832499166937088/amongus.png";
            pictureBox1.ImageLocation = "https://cdn.discordapp.com/attachments/774762337264599061/774832506204979240/proswapper.png";
            pictureBox3.ImageLocation = "https://cdn.discordapp.com/attachments/774762337264599061/774832508089008128/SettingsIcon.png";

            versionlabel.Text = Program.version;
            Dashboard.Instance.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(Dashboard.Instance);
            Dashboard.Instance.BringToFront();
            Thread game = new Thread(CloseGame);
            game.Start();
            detectgame.Start();
            string[] data = Settings.Default.newtheme.Split(';');
            string[] panel1d = data[0].Split(',');
            string[] panel3d = data[2].Split(',');
            string[] panel4d = data[3].Split(',');
            this.BackColor = Color.FromArgb(255, int.Parse(panel1d[0]), int.Parse(panel1d[1]), int.Parse(panel1d[2]));
            panel1.BackColor = this.BackColor;
            texturepacksbutton.BackColor = Color.FromArgb(255, int.Parse(panel3d[0]), int.Parse(panel3d[1]), int.Parse(panel3d[2]));
            button3.BackColor = texturepacksbutton.BackColor;
            texturepacksbutton.ForeColor = Color.FromArgb(255, int.Parse(panel4d[0]), int.Parse(panel4d[1]), int.Parse(panel4d[2]));
            button3.ForeColor = texturepacksbutton.ForeColor;
            versionlabel.ForeColor = texturepacksbutton.ForeColor;
        }

        private void button1_Click(object sender, EventArgs e) => Program.Cleanup();
        private void button2_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void pictureBox1_Click(object sender, EventArgs e) => Dashboard.Instance.BringToFront();
        private static bool already = false;
        private void detectgame_Tick(object sender, EventArgs e)
        {
            Process[] detectfn = Process.GetProcesses();
            foreach (Process theprocess in detectfn)
            {
                if (theprocess.ProcessName == "Among Us")
                {
                    if (already == false)
                    {
                        already = true;
                        MessageBox.Show("Among Us has been detected as opened! Closing Pro Swapper as it can be closed while playing Among Us!", "Pro Swapper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                        Environment.Exit(0);
                    }
                }
            }
        }


        private void texturepacksbutton_Click(object sender, EventArgs e)
        {
            if (!panelContainer.Controls.Contains(Maps.Instance))
            {
                Maps.Instance.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(Maps.Instance);
            }
            Maps.Instance.BringToFront();
        }


        private void pictureBox3_Click(object sender, EventArgs e) => new SettingsForm().Show();

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to install Among Us?", "Pro Swapper Among Us", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                string dir = @"Among_Us_Installed\";
                if (Directory.Exists(dir))
                {
                    MessageBox.Show("Among Us is already installed! If you want to reinstall it delete the Among_Us_Installed Folder", "Pro Swapper Among Us", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    Directory.CreateDirectory(dir);


                using (WebClient a = new WebClient())
                {
                    a.DownloadFile("https://cdn.discordapp.com/attachments/774462801166073918/775098363741208576/Among_Us_2020.10.22.zip", "temp.pro");
                }



                ZipFile.ExtractToDirectory("temp.pro", dir);
                File.Delete("temp.pro");
                Settings.Default.GameLocation = @"Among_Us_Installed\Among Us.exe";
                Settings.Default.Save();
                MessageBox.Show("Installed Among Us 2020.10.22!", "Pro Swapper Among Us", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
