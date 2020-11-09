using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace ProSwapper
{
    public partial class Maps : UserControl
    {
        private static Maps _instance;
        public static Maps Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Maps();
                return _instance;
            }
        }
        public Maps()
        {
            InitializeComponent();
        }
        List<Item> ItemList = new List<Item>();

        private static string GetLine(string text, int lineNo)
        {
            string[] lines = text.Replace("\r", "").Split('\n');
            return lines.Length >= lineNo ? lines[lineNo - 1] : null;
        }

        public class Item
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public string Downloadurl { get; set; }
            public string imgurl { get; set; }
            public Item(int ItemID, string name, string downloadurl, string imageURL)
            {
                Name = name;
                ID = ItemID;
                Downloadurl = downloadurl;
                imgurl = imageURL;
            }
        }


        private void Skins_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.HorizontalScroll.Enabled = false;
            this.AutoScroll = true;
            string[] data = Settings.Default.newtheme.Split(';');
            string[] panel2d = data[1].Split(',');
            this.BackColor = Color.FromArgb(255, int.Parse(panel2d[0]), int.Parse(panel2d[1]), int.Parse(panel2d[2]));
            WebClient getinfo = new WebClient();
            string infogotten = "";
            try
            {
                infogotten = getinfo.DownloadString("https://textbin.net/raw/nw5jC8GUZb");
            }
            catch
            {
                infogotten = getinfo.DownloadString("https://proswapper.xyz/amongusitems.txt");
            }

            int numLines = infogotten.Split('\n').Length;

            for (int i = 0; i < numLines; i++)
            {
                string[] a = GetLine(infogotten, i + 1).Split(';');
                ItemList.Add(new Item(i, a[0], a[1], a[2]));
                list.Items.Add(a[0]);
            }
            list.SelectedIndex = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://www.reddit.com/user/DepresseoCoffee");

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Item item in ItemList)
            {
                if (list.SelectedIndex == item.ID)
                {
                    pictureBox1.ImageLocation = item.imgurl;
                    button1.Text = "Set Among Us Texture to " + item.Name;
                    tempurl = item.Downloadurl;
                    tempname = item.Name;
                }
            }

            if (list.SelectedIndex == 1)
                linkLabel1.Visible = true;
            else
                linkLabel1.Visible = false;
        }
        private string tempurl { get; set; }
        private string tempname { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Settings.Default.GameLocation.Contains("Among Us.exe"))
            {
                MessageBox.Show("Please select your Among Us.exe in settings!", "Pro Swapper Among Us", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            wait.Visible = true;

            string file1 = Main.AmongUsDataFolder + "globalgamemanagers.assets";
            string file2 = Main.AmongUsDataFolder + "sharedassets0.assets";
            if (File.Exists(file1))
                File.Delete(file1);

            if (File.Exists(file2))
                File.Delete(file2);

            using (WebClient a = new WebClient())
            {
                a.DownloadFile(tempurl, "temp.pro");
            }
            ZipFile.ExtractToDirectory("temp.pro", Main.AmongUsDataFolder);
            File.Delete("temp.pro");
            wait.Visible = false;
            MessageBox.Show("Among Us Texture has been set to " + tempname, "Pro Swapper Among Us", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}