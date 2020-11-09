using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProSwapper
{
    public partial class Dashboard : UserControl
    {
        private static Dashboard _instance;
        public static Dashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Dashboard();
                return _instance;
            }
        }

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string[] data = Settings.Default.newtheme.Split(';');
            string[] panel2d = data[0].Split(',');
            this.BackColor = Color.FromArgb(255, int.Parse(panel2d[0]), int.Parse(panel2d[1]), int.Parse(panel2d[2])); ;
            about.BackColor = this.BackColor;
            patchnotes.BackColor = this.BackColor;
            string[] panel4d = data[3].Split(',');
            label2.ForeColor = Color.FromArgb(255, int.Parse(panel4d[0]), int.Parse(panel4d[1]), int.Parse(panel4d[2])); ;
            label3.ForeColor = label2.ForeColor;

        }
    }
}
