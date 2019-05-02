using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.IO.Compression;
using System.Diagnostics;

namespace QuestSideloader
{
    public partial class mainForm : Form
    {
        private string adburl = "https://dl.google.com/android/repository/platform-tools-latest-windows.zip";

        public mainForm()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(dragEnter);
            this.DragDrop += new DragEventHandler(dragDrop);

            linkToOculus.LinkBehavior = LinkBehavior.NeverUnderline;

            var b = SystemIcons.Information.ToBitmap();
            pictureBox1.Image = b;
            this.Show();

            init();            
        }

        public void init()
        {
            getadb();
        }

        private void dragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void dragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.EndsWith(".apk"))
                {
                    installApk(file);
                    break;
                }
            }
        }

        private void installApk(string path)
        {
            if (MessageBox.Show("Do you wish to install this app?\nWarning: You should only install apps from developers you trust!", "Install APK", MessageBoxButtons.OKCancel) == DialogResult.OK){
                lStatus.Text = "Installing "+path+"...";
                var o = adbCmd("install -r "+path);
                checkInstallOutput(o);
            }
        }

        private void getadb()
        {           
            if (!System.IO.File.Exists(Application.LocalUserAppDataPath + "/platform-tools/adb.exe"))
            {
                lStatus.Text = "ADB not found.";
                if (MessageBox.Show("To sideload apps, a program called ADB must be downloaded from Google. Click OK to continue...", "Download ADB?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    lStatus.Text = "Please wait...\nThe program may look like it has frozen but be patient!";
                    lDrop.Text = "Downloading: "+adburl;
                    WebClient Client = new WebClient();
                    Application.DoEvents();
                    try {
                        Client.DownloadFile(adburl, Application.LocalUserAppDataPath + "/adb.zip");
                    }
                    catch (WebException we)
                    {
                        MessageBox.Show("An error occurred downloading ADB. Please try again or contact the developer: " + we.ToString());
                        Application.Exit();
                    }

                    try
                    {
                        ZipFile.ExtractToDirectory(Application.LocalUserAppDataPath + "/adb.zip", Application.LocalUserAppDataPath + "/");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("An error occurred extracting ADB. Please try again or contact the developer: "+e.ToString());
                        Application.Exit();
                    }

                    if (!System.IO.File.Exists(Application.LocalUserAppDataPath + "/platform-tools/adb.exe"))
                    {
                        MessageBox.Show("An error occurred extracting ADB. Please try again or contact the developer.");
                        Application.Exit();
                    }
                    else
                        getdevices();
                }
                else
                    Application.Exit();
            }
            else
            {
                getdevices();
            }
        }

        private void getdevices()
        {
            lDrop.Text = "...";
            lStatus.Text = "Getting devices, please plug in your Quest/Go...";

            //adb devices
            var o = adbCmd("devices");
            if (o.ToLower().Contains("unauthorized"))                
            {
                lDrop.Text = "Device found. Please leave your Quest/Go plugged in, put it on and authorize this computer when prompted...";
                devicesTimer.Enabled = true;
            }
            else if (o.Replace("List of devices","").Contains("device"))
            {
                lDrop.Text = "Device found.";
                checkautoinstall();                
            }
            else
            {
                lDrop.Text = "Getting devices, please plug in your Quest/Go...";
                devicesTimer.Enabled = true;
            }
        }

        private string adbCmd(string options)
        {
            Application.DoEvents();
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.WorkingDirectory = "./";
            p.StartInfo.FileName = Application.LocalUserAppDataPath + "/platform-tools/adb.exe";
            p.StartInfo.Arguments = options;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }

        private void checkautoinstall()
        {
            //check for auto-install package apk
            if (System.IO.File.Exists("./autoinstall.apk"))
            {
                lStatus.Text = "Device found.";
                lDrop.Text = "";
                if (MessageBox.Show("Auto-install APK detected. Do you wish to install this app?\nWarning: You should only install apps from developers you trust!", "Confirm Install", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    lStatus.Text = "Auto installing, please wait.";
                    var o = adbCmd("install -r ./autoinstall.apk");
                    checkInstallOutput(o);
                    setupdragndrop();
                    lStatus.Text = "App installed successfully!";
                }
                else
                {
                    setupdragndrop();
                }
            }
            else
            {
                setupdragndrop();
            }
        }

        private void checkInstallOutput(string output)
        {
            if (output.Contains("Success"))
            {
                lStatus.Text = "App installed successfully!";
            }
            else
            {
                lStatus.Text = "App NOT installed!\nInfo: "+output;
            }
        }

        private void setupdragndrop()
        {
            lStatus.Text = "Device found.";
            lDrop.Text = "Drag your app's APK file\nhere to install.";
        }

        private void linkToOculus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://developer.oculus.com/documentation/mobilesdk/latest/concepts/mobile-device-setup-go/");
        }

        private void devicesTimer_Tick(object sender, EventArgs e)
        {
            devicesTimer.Enabled = false;
            getdevices();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
