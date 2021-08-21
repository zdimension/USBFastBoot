using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using SharpCompress.Archives;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Common;
using USBFastBoot.Properties;

namespace USBFastBoot
{
    [SupportedOSPlatform("windows")]
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            btnInstall.Visible = false;
            button1.Visible = false;
            progressBar.Visible = true;

            await Task.Run(() =>
            {
                // installation
                var installpath = @"C:\Program Files\USBFastBoot\";

                try
                {
                    if (Directory.Exists(installpath)) Directory.Delete(installpath, true);
                    Directory.CreateDirectory(installpath);
                }
                catch
                {
                    ;
                }

                using (var ms = new MemoryStream(Resources.qemu))
                using (var zip = ArchiveFactory.Open(ms))
                {
                    var counter = 0;
                    var entries = zip.Entries
                        .Where(x => !x.IsDirectory)
                        .ToArray();
                    progressBar.Invoke((Action)(() => progressBar.Maximum = entries.Length));
                    foreach (var entry in entries)
                    {
                        entry.WriteToDirectory(installpath, new ExtractionOptions
                        {
                            ExtractFullPath = true
                        });
                        progressBar.Invoke((Action)(() => progressBar.Value = Interlocked.Increment(ref counter)));
                    }
                }

                const string qemu = "qemu.exe";

                if (cbxUSB.Checked)
                {
                    var k = Registry.ClassesRoot.OpenSubKey("Drive", true)!
                        .CreateSubKey("shell")!
                        .CreateSubKey("Boot on QEMU");
                    k!.SetValue("Icon", $"\"{installpath}{qemu}\"");
                    k.CreateSubKey("command")!
                        .SetValue("", $"\"{installpath}QemuHelper.exe\" %1");
                }

                if (cbxISO.Checked)
                {
                    var k = Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", true)!
                        .CreateSubKey(".iso")!
                        .CreateSubKey("shell")!
                        .CreateSubKey("Boot on QEMU");
                    k!.SetValue("Icon", $"\"{installpath}{qemu}\"");
                    k.CreateSubKey("command")!
                        .SetValue("", $"\"{installpath}{qemu}\" -m 2048 -vga std -cdrom \"%1\"");
                }

                if (cbxIMG.Checked)
                {
                    var k = Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", true)!
                        .CreateSubKey(".img")!
                        .CreateSubKey("shell")!
                        .CreateSubKey("Boot on QEMU");
                    k!.SetValue("Icon", $"\"{installpath}{qemu}\"");
                    k.CreateSubKey("command")!
                        .SetValue("", $"\"{installpath}{qemu}\" -m 2048 -vga std -fda \"%1\"");
                }
            });
            
            progressBar.Visible = false;
            btnInstall.Visible = true;
            button1.Visible = true;
        }

        private void cbxUSB_CheckedChanged(object sender, EventArgs e)
        {
            btnInstall.Enabled = cbxUSB.Checked || cbxISO.Checked || cbxIMG.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            btnInstall.Visible = false;
            progressBar.Visible = true;
            try
            {
                Registry.ClassesRoot.OpenSubKey("Drive", true)!
                    .OpenSubKey("shell", true)!
                    .DeleteSubKeyTree("Boot on QEMU");
            }
            catch
            {
                ;
            }
            try
            {
                Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", true)!
                    .OpenSubKey(".iso", true)!
                    .OpenSubKey("shell", true)!
                    .DeleteSubKeyTree("Boot on QEMU");
            }
            catch
            {
                ;
            }
            try
            {
                Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", true)!
                    .OpenSubKey(".img", true)!
                    .OpenSubKey("shell", true)!
                    .DeleteSubKeyTree("Boot on QEMU");
            }
            catch
            {
                ;
            }
            try
            {
                Directory.Delete(@"C:\Program Files\USBFastBoot\", true);
            }
            catch
            {
                ;
            }
            progressBar.Visible = false;
            button1.Visible = true;
            btnInstall.Visible = true;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Text += " " + Assembly.GetEntryAssembly()!.GetName().Version!.ToString(2);
        }
    }
}
