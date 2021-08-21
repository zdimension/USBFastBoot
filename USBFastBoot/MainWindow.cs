using System;
using System.IO;
using System.Threading;
using System.IO.Compression;
using System.Reflection;
using System.Windows.Forms;
using Ionic.Zip;
using Microsoft.Win32;
using USBFastBoot.Properties;

namespace USBFastBoot
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            btnInstall.Visible = false;
            button1.Visible = false;
            pbxLoading.Visible = true;
            // installation
            var installpath = @"C:\Program Files\USBFastBoot\";

            try
            {
                if (Directory.Exists(installpath)) Directory.Delete(installpath, true);
                Directory.CreateDirectory(installpath);
            }
            catch
            {

            }

            using (var ms = new MemoryStream(Resources.qemu))
            using (var zip = ZipFile.Read(ms))
                foreach (var en in zip)
                    en.Extract(installpath);

            var qemu = "qemu.exe";

            if (cbxUSB.Checked)
            {
                var k = Registry.ClassesRoot.OpenSubKey("Drive", true)
                    .CreateSubKey("shell")
                    .CreateSubKey("Boot on QEMU");
                k.SetValue("Icon", '"' + installpath + qemu + '"');
                k.CreateSubKey("command")
                    .SetValue("", $"\"{installpath}QemuHelper.exe\" %1");
            }

            if (cbxISO.Checked)
            {
                var k = Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", true)
                    .CreateSubKey(".iso")
                    .CreateSubKey("shell")
                    .CreateSubKey("Boot on QEMU");
                k.SetValue("Icon", '"' + installpath + qemu + '"');
                k.CreateSubKey("command")
                    .SetValue("", $"\"{installpath}{qemu}\" -m 2048 -vga std -cdrom \"%1\"");
            }

            if (cbxIMG.Checked)
            {
                var k = Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", true)
                    .CreateSubKey(".img")
                    .CreateSubKey("shell")
                    .CreateSubKey("Boot on QEMU");
                k.SetValue("Icon", '"' + installpath + qemu + '"');
                k.CreateSubKey("command")
                    .SetValue("", $"\"{installpath}{qemu}\" -m 2048 -vga std -fda \"%1\"");
            }


            pbxLoading.Visible = false;
            btnInstall.Visible = true;
            button1.Visible = true;
        }

        private void cbxUSB_CheckedChanged(object sender, EventArgs e)
        {
            btnInstall.Enabled = (cbxUSB.Checked) || (cbxISO.Checked) || (cbxIMG.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            btnInstall.Visible = false;
            pbxLoading.Visible = true;
            try
            {
                Registry.ClassesRoot.OpenSubKey("Drive", true)
                    .OpenSubKey("shell", true)
                    .DeleteSubKeyTree("Boot on QEMU");
            }
            catch
            {
            }
            try
            {
                Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", true)
                    .OpenSubKey(".iso", true)
                    .OpenSubKey("shell", true)
                    .DeleteSubKeyTree("Boot on QEMU");
            }
            catch
            {
            }
            try
            {
                Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", true)
                    .OpenSubKey(".img", true)
                    .OpenSubKey("shell", true)
                    .DeleteSubKeyTree("Boot on QEMU");
            }
            catch
            {
            }
            try
            {
                Directory.Delete(@"C:\Program Files\USBFastBoot\", true);
            }
            catch
            {
            }
            pbxLoading.Visible = false;
            button1.Visible = true;
            btnInstall.Visible = true;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Text += " " + Assembly.GetEntryAssembly().GetName().Version.ToString(2);
        }
    }
}
