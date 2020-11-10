using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ProSwapper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (WebClient web = new WebClient())
            {
                try
                {
                    apidata = web.DownloadString("https://textbin.net/raw/OOFBhlcGjX");
                }
                catch
                {
                    try
                    {
                        //Uses Pro Swapper api if user's textbin is blocked
                        apidata = web.DownloadString("https://proswapper.xyz/amongus.txt");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Pro Swapper needs an internet connection to run, if you are already connected to the internet Pro Swapper severs may be blocked in your country, please use a VPN or try disabling your firewall, if you are already doing this please refer to this error: " + ex, "Pro Swapper Among Us", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.Cleanup();
                    }
                }
            }
            string today = DateTime.Today.ToString();
            if (Settings.Default.lastopened != today)
            {
                Process.Start(apidata.Split('|')[0]);
                Settings.Default.lastopened = today;
                Settings.Default.Save();
            }

            if (apidata.Contains("OFFLINE"))
            {
                MessageBox.Show("Pro Swapper Among Us is currently not working. Take a look at our Discord for any announcments", "Pro Swapper Among Us", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.Cleanup();
            }
            string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            version = ver.Substring(2, ver.Length - 2);
            if (!apidata.Contains(version))
            {
                DialogResult result = MessageBox.Show("You do not have the latest version of Pro Swapper. (" + apidata.Split('|')[1] + ") Do you want to be directed to the new download link?", "Pro Swapper Update Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Process.Start("https://proswapper.xyz/downloads");
                    Program.Cleanup();
                }
            }
            if (!apidata.Contains("NOHASH") && !apidata.Contains(prohash))
            {
                MessageBox.Show("This is an old version of Pro Swapper which no longer works, please download the newest version of Pro Swapper", "Pro Swapper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start("https://proswapper.xyz/downloads");
                Program.Cleanup();
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        public static string version { get; set; }

        private static string apidata { get; set; }
        public static void Cleanup()
        {
            Application.Exit();
            Environment.Exit(0);
        }


        // The cryptographic service provider.
        public static MD5 Md5 = MD5.Create();

        // Compute the file's hash.
        public static byte[] GetHashMD5(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Md5.ComputeHash(stream);
            }
        }
        // Return a byte array as a sequence of hex values.
        public static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result;
        }

        public static string prohash = BytesToString(GetHashMD5(AppDomain.CurrentDomain.FriendlyName));

    }
}