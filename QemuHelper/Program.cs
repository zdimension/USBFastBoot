using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.Versioning;

namespace QemuHelper
{
    [SupportedOSPlatform("windows")]
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var logicalDiskId = args[0][..2];

            var deviceId = string.Empty;
            var tmp = GetDrive(logicalDiskId);
            if (tmp != null) deviceId = tmp["DeviceID"].ToString();
            var dt = DriveType.Fixed;
            if (string.IsNullOrWhiteSpace(deviceId))
            {
                var id = new DriveInfo(logicalDiskId);
                dt = id.DriveType;
                deviceId = @"\\.\" + logicalDiskId.ToUpper();
            }

            Console.WriteLine("Device: " + deviceId);

            Process.Start(new ProcessStartInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "qemu.exe"),
                    " -L . -boot c " +
                    (dt == DriveType.CDRom ? $"-cdrom {deviceId}" : $"-drive file={deviceId},if=virtio") +
                    " -m 2048 -vga std")
                { Verb = "runas", UseShellExecute = true, WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory });
        }

        private static ManagementBaseObject GetDrive(string letter)
        {
            var query =
                $"ASSOCIATORS OF {{Win32_LogicalDisk.DeviceID='{letter}'}} WHERE AssocClass = Win32_LogicalDiskToPartition";
            var queryResults = new ManagementObjectSearcher(query);
            var partitions = queryResults.Get();

            foreach (var partition in partitions)
            {
                query =
                    $"ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='{partition["DeviceID"]}'}} WHERE AssocClass = Win32_DiskDriveToDiskPartition";
                queryResults = new ManagementObjectSearcher(query);
                var drives = queryResults.Get();

                foreach (var drive in drives)
                    return drive;
            }

            return null;
        }
    }
}